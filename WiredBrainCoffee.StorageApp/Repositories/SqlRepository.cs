﻿
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntityBase
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {

            _dbSet.Add(item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
