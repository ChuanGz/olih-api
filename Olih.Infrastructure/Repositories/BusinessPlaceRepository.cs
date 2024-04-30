using Olih.Common;
using Olih.Domain.Entities;
using Olih.Domain.Interfaces.Repositories;

public class BusinessPlaceRepository(BusinessPlaceRepository repository) : BaseGenericOperation<string, BusinessPlace, BusinessPlaceRepository>(repository), IBusinessPlaceRepository
{
}