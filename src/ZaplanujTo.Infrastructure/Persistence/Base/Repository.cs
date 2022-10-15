using Domain.Interfaces;
using ZaplanujTo.Application.Common.Persistence.Base;

namespace ZaplanujTo.Infrastructure.Persistence.Base;

// ToDo
virtual class Repository<TEntity, TContext> : IRepository<TEntity> 
    where TEntity : class, IEntity
    where TContext : MongoDbContext
{
    protected readonly TContext Context;

    public Repository(TContext context)
    {
        Context = context;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        CancellationToken cancellationToken = default) => await Context.Set<TEntity>().ToListAsync();

    public async Task<TEntity> GetByIdAsync(
        string id,
        CancellationToken cancellationToken = default) => await Context.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> IsExistAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);
        return entity is null ? false : true;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await Context.Set<TEntity>().FindAsync(id);
        if (entity == null)
            return false;

        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();

        return true;
    }
}
