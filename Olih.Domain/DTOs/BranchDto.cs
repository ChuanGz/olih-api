namespace Olih.Domain.DTOs;

public class BranchDto
{
    public required string BranchId { get; set; }
    public required string BranchName { get; set; }
    public string? BranchStatus { get; set; }
    public AddressDto? BranchAddress { get; set; } 
    public int HeadCount { get; set; }
}
