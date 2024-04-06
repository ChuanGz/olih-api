using System;

namespace Olih.Api.Models.Request
{
    public record GetOneBranchRequestModel
    {
        public required int BranchId { get; init; }
    }
}
