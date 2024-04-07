using System;
using Olih.Api.Models.DTOs;

namespace Olih.Api.Models.Response
{
    public class GetOneBranchResponseModel
    {
        public required BranchDto Branch { get; set; }
    }
}
