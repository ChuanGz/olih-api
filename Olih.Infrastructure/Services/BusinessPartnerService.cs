using System.Linq.Expressions;
using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Interfaces;
using Olih.Domain.Request.BusinessPartner;
using Olih.Domain.Response.BusinessPartner;
using Olih.MockupData.Memory;

namespace Olih.Infrastructure.Services;

public class BusinessPartnerService : IBusinessPartnerService
{
    public CreateBusinessPartnerResponseModel Create(CreateBusinessPartnerRequestModel requestModel)
    {
        var created = BusinessPartnerMockSvc.CreateBusinessPartner(
            requestModel.CardCode,
            requestModel.CardName
        );
        return new CreateBusinessPartnerResponseModel
        {
            CardCode = created.CardCode,
            CardName = created.CardName,
            CardNumber = created.CardNumber,
        };
    }

    public void Delete(DeleteBusinessPartnerRequestModel requestModel)
    {
        BusinessPartnerMockSvc.DeleteBusinessPartner(requestModel.CardCode);
    }

    public PagedList<BusinessPartnerDto> GetList(GetListBusinessPartnerRequestModel requestModel)
    {
        var bPQuery = BusinessPartnerMockSvc.GetAllBusinessPartner().AsQueryable();
        // step 1, search by text
        if (!string.IsNullOrWhiteSpace(requestModel.SearchText))
        {
            bPQuery = bPQuery.Where(
                x =>
                    x.CardCode.Contains(requestModel.SearchText)
                    || x.CardName.Contains(requestModel.SearchText)
                    || x.CardNumber.Contains(requestModel.SearchText)
            );
        }

        // step 2, shape the order result
        if (requestModel.IsDesc)
        {
            bPQuery = bPQuery.OrderByDescending(GetSortProperty(requestModel.SortByColumn));
        }
        else
        {
            bPQuery = bPQuery.OrderBy(GetSortProperty(requestModel.SortByColumn));
        }

        return PagedList<BusinessPartnerDto>.Create(
            bPQuery,
            requestModel.PageNumber,
            requestModel.PageSize
        );
    }

    private Expression<Func<BusinessPartnerDto, object>> GetSortProperty(string? sortByColumn) =>
        sortByColumn?.ToLower() switch
        {
            "card_code" => bP => bP.CardCode,
            "card_name" => bP => bP.CardName,
            "card_number" => bP => bP.CardNumber,
            _ => bP => bP.CardCode,
        };

    public GetOneBusinessPartnerResponseModel GetOne(GetOneBusinessPartnerRequestModel requestModel)
    {
        return new GetOneBusinessPartnerResponseModel
        {
            BusinessPartner = BusinessPartnerMockSvc.GetOneBusinessPartner(requestModel.CardCode)
        };
    }

    public void Update(UpdateBusinessPartnerRequestModel requestModel)
    {
        BusinessPartnerMockSvc.UpdateBusinessPartner(
            requestModel.CardCode,
            requestModel.CardName,
            requestModel.CardNumber
        );
    }
}
