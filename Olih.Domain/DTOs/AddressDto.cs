namespace Olih.Domain.DTOs;

public class AddressDto
{
    public string? FullAddress
    {
        get { return this.StreetNo + ", " + this.Ward + ", " + this.District + ", " + this.City + ", " + this.Country; }
    }
    public string? StreetNo { get; set; }
    public string? Ward { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
