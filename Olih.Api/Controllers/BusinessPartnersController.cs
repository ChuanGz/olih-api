using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Interfaces;
using Olih.Domain.Request.BusinessPartner;
using Olih.Domain.Response.BusinessPartner;

namespace Olih.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BusinessPartnersController (IBusinessPartnerService businessPartnerService, ILogger<BusinessPartnersController> logger) : ControllerBase
     { 
         private readonly IBusinessPartnerService _businessPartnerService = businessPartnerService;
        private readonly ILogger<BusinessPartnersController> _logger = logger;
        
        [HttpGet]
        [ProducesResponseType<PagedList<BusinessPartnerDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public Results<Ok<PagedList<BusinessPartnerDto>>, BadRequest<string>, NotFound> RetriveListBusinessPartner(string? searchText, string? sortByColumn, bool isDesc, int? pageNumber, int? pageSize)
        {
            if(pageNumber <0 || pageSize <= 0)
            {
                return TypedResults.BadRequest("wrong input prarameter test");
            }
            PagedList<BusinessPartnerDto> queryResult = _businessPartnerService.GetList(new GetListBusinessPartnerRequestModel
            {
                SearchText = searchText,
                SortByColumn = sortByColumn,
                IsDesc = isDesc,
                PageNumber = pageNumber ?? 0,
                PageSize = pageSize ?? 10
            });
            if (queryResult == null || queryResult.Items.Count == 0)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(queryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<GetOneBusinessPartnerResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public Results<Ok<GetOneBusinessPartnerResponseModel>, BadRequest<string>, NotFound> RetriveOneBusinessPartner([Required] string id)
        {
            if (id.Length != 3)
            {
                return TypedResults.BadRequest("BusinessPartner id length must be 3");
            }
            GetOneBusinessPartnerResponseModel queryResult = _businessPartnerService.GetOne(new GetOneBusinessPartnerRequestModel
            {
  
            });


            if (queryResult == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(queryResult);
        }

        [HttpPost]
        [ProducesResponseType<CreateBusinessPartnerResponseModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<Created<CreateBusinessPartnerResponseModel>, BadRequest<string>> CreateBusinessPartner([Required] string BusinessPartnerId, [Required] string BusinessPartnerName)
        {
            if (BusinessPartnerId.Length != 3)
            {
                return TypedResults.BadRequest("BusinessPartner id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(BusinessPartnerName))
            {
                return TypedResults.BadRequest("BusinessPartner name must not empty or whitespace");
            }
            CreateBusinessPartnerResponseModel creationResult = _businessPartnerService.Create(new CreateBusinessPartnerRequestModel
            {

            });
            var uri = Url.Action(nameof(RetriveOneBusinessPartner), new { id = creationResult.ToString() });

            return TypedResults.Created(BusinessPartnerId, creationResult);
        }

        [HttpPut]
        [ProducesResponseType<CreateBusinessPartnerResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<NoContent,BadRequest<string>> UpdateBusinessPartner([Required] string BusinessPartnerId, [Required] string BusinessPartnerName)
        {
            if (BusinessPartnerId.Length != 3)
            {
                return TypedResults.BadRequest("BusinessPartner id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(BusinessPartnerName))
            {
                return TypedResults.BadRequest("BusinessPartner name not valid");
            }
            _businessPartnerService.Update(new UpdateBusinessPartnerRequestModel
            {
            });

            return TypedResults.NoContent();
        }

        [HttpDelete]
        [ProducesResponseType<CreateBusinessPartnerResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<NoContent, BadRequest<string>> DeleteBusinessPartner([Required] string BusinessPartnerId)
        {
            if (BusinessPartnerId.Length != 3)
            {
                return TypedResults.BadRequest("BusinessPartner id length must be 3");
            }
            _businessPartnerService.Delete(new DeleteBusinessPartnerRequestModel
            {
                
            });

            return TypedResults.NoContent();
        }
    }
}
