namespace Olih.Api.Models.Request;

public class UpdateBranchRequestModel
{
    public required string BranchId { get; set; }
    public required string BranchName { get; set; }
}
