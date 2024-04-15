using Olih.Domain.Request.BusinessPartner;
using Olih.Infrastructure.Services;

namespace Olih.XUnit;

public class BusinessPartnerService_Test
{
    private BusinessPartnerService businessPartnerService = new BusinessPartnerService();

    [Fact]
    public void Test_GetList()
    {
        var listed = businessPartnerService.GetList(new GetListBusinessPartnerRequestModel{
            PageNumber = 0,
            PageSize = 20
        });

        Assert.Equal(20, listed.Items.Count);
    }

    [Fact]
    public void Test_GetOne()
    {
        var getOneNull = businessPartnerService.GetOne(new GetOneBusinessPartnerRequestModel{
            CardCode = "NotFoundtest"
        });

        Assert.Null(getOneNull);

        var getOneNotNull = businessPartnerService.GetOne(new GetOneBusinessPartnerRequestModel{
            CardCode = "BP_001"
        });

        Assert.NotNull(getOneNotNull);
        Assert.NotNull(getOneNotNull.BusinessPartner);
        Assert.NotNull(getOneNotNull.BusinessPartner.CardCode);
        Assert.NotNull(getOneNotNull.BusinessPartner.CardName);
    }

    [Fact]
    public void Test_Create()
    {
        var created = businessPartnerService.Create(new  CreateBusinessPartnerRequestModel{
            CardCode = "BP_999",
            CardName = "Unit Test 01"
        });

        Assert.NotNull(created.CardCode);
        Assert.NotNull(created.CardName);
    }

    [Fact]
    public void Test_Update()
    {
         var created = businessPartnerService.Create(new  CreateBusinessPartnerRequestModel{
            CardCode = "BP_992",
            CardName = "New Name"
        });

        Assert.NotNull(created.CardCode);
        Assert.NotNull(created.CardName);

        string newCardName = "Updated";
        businessPartnerService.Update(new UpdateBusinessPartnerRequestModel{
            CardCode = "BP_992",
            CardName = newCardName,
            CardNumber = "111"
        });
        var reQuery = businessPartnerService.GetOne(new GetOneBusinessPartnerRequestModel{CardCode = "BP_992"}) ;   
        Assert.NotNull(reQuery.BusinessPartner);
        Assert.Equal(reQuery.BusinessPartner.CardName, newCardName);
    }
    [Fact]
    public void Test_Delete()
    {
       businessPartnerService.Delete(new DeleteBusinessPartnerRequestModel{CardCode ="BPL_001"});

        var reQuery = businessPartnerService.GetOne(new GetOneBusinessPartnerRequestModel{CardCode = "BPL_001"}) ;   
        Assert.Null(reQuery.BusinessPartner);
    }
}   