using Olih.Domain.DTOs;

namespace Olih.MockupData.Memory;

public static class BranchMockSvc
{
    public static void GenerateSampleBranches(int count)
    {
        List<BranchDto> branches = new List<BranchDto>();

        for (int i = 1; i <= count; i++)
        {
            BranchDto branch = new BranchDto
            {
                BranchId = $"BPL_{i.ToString("000")}",
                BranchName = $"Simple Branch Name {i}",
                BranchStatus = "Active",
                BranchAddress =  new AddressDto { StreetNo = $"Street {i}", Ward = $"Ward {i}", District = $"District {i}", City = $"City {i}", Country = $"Country {i}" },
                HeadCount = (10000%i+1000)*2
            };
            branches.Add(branch);
        }
        _branches = branches;
    }
    public static List<BranchDto> GetAllBranches()
    {
        GenerateSampleBranches(100);
        return _branches!;
    }

    public static BranchDto? GetOneBranch(string branchId)
    {
        return _branches!.SingleOrDefault(x => x.BranchId == branchId);
    }

    public static BranchDto CreateBranch(string branchId, string branchName)
    {
        int i = 2000;
        var branch = new BranchDto
            {
                BranchId = branchId,
                BranchName = branchName,
                BranchStatus = "Active",
                BranchAddress =  new AddressDto { StreetNo = $"Street {i}", Ward = $"Ward {i}", District = $"{i}", City = $"City {i}", Country = "Country" },
                HeadCount = (10000%i+1000)*2
            };
        _branches!.Add(branch);
        return _branches.Single(x => x.BranchId == branchId);
    }

    public static void UpdateBranch(string branchId, string newbranchName)
    {
        var existed = _branches!.Single(x => x.BranchId == branchId);
        existed.BranchName = newbranchName;
    }
    public static void DeleteBranch(string branchId)
    {
        var existed = _branches!.SingleOrDefault(x => x.BranchId == branchId);
        _branches!.RemoveAll(x => x.BranchId == branchId);
    }

    private static List<BranchDto>? _branches;
}
