using Olih.Common;

namespace Olih.Domain.Entities;

public class BusinessPlace : BaseEntity
{
    public required string BranchName { get; set; }
    public string? BranchStatus { get; set; }
    public Address? BranchAddress { get; set; }
    public int HeadCount { get; set; }
}
