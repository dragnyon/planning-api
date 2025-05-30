﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;
//TEntity child of BaseEntity
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly PlanningDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected BaseRepository(PlanningDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> Get(Guid id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IList<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync();
    }
    
    public async Task Create(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Delete(Guid id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        if (entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}