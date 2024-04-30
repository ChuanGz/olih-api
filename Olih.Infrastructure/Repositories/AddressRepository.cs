using Olih.Common;
using Olih.Domain.Entities;
using Olih.Domain.Interfaces.Repositories;

public class AddressRepository(AddressRepository repository) : BaseGenericOperation<string, Address, AddressRepository>(repository), IAddressRepository
{
}