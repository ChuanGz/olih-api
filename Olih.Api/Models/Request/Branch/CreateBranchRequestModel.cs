namespace Olih.Api.Models.Request;

public class CreateBranchRequestModel
{
    public required string BranchId { get; set; }
    public required string BranchName { get; set; }
}
