using Olih.Common;
using Olih.Domain.Entities;
using Olih.Domain.Interfaces.Repositories;

public class ProductRepository(ProductRepository repository) : BaseGenericOperation<string, Product, ProductRepository>(repository), IProductRepository
{
}