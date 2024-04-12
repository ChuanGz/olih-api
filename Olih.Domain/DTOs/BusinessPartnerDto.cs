using System.Net.Sockets;

namespace Olih.Domain.DTOs;

public class BusinessPartnerDto
{
    public required string CardCode { get; set; }
    public required string CardName { get; set; }
    public required string CardNumber { get; set; }
    public List<AddressDto>? Addresses { get; set; }
    public double CurrentBalance { get; set; }
    public double CreditLimit { get; set; }
}
