using Olih.Api.Business.Interfaces;
using Olih.Api.Models.DTOs;
using Olih.Api.Models.Request;
using Olih.Api.Models.Response;

namespace Olih.Api.Businesses.Services;

public class BranchService : IBranchService
{
    private List<BranchDto> _branches = new List<BranchDto>();

    public BranchService()
    {
        _branches.Add(new BranchDto("A", "Branch A"));
        _branches.Add(new BranchDto("B", "Branch B"));
        _branches.Add(new BranchDto("C", "Branch C"));
        _branches.Add(new BranchDto("D", "Branch D"));
    }

    public async Task<GetListBranchResponseModel> GetListAsync(
        GetListBranchRequestModel requestModel
    )
    {
        return await Task.FromResult(
            new GetListBranchResponseModel
            {
                Branches = _branches,
                PageCount = 1,
                PageTotal = 1,
                PageIndex = 1,
                PageSize = 10,
            }
        );
    }

    public async Task<GetOneBranchResponseModel> GetOneAsync(
        GetOneBranchRequestModel getOneBranchRequestModel
    )
    {
        return await Task.FromResult(
            new GetOneBranchResponseModel
            {
                Branch = _branches.Single(b => b.BranchId == getOneBranchRequestModel.BranchId)
            }
        );
    }
}
