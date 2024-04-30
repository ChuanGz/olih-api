using Olih.Common;

namespace Olih.Domain.Entities;
public class Product : BaseEntity
{
    public string? ItemCode { get; set; }
    public string? ItemName { get; set; }
    public string? ItemDescription { get; set; }
    public string? UoM { get; set; }
    public double AvailableQty { get; set; }
    public double InStockQty { get; set; }
    public double CommittedQty { get; set; }
    public double OrderedQty { get; set; }
}
