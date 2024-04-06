using Olih.Api.Models.Request;
using Olih.Api.Models.Response;

namespace Olih.Api.Business.Interfaces;

public interface IBranchService
{
    Task<GetListBranchResponseModel> GetListAsync(GetListBranchRequestModel requestModel);
}
