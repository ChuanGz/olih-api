using System;
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
        public async Task<ActionResult<GetListBranchResponseModel>> ListBranchAsync(GetListBranchRequestModel requestModel)
        {
            var queryResult = await _branchService.GetListAsync(requestModel);

            if(queryResult == null || queryResult.Branches.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(queryResult);
        } 
    }
}
