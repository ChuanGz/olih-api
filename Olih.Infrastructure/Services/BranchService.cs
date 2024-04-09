using System.Linq.Expressions;
using Olih.Domain.Request.Branch;
using Olih.Domain.Response.Branch;
using Olih.Infrastructure.Factories;
using Olih.Domain.DTOs;
using Olih.Common;
using Olih.Domain.Interfaces;

namespace Olih.Infrastructure.Services;

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

    public PagedList<BranchDto> GetList(GetListBranchRequestModel requestModel)
    {
        var branchQuery = BranchServiceFactory.GetAllBranches().AsQueryable();
        // step 1, search by text
        if (!string.IsNullOrWhiteSpace(requestModel.SearchText))
        {
            branchQuery = branchQuery.Where(
                x =>
                    x.BranchId.Contains(requestModel.SearchText)
                    || x.BranchName.Contains(requestModel.SearchText)
                    || x.BranchAdress.Contains(requestModel.SearchText)
                    || x.BranchStatus.Contains(requestModel.SearchText)
            );
        }

        // step 2, shape the order result
        if (requestModel.IsDesc)
        {
            branchQuery = branchQuery.OrderByDescending(GetSortProperty(requestModel.SortByColumn));
        }
        else
        {
            branchQuery = branchQuery.OrderBy(GetSortProperty(requestModel.SortByColumn));
        }

        return PagedList<BranchDto>.Create(
            branchQuery,
            requestModel.PageNumber,
            requestModel.PageSize
        );
    }

    private Expression<Func<BranchDto, object>> GetSortProperty(string? sortByColumn) =>
        sortByColumn?.ToLower() switch
        {
            "name" => branch => branch.BranchName,
            "status" => branch => branch.BranchStatus,
            "address" => branch => branch.BranchAdress,
            "head_count" => branch => branch.HeadCount,
            _ => branch => branch.BranchId,
        };

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
