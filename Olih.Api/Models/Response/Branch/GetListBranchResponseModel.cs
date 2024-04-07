using System;
using Olih.Api.Models.DTOs;

namespace Olih.Api.Models.Response
{
    public class GetListBranchResponseModel : PaginationBasedResponseModel
    {
        public required List<BranchDto> Branches { get; init; }
    }
}
