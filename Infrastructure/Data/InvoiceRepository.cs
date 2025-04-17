using System.Data;
using Dapper;
using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Models.DTOs;

namespace phymarcyManagement.Infrastructure.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DapperContext _context;

        public InvoiceRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateInvoiceAsync(InvoiceDto invoiceDto)
        {
            using var connection = _context.CreateConnection();
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open(); // Ensure the connection is open
            }
            
            using var transaction = connection.BeginTransaction();

            try
            {
                decimal totalAmount = 0;

                foreach (var item in invoiceDto.Drugs)
                {
                    var priceQuery = "SELECT price FROM drug WHERE drug_id = @DrugId";
                    var price = await connection.QuerySingleAsync<decimal>(priceQuery, new { item.DrugId }, transaction);

                    totalAmount += price * item.Quantity;
                    
                    var stockCheck = "SELECT quantity FROM drug WHERE drug_id = @DrugId";
                    var available = await connection.QuerySingleAsync<int>(stockCheck, new { item.DrugId }, transaction);

                    if (available < item.Quantity)
                        throw new Exception("Insufficient stock for drug ID: " + item.DrugId);

                    var stockUpdate = "UPDATE drug SET quantity = quantity - @Qty WHERE drug_id = @DrugId";
                    await connection.ExecuteAsync(stockUpdate, new { Qty = item.Quantity, item.DrugId }, transaction);
                }
                
                var insertInvoice = @"
                    INSERT INTO invoice (customer_id, total_amount, purchase_date)
                    VALUES (@CustomerId, @TotalAmount, @PurchaseDate)
                    RETURNING invoice_id;
                ";

                var invoiceId = await connection.ExecuteScalarAsync<int>(insertInvoice, new
                {
                    invoiceDto.CustomerId,
                    TotalAmount = totalAmount,
                    PurchaseDate = DateTime.UtcNow
                }, transaction);
                
                foreach (var item in invoiceDto.Drugs)
                {
                    var price = await connection.QuerySingleAsync<decimal>(
                        "SELECT price FROM drug WHERE drug_id = @DrugId", new { item.DrugId }, transaction
                    );

                    var insertDrug = @"
                        INSERT INTO invoice_drug (invoice_id, drug_id, quantity, price)
                        VALUES (@InvoiceId, @DrugId, @Quantity, @Price);
                    ";

                    await connection.ExecuteAsync(insertDrug, new
                    {
                        InvoiceId = invoiceId,
                        item.DrugId,
                        item.Quantity,
                        Price = price
                    }, transaction);
                }

                transaction.Commit();
                return invoiceId;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        
        public async Task<InvoiceDetailsDto> GetInvoiceByIdAsync(int invoiceId)
        {
            using var connection = _context.CreateConnection();

            var invoiceQuery = @"
    SELECT 
        invoice_id AS InvoiceId,
        customer_id AS CustomerId,
        total_amount AS TotalAmount,
        purchase_date AS PurchaseDate
    FROM invoice
    WHERE invoice_id = @Id
";
            var invoice = await connection.QuerySingleOrDefaultAsync<InvoiceDetailsDto>(invoiceQuery, new { Id = invoiceId });

            if (invoice == null) return null;

            var itemsQuery = @"
        SELECT d.drug_id, d.name, id.quantity, id.price
        FROM invoice_drug id
        JOIN drug d ON id.drug_id = d.drug_id
        WHERE id.invoice_id = @Id
    ";

            var items = (await connection.QueryAsync<InvoiceItemDto>(itemsQuery, new { Id = invoiceId })).ToList();
            invoice.Items = items;

            return invoice;
        }

    }
}
