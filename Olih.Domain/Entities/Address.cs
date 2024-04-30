using Olih.Common;

namespace Olih.Domain.Entities;
public class Address : BaseEntity
{
    public string? StreetNo { get; set; }
    public string? Ward { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
}
