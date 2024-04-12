namespace Olih.Domain.Interfaces;

public class UpdateBusinessPartnerRequestModel
{
    public required string CardCode { get; set; }
    public required string CardName { get; set; }
    public required string CardNumber { get; set; }
}
