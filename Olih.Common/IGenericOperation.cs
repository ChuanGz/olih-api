namespace Olih.Common;

public interface IGenericOperation<TKey, TModel> where TModel : BaseEntity
{
    Task<IEnumerable<TModel>> ListAsync();

    Task<TModel> GetAsync(TKey key);

    Task<TModel> AddAsync(TModel model);

    Task<IEnumerable<TModel>> AddAsync(IEnumerable<TModel> models);

    Task<TModel> UpdateAsync(TKey key, TModel model);

    Task<IEnumerable<TModel>> UpdateAsync(IDictionary<TKey, TModel> models);

    Task DeleteAsync(TKey key);
}