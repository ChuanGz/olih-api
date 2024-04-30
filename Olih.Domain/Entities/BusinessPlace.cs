namespace Olih.Domain.Entities;

public class BranchPlace
{
    public required string Id { get; set; }
    public required string BranchName { get; set; }
    public string? BranchStatus { get; set; }
    public Address? BranchAddress { get; set; }
    public int HeadCount { get; set; }
}
