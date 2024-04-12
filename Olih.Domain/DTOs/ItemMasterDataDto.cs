namespace Olih.Domain.DTOs;

public class ItemMasterDataDto
{
    public string? ItemCode { get; set; }
    public string? ItemName { get; set; }
    public string? ItemDescription { get; set; }
    public string? UoM { get; set; }
    public double AvailableQty
    {
        get { return InStockQty - CommittedQty + OrderedQty; }
    } // Available Qty=Instock-Committed+Ordered
    public double InStockQty { get; set; }
    public double CommittedQty { get; set; }
    public double OrderedQty { get; set; }
}
