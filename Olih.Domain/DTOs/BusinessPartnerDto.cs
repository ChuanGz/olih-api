namespace Olih.Domain.DTOs;

public class BusinessPartnerDto
{
    public string? CardCode { get; set; }
    public string? CardNumber { get; set; }
    public string? CardName { get; set; }
    public double CurrentBal { get; set; }
    public double CreditLimit { get; set; }
}
