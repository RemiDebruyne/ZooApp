﻿using System.Linq.Expressions;
using ZooAPI.Data;
using ZooCore;

namespace ZooAPI.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {

        public Task<T?>? AddAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);
        public Task<T?>? GetAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T?>>? GetAllAsync(Expression<Func<T, bool>> predicate);
        public Task<IEnumerable<T?>>? GetAllAsync();

    }
}
