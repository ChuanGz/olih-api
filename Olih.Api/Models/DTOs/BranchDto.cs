using System;

namespace Olih.Api.Models.DTOs
{
    public class BranchDto(string branchId, string branchName)
    {
        public string BranchId { get; set; } = branchId;
        public string BranchName { get; set; } = branchName;
        public string BranchStatus { get; set; } = "A";
        public string BranchAdress { get; set; } = "test default address";
        public int HeadCount { get; set; } = (new Random()).Next(1000, 9999);
    }
}
