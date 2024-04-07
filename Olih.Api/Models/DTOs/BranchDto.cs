using System;

namespace Olih.Api.Models.DTOs
{
    public class BranchDto(string branchId, string branchName)
    {
        public string BranchId { get; set; } = branchId;
        public string BranchName { get; set; } = branchName;
    }
}
