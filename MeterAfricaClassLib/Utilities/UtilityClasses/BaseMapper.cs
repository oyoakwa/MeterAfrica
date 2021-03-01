using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Utilities.UtilityClasses
{

    public interface IBaseMapper<TEntity, TDataObject>
    {
        TDataObject MapEntityToModel(TEntity entity);
        TEntity MapModelToEntity(TDataObject model);
        List<TDataObject> MapListEntityToListModel(List<TEntity> entities);
        List<TEntity> MapListModelToListEntity(List<TDataObject> models);
    }

    class BaseMapper<TEntity, TDataObject> : IBaseMapper<TEntity, TDataObject>
    {
        public TDataObject MapEntityToModel(TEntity entity)
        {
            var model = entity.Adapt<TDataObject>();
            return model;
        }

        public TEntity MapModelToEntity(TDataObject model)
        {
            return model.Adapt<TEntity>();
        }

        public List<TDataObject> MapListEntityToListModel(List<TEntity> entities)
        {
            var dataObjects = entities.Adapt<List<TEntity>, List<TDataObject>>();
            return dataObjects;
        }

        public List<TEntity> MapListModelToListEntity(List<TDataObject> models)
        {
            var listEntities = models.Adapt<List<TDataObject>, List<TEntity>>();
            return listEntities;
        }
    }
}
