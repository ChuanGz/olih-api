using Olih.Api.Models.DTOs;

namespace Olih.Api.Businesses.Factories;

public static class BranchServiceFactory
{
    private static readonly List<BranchDto> value = [
            new ("A01", "Branch A01"),
            new ("A02", "Branch A02"),
            new ("A03", "Branch A03"),
            new ("A04", "Branch A04"),
            new ("A05", "Branch A05"),
            new ("B01", "Branch B01"),
            new ("B02", "Branch B02"),
            new ("B03", "Branch B03"),
            new ("B04", "Branch B04"),
            new ("B05", "Branch B05"),
            new ("C01", "Branch C01"),
            new ("C02", "Branch C02"),
            new ("C03", "Branch C03"),
            new ("C04", "Branch C04"),
            new ("C05", "Branch C05"),
            new ("D01", "Branch D01"),
            new ("D02", "Branch D02"),
            new ("D03", "Branch D03"),
            new ("D04", "Branch D04"),
            new ("D05", "Branch D05"),
    ];
    private static readonly List<BranchDto> _branches =
    value;

    public static List<BranchDto> GetListBranch(int skip, int take)
    {
        return _branches.Skip(skip).Take(take).ToList();
    }

    public static BranchDto? GetOneBranch(string branchId)
    {
        return _branches.SingleOrDefault(x => x.BranchId == branchId);
    }

    public static BranchDto CreateBranch(string branchId, string branchName)
    {
        _branches.Add(new(branchId, branchName));
        return _branches.Single(x => x.BranchId == branchId);
    }

    public static void UpdateBranch(string branchId, string newbranchName)
    {
        var existed = _branches.Single(x => x.BranchId == branchId);
        existed.BranchName = newbranchName;
    }
    public static void DeleteBranch(string branchId)
    {
        var existed = _branches.SingleOrDefault(x => x.BranchId == branchId);
        _branches.RemoveAll(x => x.BranchId == branchId);
    }
}
