using System;
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
        public async Task<ActionResult<GetListBranchResponseModel>> ListBranchAsync(int? pageIndex, int? pageSize)
        {

            GetListBranchResponseModel queryResult = await _branchService.GetListAsync(new GetListBranchRequestModel{
                PageIndex = pageIndex ?? 1,
                PageSize = pageSize ?? 20
            });

            if(queryResult == null || queryResult.Branches.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(queryResult);
        } 

        [HttpGet("/{id}")]
        public async Task<ActionResult<GetOneBranchResponseModel>> ListBranchAsync([Required] int id)
        {
            GetOneBranchResponseModel queryResult = await _branchService.GetOneAsync(new GetOneBranchRequestModel{
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
