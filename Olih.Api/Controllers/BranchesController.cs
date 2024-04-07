using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Olih.Api.Business.Interfaces;
using Olih.Api.Models.Request;
using Olih.Api.Models.Response;

namespace Olih.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BranchesController(IBranchService branchService, ILogger<BranchesController> logger) : ControllerBase
    {
        private readonly IBranchService _branchService = branchService;
        private readonly ILogger<BranchesController> _logger = logger;

        [HttpGet]
        [ProducesResponseType<GetOneBranchResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetriveListBranch(int? pageIndex, int? pageSize)
        {

            GetListBranchResponseModel queryResult = _branchService.GetList(new GetListBranchRequestModel
            {
                PageIndex = pageIndex ?? 0,
                PageSize = pageSize ?? 10
            });

            if (queryResult == null || queryResult.Branches.Count == 0)
            {
                return NotFound();
            }

            return Ok(queryResult);
        }

        [HttpGet("{id}")]
        [ProducesResponseType<GetOneBranchResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RetriveOneBranch([Required] string id)
        {
            if (id.Length != 3)
            {
                return BadRequest("branch id length must be 3");
            }
            GetOneBranchResponseModel queryResult = _branchService.GetOne(new GetOneBranchRequestModel
            {
                BranchId = id
            });


            if (queryResult == null)
            {
                return NotFound();
            }

            return Ok(queryResult);
        }

        [HttpPost]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateBranch([Required] string branchId, [Required] string branchName)
        {
            if (branchId.Length != 3)
            {
                return BadRequest("branch id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(branchName))
            {
                return BadRequest("branch name not valid");
            }
            CreateBranchResponseModel creationResult = _branchService.Create(new CreateBranchRequestModel
            {
                BranchId = branchId,
                BranchName = branchName
            });
            var uri = Url.Action(nameof(RetriveOneBranch), new { id = creationResult.BranchId });

            return Created(branchId, creationResult);
        }

        [HttpPut]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBranch([Required] string branchId, [Required] string branchName)
        {
            if (branchId.Length != 3)
            {
                return BadRequest("branch id length must be 3");
            }
            if (string.IsNullOrWhiteSpace(branchName))
            {
                return BadRequest("branch name not valid");
            }
            _branchService.Update(new UpdateBranchRequestModel
            {
                BranchId = branchId,
                BranchName = branchName
            });

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType<CreateBranchResponseModel>(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteBranch([Required] string branchId)
        {
            if (branchId.Length != 3)
            {
                return BadRequest("branch id length must be 3");
            }
            _branchService.Delete(new DeleteBranchRequestModel
            {
                BranchId = branchId
            });

            return NoContent();
        }
    }
}
