namespace ZaplanujTo.Application.Common.Persistence.Base;

public interface IRepository<TEntity>
{
    // ToDo
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    // ToDo
    // x => x.UserName == "Mateusz"
    // _repo.GetByPredicate(x => x.Hobby == "Lol")
    // Func
    // x => x.Homework.Flag == false

    Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> IsExistAsync(string id, CancellationToken cancellationToken = default);
}