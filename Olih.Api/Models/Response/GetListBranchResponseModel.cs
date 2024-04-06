using System;
using Olih.Api.Models.DTOs;

namespace Olih.Api.Models.Response
{
    public record GetListBranchResponseModel : PaginationBasedResponseModel
    {
        public required List<BranchDto> Branches { get; init; }
    }
}
