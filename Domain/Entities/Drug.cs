namespace phymarcyManagement.Domain.Entities;

public class Drug
{
    public int drug_id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public decimal price { get; set; }
    public int quantity { get; set; }
    public int supplier_id { get; set; }
}