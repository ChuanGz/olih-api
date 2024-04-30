using Olih.Common;
using Olih.Domain.Entities;
using Olih.Domain.Interfaces.Repositories;

public class BusinessPartnerRepository(BusinessPartnerRepository repository) : BaseGenericOperation<string, BusinessPartner, BusinessPartnerRepository>(repository), IBusinessPartnerRepository
{
}