using Olih.Api.Business.Interfaces;
using Olih.Api.Models.Request;
using Olih.Api.Models.Response;
using Olih.Api.Businesses.Factories;

namespace Olih.Api.Businesses.Services;

public class BranchService : IBranchService
{
    public CreateBranchResponseModel Create(CreateBranchRequestModel requestModel)
    {
        var created = BranchServiceFactory.CreateBranch(
            requestModel.BranchId,
            requestModel.BranchName
        );
        return new CreateBranchResponseModel
        {
            BranchId = created.BranchId,
            BranchName = created.BranchName,
        };
    }

    public void Delete(DeleteBranchRequestModel requestModel)
    {
        BranchServiceFactory.DeleteBranch(requestModel.BranchId);
    }

    public GetListBranchResponseModel GetList(GetListBranchRequestModel requestModel)
    {
        return new GetListBranchResponseModel
        {
            Branches = BranchServiceFactory.GetListBranch(
                requestModel.PageSize * requestModel.PageNumber,
                requestModel.PageSize
            )
        };
    }

    public GetOneBranchResponseModel GetOne(GetOneBranchRequestModel requestModel)
    {
        return new GetOneBranchResponseModel
        {
            Branch = BranchServiceFactory.GetOneBranch(requestModel.BranchId)
        };
    }

    public void Update(UpdateBranchRequestModel requestModel)
    {
        BranchServiceFactory.UpdateBranch(requestModel.BranchId, requestModel.BranchName);
    }
}
