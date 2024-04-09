using Olih.Api.Models.DTOs;
using Olih.Api.Models.Request;
using Olih.Api.Models.Response;

namespace Olih.Api.Business.Interfaces;

public interface IBranchService
{
    CreateBranchResponseModel Create(CreateBranchRequestModel requestModel);
    void Delete(DeleteBranchRequestModel requestModel);
    PagedList<BranchDto> GetList(GetListBranchRequestModel requestModel);
    GetOneBranchResponseModel GetOne(GetOneBranchRequestModel requestModel);
    void Update(UpdateBranchRequestModel requestModel);
}
