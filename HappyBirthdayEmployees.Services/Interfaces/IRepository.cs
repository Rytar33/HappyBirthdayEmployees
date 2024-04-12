using HappyBirthdayEmployees.Models;

namespace HappyBirthdayEmployees.Services.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAll();

    Task<TEntity> Get(Guid id); 

    Task Add(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(TEntity entity);
}
