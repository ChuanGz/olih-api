namespace Olih.Domain.DTOs;

public class BranchDto(string branchId, string branchName)
{
    public string BranchId { get; set; } = branchId;
    public string BranchName { get; set; } = branchName;
    public string BranchStatus { get; set; } = "A";
    public AddressDto BranchAddress { get; set; } = new AddressDto{
        StreetNo = "14 Ton That Thuyet",
        Ward = "12 ward",
        District = "",
        City = "Ho Chi Minh city",
    };
    public int HeadCount { get; set; } = new Random().Next(1000, 9999);
}
