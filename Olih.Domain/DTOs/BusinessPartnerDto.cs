using System.Net.Sockets;

namespace Olih.Domain.DTOs;

public class BusinessPartnerDto
{
    public string? CardCode { get; set; }
    public string? CardNumber { get; set; }
    public string? CardName { get; set; }
    public List<AddressDto>? Addresses { get; set; }
    public double CurrentBalance { get; set; }
    public double CreditLimit { get; set; }
}
