using Olih.Common;
using Olih.Domain.DTOs;
using Olih.Domain.Request.ItemMasterData;
using Olih.Domain.Response.ItemMasterData;

namespace Olih.Domain.Interfaces;

public interface IItemMasterDataService
{
    CreateItemMasterDataResponseModel Create(CreateItemMasterDataRequestModel requestModel);
    void Delete(DeleteItemMasterDataRequestModel requestModel);
    PagedList<ItemMasterDataDto> GetList(GetListItemMasterDataRequestModel requestModel);
    GetOneItemMasterDataResponseModel GetOne(GetOneItemMasterDataRequestModel requestModel);
    void Update(UpdateItemMasterDataRequestModel requestModel);
}
