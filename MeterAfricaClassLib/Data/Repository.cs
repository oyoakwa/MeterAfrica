using MeterAfricaClassLib.Data;
using MeterAfricaClassLib.Data.AbstractClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<List<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int? skip = null, int? take = null, bool IncludeDeleted = false);

    Task<List<TEntity>> GetAllAsync(bool IncludeDeleted = false);

    Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int? skip = null, int? take = null, bool IncludeDeleted = false);

    Task<TEntity> GetOneAsync(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null);

    Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null);

    Task<TEntity> GetLastAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, bool asNoTracking = false);

    Pagination<TEntity> GetPaginated(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int skip = 1, int take = 10, bool IncludeDeleted = false);

    Task<TEntity> GetByIdAsync(Guid id);

    TEntity GetById(Guid id);

    Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

    Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null);

    void Create(TEntity entity, string createdBy = null);

    void Update(TEntity entity, string modifiedBy = null);

    bool Delete(Guid id, string deletedBy = null);

    Task SaveAsync();
    void Save();
    IQueryable<TEntity> GetQueryable(bool IncludeDeleted = false);
}
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly IUnitOfWork _unitOfWork;

    public Repository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Base Query

    protected virtual IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int? skip = 1, int? take = 10,
        bool IncludeDeleted = false, bool AsNoTracking = true)
    {
        orderBy ??= (x => x.OrderBy(o => o.CreatedDate));
        includeProperties ??= string.Empty;
        IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>();
        if (!IncludeDeleted) query = query.Where(x => !x.IsDeleted);
        if (filter != null) query = query.Where(filter);
        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (orderBy != null) query = orderBy(query);
        if (skip.HasValue) query = query.Skip((skip.Value - 1) * take.Value).Take(take.Value);
        if (AsNoTracking) query = query.AsNoTracking();
        return query;
    }

    public virtual IQueryable<TEntity> GetQueryable(bool IncludeDeleted = false)
    {
        IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>();
        if (!IncludeDeleted) query = query.AsNoTracking().Where(x => !x.IsDeleted);
        return query;
    }

    protected virtual Pagination<TEntity> GetPaginatedQueryable(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int skip = 1, int take = 10, bool IncludeDeleted = false)
    {
        orderBy ??= (x => x.OrderBy(o => o.CreatedDate));
        includeProperties ??= string.Empty;
        IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>().AsNoTracking();
        if (!IncludeDeleted) query = query.Where(x => !x.IsDeleted);
        if (filter != null) query = query.Where(filter);

        int Count = query.Count();
        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (orderBy != null) query = orderBy(query);
        query = query.Skip((skip - 1) * take).Take(take);

        var totalPages = (int)Math.Ceiling(Count / (decimal)take);
        long itemEnd = skip * take;
        long itemStart = (itemEnd - take) + 1;
        if (itemEnd > Count)
        {
            itemEnd = Count;
        }
        var msg = string.Format("Showing {0} to {1} of {2} Records | Total Pages: {3}",
            itemStart, itemEnd, Count, totalPages);

        Pagination<TEntity> extension = new Pagination<TEntity>
        {
            Summary = Count > 0 ? msg : string.Empty,
            TotalCount = Count,
            ReturnedList = query.ToList(),
            CurrentPage = skip,
            PageCount = totalPages
        };
        return extension;
    }

    protected virtual IQueryable<TEntity> GetQueryable(
        Expression<Func<TEntity, bool>> filter = null, string includeProperties = null,
        bool IncludeDeleted = false)
    {
        IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>().AsNoTracking();
        includeProperties ??= string.Empty;
        if (!IncludeDeleted) query = query.Where(x => !x.IsDeleted);

        foreach (var includeProperty in includeProperties
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        return query;
    }

    #endregion

    public virtual async Task<List<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int? skip = null, int? take = null,
        bool IncludeDeleted = false)
    {
        return await GetQueryable(null, orderBy, includeProperties, skip, take, IncludeDeleted).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(bool IncludeDeleted = false)
    {
        return await GetQueryable(IncludeDeleted).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int? skip = null, int? take = null, bool IncludeDeleted = false)
    {
        return await GetQueryable(filter, orderBy, includeProperties, skip, take, IncludeDeleted).ToListAsync();
    }

    public virtual Pagination<TEntity> GetPaginated(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, int skip = 1, int take = 10, bool IncludeDeleted = false)
    {
        return GetPaginatedQueryable(filter, orderBy, includeProperties, skip, take, IncludeDeleted);
    }

    public virtual async Task<TEntity> GetSingleAsync(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null)
    {
        return await GetQueryable(filter, includeProperties).SingleOrDefaultAsync();
    }

    public virtual async Task<TEntity> GetOneAsync(
        Expression<Func<TEntity, bool>> filter = null,
        string includeProperties = null)
    {
        return await GetQueryable(filter, includeProperties).FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> GetFirstAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null)
    {
        return await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
    }

    public virtual async Task<TEntity> GetLastAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = null, bool asNoTracking = true)
    {
        return await GetQueryable(filter: filter, orderBy: orderBy, includeProperties: includeProperties,
            AsNoTracking: asNoTracking).LastOrDefaultAsync();
    }

    public virtual Task<TEntity> GetByIdAsync(Guid id)
    {
        return _unitOfWork.Context.Set<TEntity>()
            .AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual TEntity GetById(Guid id)
    {
        return _unitOfWork.Context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
    }

    public virtual Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        return GetQueryable(filter, null, false).CountAsync();
    }

    public virtual async Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        return await _unitOfWork.Context.Set<TEntity>().AnyAsync(filter);
    }

    public virtual void Create(TEntity entity, string createdBy = null)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.CreatedBy = createdBy;
        _unitOfWork.Context.Set<TEntity>().Add(entity);
    }

    public virtual async Task CreateMany(List<TEntity> entity)
    {
        await _unitOfWork.Context.Set<TEntity>().AddRangeAsync(entity);
    }

    public virtual void Update(TEntity entity, string modifiedBy = null)
    {
        entity.ModifiedDate = DateTime.UtcNow;
        entity.ModifiedBy = modifiedBy;
        _unitOfWork.Context.Set<TEntity>().Attach(entity);
        _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
    }

    public virtual bool Delete(Guid id, string deletedBy = null)
    {
        TEntity entity = _unitOfWork.Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        if (entity != null)
        {
            entity.Deleted = DateTime.UtcNow;
            entity.ModifiedBy = deletedBy;
            entity.IsDeleted = true;
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Commit();
            return true;
        }
        return false;
    }

    public virtual async Task SaveAsync()
    {
        await _unitOfWork.CommitAsync();
    }

    public virtual void Save()
    {
        _unitOfWork.Commit();
    }
}
