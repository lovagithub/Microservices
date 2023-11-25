using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Shared.Cenerics;

public abstract class Repository<TEntity, DbConext>(DbConext context) where TEntity : class where DbConext : DbContext
{
    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        try
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null! ;
    }
    public virtual async Task<IEnumerable<TEntity>> GetAsync()
    {
        try
        {
            var entities = await context.Set<TEntity>().ToListAsync();
            return entities;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return entity ?? null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        try
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = await GetAsync(expression);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
           
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
           return await context.Set<TEntity>().AnyAsync(expression);
           
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}

