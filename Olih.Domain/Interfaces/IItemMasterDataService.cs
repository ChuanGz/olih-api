using Olih.Common;

namespace Olih.Domain.Interfaces;

public interface IItemMasterDataService
{
    CreateItemMasterDataResponseModel Create(CreateItemMasterDataRequestModel requestModel);
    void Delete(DeleteItemMasterDataRequestModel requestModel);
    PagedList<ItemMasterDataDto> GetList(GetListItemMasterDataRequestModel requestModel);
    GetOneItemMasterDataResponseModel GetOne(GetOneItemMasterDataRequestModel requestModel);
    void Update(UpdateItemMasterDataRequestModel requestModel);
}

public class UpdateItemMasterDataRequestModel { }

public class GetOneItemMasterDataRequestModel { }

public class GetOneItemMasterDataResponseModel { }

public class GetListItemMasterDataRequestModel { }

public class ItemMasterDataDto { }

public class DeleteItemMasterDataRequestModel { }

public class CreateItemMasterDataRequestModel { }

public class CreateItemMasterDataResponseModel { }
