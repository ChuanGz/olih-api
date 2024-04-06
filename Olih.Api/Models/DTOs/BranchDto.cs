using System;

namespace Olih.Api.Models.DTOs
{
    public record BranchDto
    {
        public required string BranchId { get; set; }
        public required string BranchName { get; set; }
    }
}
