using Olih.Domain.Request.Branch;
using Olih.Infrastructure.Services;

namespace Olih.XUnit;

public class BranchService_Test
{
    private BranchService branchService = new BranchService();

    [Fact]
    public void Test_GetList()
    {
        var listed = branchService.GetList(new GetListBranchRequestModel{
            PageNumber = 0,
            PageSize = 20
        });

        Assert.Equal(20, listed.Items.Count);
    }

    [Fact]
    public void Test_GetOne()
    {
        var getOne = branchService.GetOne(new GetOneBranchRequestModel{
            BranchId = "BPL_001"
        });

        Assert.NotNull(getOne.Branch.BranchName);
        Assert.NotNull(getOne.Branch.BranchStatus);
    }

    [Fact]
    public void Test_Create()
    {
        var created = branchService.Create(new  CreateBranchRequestModel{
            BranchId = "BPL_999",
            BranchName = "Unit Test Branch Name"
        });

        Assert.NotNull(created.BranchId);
        Assert.NotNull(created.BranchName);
    }
    [Fact]
    public void Test_Update()
    {
        string newBranchName = "Unit test updated BranchName";
        branchService.Update(new UpdateBranchRequestModel{
            BranchId = "BPL_002",
            BranchName = newBranchName
        });
        var againList = branchService.GetOne(new GetOneBranchRequestModel{BranchId = "BPL_002"}) ;   
        Assert.NotNull(againList.Branch);
        Assert.Equal(againList.Branch.BranchName, newBranchName);
    }
    [Fact]
    public void Test_Delete()
    {
       branchService.Delete(new DeleteBranchRequestModel{BranchId ="BPL_001"});

        var againList = branchService.GetOne(new GetOneBranchRequestModel{BranchId = "BPL_002"}) ;   
        Assert.Null(againList.Branch);
    }
}   