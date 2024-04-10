using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Request.BusinessPartner;
using Olih.Domain.Response.BusinessPartner;

namespace Olih.Domain.Interfaces;

public interface IBusinessPartnerService
{
    CreateBusinessPartnerResponseModel Create(CreateBusinessPartnerRequestModel requestModel);
    void Delete(DeleteBusinessPartnerRequestModel requestModel);
    PagedList<BusinessPartnerDto> GetList(GetListBusinessPartnerRequestModel requestModel);
    GetOneBusinessPartnerResponseModel GetOne(GetOneBusinessPartnerRequestModel requestModel);
    void Update(UpdateBusinessPartnerRequestModel requestModel);
}
