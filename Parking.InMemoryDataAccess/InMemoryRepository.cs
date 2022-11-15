using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Parking.Domain;

namespace Parking.InMemoryDataAccess
{
    public class InMemoryRepository<TModel> : IRepository<TModel> where TModel : NotifyPropertyObject
    {
        private readonly MainContext context;
        private readonly DbSet<TModel> entities;

        public InMemoryRepository(MainContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            entities = context.Set<TModel>();
        }

        public void Add(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!entities.Contains(entity))
                _ = entities.Add(entity);
            _ = context.SaveChanges();
        }

        public void Delete(int id)
        {
            _ = entities.Remove(GetById(id));
            _ = context.SaveChanges();
        }

        public TModel[] GetAll()
        {
            return entities.ToArray();
        }

        public TModel GetById(int id)
        {
            TModel entity = entities.Find(id) ?? throw new KeyNotFoundException(nameof(id));
            return entity;
        }

        public void Update(TModel entity)
        {
            _ = context.Update(entity);
            _ = context.SaveChanges();
        }
    }
}
