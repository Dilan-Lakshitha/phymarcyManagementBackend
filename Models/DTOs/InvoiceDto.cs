namespace phymarcyManagement.Models.DTOs;

public class InvoiceDto
{
    public int CustomerId { get; set; }
    public List<InvoiceDrugDto> Drugs { get; set; }
}

public class InvoiceDrugDto
{
    public int DrugId { get; set; }
    public int Quantity { get; set; }
}

public class InvoiceDetailsDto
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime PurchaseDate { get; set; }
    public List<InvoiceItemDto> Items { get; set; } = new();
}

public class InvoiceItemDto
{
    public int DrugId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
