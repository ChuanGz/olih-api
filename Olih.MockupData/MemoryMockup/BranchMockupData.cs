using Olih.Domain.DTOs;

namespace Olih.MockupData.MemoryMockup;

public static class BranchMockupData
{

    public static List<BranchDto> GetAllBranches()
    {
        return _branches;
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

    private static List<BranchDto> _branches = [
            new ("A01", "Branch A01"),
            new ("A02", "Branch A02"),
            new ("A03", "Branch A03"),
            new ("A04", "Branch A04"),
            new ("A05", "Branch A05"),
            new ("A06", "Branch A06"),
            new ("A07", "Branch A07"),
            new ("A08", "Branch A08"),
            new ("A09", "Branch A09"),
            new ("A10", "Branch A10"),
            new ("A11", "Branch A11"),
            new ("A12", "Branch A12"),
            new ("A13", "Branch A13"),
            new ("A14", "Branch A14"),
            new ("A15", "Branch A15"),
            new ("A16", "Branch A16"),
            new ("A17", "Branch A17"),
            new ("A18", "Branch A18"),
            new ("A19", "Branch A19"),
            new ("A20", "Branch A20"),
            new ("B01", "Branch B01"),
            new ("B02", "Branch B02"),
            new ("B03", "Branch B03"),
            new ("B04", "Branch B04"),
            new ("B05", "Branch B05"),
            new ("B06", "Branch B06"),
            new ("B07", "Branch B07"),
            new ("B08", "Branch B08"),
            new ("B09", "Branch B09"),
            new ("B10", "Branch B10"),
            new ("B11", "Branch B11"),
            new ("B12", "Branch B12"),
            new ("B13", "Branch B13"),
            new ("B14", "Branch B14"),
            new ("B15", "Branch B15"),
            new ("B16", "Branch B16"),
            new ("B17", "Branch B17"),
            new ("B18", "Branch B18"),
            new ("B19", "Branch B19"),
            new ("B20", "Branch B20"),
            new ("C01", "Branch C01"),
            new ("C02", "Branch C02"),
            new ("C03", "Branch C03"),
            new ("C04", "Branch C04"),
            new ("C05", "Branch C05"),
            new ("C06", "Branch C06"),
            new ("C07", "Branch C07"),
            new ("C08", "Branch C08"),
            new ("C09", "Branch C09"),
            new ("C10", "Branch C10"),
            new ("C11", "Branch C11"),
            new ("C12", "Branch C12"),
            new ("C13", "Branch C13"),
            new ("C14", "Branch C14"),
            new ("C15", "Branch C15"),
            new ("C16", "Branch C16"),
            new ("C17", "Branch C17"),
            new ("C18", "Branch C18"),
            new ("C19", "Branch C19"),
            new ("C20", "Branch C20"),
            new ("D01", "Branch D01"),
            new ("D02", "Branch D02"),
            new ("D03", "Branch D03"),
            new ("D04", "Branch D04"),
            new ("D05", "Branch D05"),
            new ("D06", "Branch D06"),
            new ("D07", "Branch D07"),
            new ("D08", "Branch D08"),
            new ("D09", "Branch D09"),
            new ("D10", "Branch D10"),
            new ("D11", "Branch D11"),
            new ("D12", "Branch D12"),
            new ("D13", "Branch D13"),
            new ("D14", "Branch D14"),
            new ("D15", "Branch D15"),
            new ("D16", "Branch D16"),
            new ("D17", "Branch D17"),
            new ("D18", "Branch D18"),
            new ("D19", "Branch D19"),
            new ("D20", "Branch D20"),
            new ("E01", "Branch E01"),
            new ("E02", "Branch E02"),
            new ("E03", "Branch E03"),
            new ("E04", "Branch E04"),
            new ("E05", "Branch E05"),
            new ("E06", "Branch E06"),
            new ("E07", "Branch E07"),
            new ("E08", "Branch E08"),
            new ("E09", "Branch E09"),
            new ("E10", "Branch E10"),
            new ("E11", "Branch E11"),
            new ("E12", "Branch E12"),
            new ("E13", "Branch E13"),
            new ("E14", "Branch E14"),
            new ("E15", "Branch E15"),
            new ("E16", "Branch E16"),
            new ("E17", "Branch E17"),
            new ("E18", "Branch E18"),
            new ("E19", "Branch E19"),
            new ("E20", "Branch E20"),
    ];
}
