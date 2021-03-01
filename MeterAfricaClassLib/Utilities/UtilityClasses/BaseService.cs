using MeterAfricaClassLib.Data;
using MeterAfricaClassLib.Data.AbstractClasses;
using MeterAfricaClassLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeterAfricaClassLib.Utilities.UtilityClasses
{

    public interface IBaseService<TEntity, TDataObject> : IBaseMapper<TEntity, TDataObject>
    {
        Task<IEnumerable<TDataObject>> GetAllAsync();

        Pagination<TEntity> GetPaginated(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
                int page = 1, int pageSize = 10);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null);

        Task<Pagination<TEntity>> GetPaginatedAsync(int page = 1, int pageSize = 10);

        Task<bool> GetExistAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TDataObject> GetByIdAsync(Guid Id);

        TDataObject Create(TDataObject model);

        Task<(bool Status, string Message, TDataObject Model)> Update(TDataObject model, Guid Id);

        bool Delete(Guid Id);

        Task SaveAsync();
    }

    class BaseService<TEntity, TDataObject> : BaseMapper<TEntity, TDataObject>,
     IBaseService<TEntity, TDataObject> where TEntity : class, IEntity
    {
        protected readonly IResponseService _responseService;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly Repository<TEntity> _repository;

        protected readonly static string _currentDateString = DateTime.Now.ToString("dd-MMMM-yyyy hh:mm:ss -tt");
        protected readonly static string _logTime = $"logged as at {_currentDateString}";

        public BaseService(IUnitOfWork unitOfWork, IResponseService responseService)
        {
            _unitOfWork = unitOfWork;
            _responseService = responseService;
            _repository = new Repository<TEntity>(unitOfWork);
        }

        public async Task<IEnumerable<TDataObject>> GetAllAsync()
        {
            List<TEntity> list = await _repository.GetAllAsync(IncludeDeleted: false);
            var dataObjects = this.MapListEntityToListModel(list);
            return dataObjects;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            List<TEntity> list = await _repository.GetAsync(filter: filter, orderBy: orderBy,
                includeProperties: includeProperties);
            return list;
        }


        public Pagination<TEntity> GetPaginated(Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null,
                int page = 1, int pageSize = 10)
        {
            var entities = _repository.GetPaginated(filter: filter,
                orderBy: orderBy, includeProperties: includeProperties,
                skip: page, take: pageSize, IncludeDeleted: false);

            return entities;
        }

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            var entity = _repository.GetFirstAsync(filter: filter, orderBy: orderBy, includeProperties: includeProperties);
            return entity;
        }

        public async Task<Pagination<TEntity>> GetPaginatedAsync(int page = 1, int pageSize = 10)
        {
            page = page < 1 ? 1 : page;
            pageSize = pageSize < 10 ? 10 : pageSize;
            int Count = await _repository.GetCountAsync();
            var entities = await _repository.GetAllAsync(skip: page, take: pageSize, IncludeDeleted: false);
            var totalPages = (int)Math.Ceiling(Count / (decimal)pageSize);

            long itemEnd = pageSize * page;
            long itemStart = itemEnd - pageSize + 1;
            if (itemEnd > Count)
            {
                itemEnd = Count;
            }

            var msg = $"Showing {itemStart} to {itemEnd} of {Count} Records | Total Pages: {totalPages}";

            Pagination<TEntity> extension = new Pagination<TEntity>
            {
                Summary = Count > 0 ? msg : string.Empty,
                TotalCount = Count,
                ReturnedList = entities,
                CurrentPage = page,
                PageCount = totalPages
            };
            return extension;
        }

        public async Task<bool> GetExistAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _repository.GetExistsAsync(filter);
        }

        public async Task<TDataObject> GetByIdAsync(Guid Id)
        {
            var entity = await _repository.GetByIdAsync(Id);
            return MapEntityToModel(entity);
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            var entity = await _repository.GetCountAsync(filter);
            return entity;
        }

        public TDataObject Create(TDataObject model)
        {
            var entity = this.MapModelToEntity(model);
            _repository.Create(entity);
            return model;
        }

        public async Task<(bool Status, string Message, TDataObject Model)> Update(TDataObject model, Guid Id)
        {
            var entity = await _repository.GetByIdAsync(id: Id);
            if (entity == null)
            {
                return (false, "Invalid request", model);
            }
            //var updateAbleEntity = this.MapModelToEntity(model);
            //updateAbleEntity.Id = Id;
            //updateAbleEntity.CreatedDate = entity.CreatedDate;
            //updateAbleEntity.CreatedBy = entity.CreatedBy;
            //updateAbleEntity.Deleted = entity.Deleted;
            //updateAbleEntity.ModifiedBy = entity.ModifiedBy;
            //updateAbleEntity.Version = entity.Version;
            //updateAbleEntity.ModifiedDate = DateTime.Now;
            //_repository.Update(updateAbleEntity);

            return (true, $"Update was successfull", model);
        }

        public bool Delete(Guid Id)
        {
            return _repository.Delete(Id);
        }

        public async Task SaveAsync()
        {
            await _repository.SaveAsync();
        }
    }
}
