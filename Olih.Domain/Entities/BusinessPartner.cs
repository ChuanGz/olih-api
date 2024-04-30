namespace Olih.Domain.Entities;

public class BusinessPartner
{
    public required string Id { get; set; }
    public required string CardCode { get; set; }
    public required string CardName { get; set; }
    public required string CardNumber { get; set; }
    public List<Address>? Addresses { get; set; }
    public double CurrentBalance { get; set; }
    public double CreditLimit { get; set; }
}
