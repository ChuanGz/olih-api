using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Request.Branch;
using Olih.Domain.Response.Branch;

namespace Olih.Domain.Interfaces.Services;

public interface IBranchService
{
    CreateBranchResponseModel Create(CreateBranchRequestModel requestModel);
    void Delete(DeleteBranchRequestModel requestModel);
    PagedList<BranchDto> GetList(GetListBranchRequestModel requestModel);
    GetOneBranchResponseModel GetOne(GetOneBranchRequestModel requestModel);
    void Update(UpdateBranchRequestModel requestModel);
}
