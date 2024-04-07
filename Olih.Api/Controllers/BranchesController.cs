using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<GetOneBranchResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RetriveListBranchAsync(int? pageIndex, int? pageSize)
        {

            GetListBranchResponseModel queryResult = await _branchService.GetListAsync(new GetListBranchRequestModel
            {
                PageIndex = pageIndex ?? 1,
                PageSize = pageSize ?? 20
            });

            if(queryResult == null || queryResult.Branches.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(queryResult);
        } 

        [HttpGet]
        [Route("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType<GetOneBranchResponseModel>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RetriveOneBranchAsync([Required] string id)
        {
             if(id.Length>=2)
            {
                 return BadRequest();
            }
            GetOneBranchResponseModel queryResult = await _branchService.GetOneAsync(new GetOneBranchRequestModel
            {
                BranchId = id
            });

           
            if(queryResult == null)
            {
                return NotFound();
            }
            
            return Ok(queryResult);
        } 

    }
}
