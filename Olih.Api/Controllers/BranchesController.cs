using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Interfaces;
using Olih.Domain.Request.Branch;
using Olih.Domain.Response.Branch;

namespace Olih.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BranchesController(IBranchService branchService, ILogger<BranchesController> logger) : ControllerBase
    {
        private readonly IBranchService _branchService = branchService;
        private readonly ILogger<BranchesController> _logger = logger;

        [HttpGet]
        [ProducesResponseType<PagedList<BranchDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public Results<Ok<PagedList<BranchDto>>, BadRequest<string>, NotFound> RetriveListBranch(string? searchText, string? sortByColumn, bool isDesc, int? pageNumber, int? pageSize)
        {
            if(pageNumber <0 || pageSize <= 0)
            {
                return TypedResults.BadRequest("wrong input prarameter test");
            }
            PagedList<BranchDto> queryResult = _branchService.GetList(new GetListBranchRequestModel
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
        [ProducesResponseType<GetOneBranchResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public Results<Ok<GetOneBranchResponseModel>, BadRequest<string>, NotFound> RetriveOneBranch([Required] string id)
        {
            if (id.Length != 3)
            {
                return TypedResults.BadRequest("branch id length must be 3");
            }
            GetOneBranchResponseModel queryResult = _branchService.GetOne(new GetOneBranchRequestModel
            {
                BranchId = id
            });


            if (queryResult == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(queryResult);
        }

        [HttpPost]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status201Created)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<Created<CreateBranchResponseModel>, BadRequest<string>> CreateBranch([Required] string branchId, [Required] string branchName)
        {
            if (branchId.Length != 3)
            {
                return TypedResults.BadRequest("branch id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(branchName))
            {
                return TypedResults.BadRequest("branch name must not empty or whitespace");
            }
            CreateBranchResponseModel creationResult = _branchService.Create(new CreateBranchRequestModel
            {
                BranchId = branchId,
                BranchName = branchName
            });
            var uri = Url.Action(nameof(RetriveOneBranch), new { id = creationResult.BranchId });

            return TypedResults.Created(branchId, creationResult);
        }

        [HttpPut]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<NoContent,BadRequest<string>> UpdateBranch([Required] string branchId, [Required] string branchName)
        {
            if (branchId.Length != 3)
            {
                return TypedResults.BadRequest("branch id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(branchName))
            {
                return TypedResults.BadRequest("branch name not valid");
            }
            _branchService.Update(new UpdateBranchRequestModel
            {
                BranchId = branchId,
                BranchName = branchName
            });

            return TypedResults.NoContent();
        }

        [HttpDelete]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<string>(StatusCodes.Status400BadRequest)]
        public Results<NoContent, BadRequest<string>> DeleteBranch([Required] string branchId)
        {
            if (branchId.Length != 3)
            {
                return TypedResults.BadRequest("branch id length must be 3");
            }
            _branchService.Delete(new DeleteBranchRequestModel
            {
                BranchId = branchId
            });

            return TypedResults.NoContent();
        }
    }
}
