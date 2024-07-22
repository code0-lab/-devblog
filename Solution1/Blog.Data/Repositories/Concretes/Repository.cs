using Blog.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Core.Entities;
using Blog.Data.Repositories.Abstractions;
using System.Linq.Expressions;

namespace Blog.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new() //IEntityBase'den kalıtım alınarak IEntityBase'den türetilen sınıfların kullanılması sağlandı. T = TEntity olarakta kullanılabilir kısa hali kullanıldı.//
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        private DbSet<T> Table { get => dbContext.Set<T>(); }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            {

                if (includeProperties.Any())
                    foreach (var item in includeProperties)
                        query = query.Include(item);

                return await query.ToListAsync();
            }

        }
        public async Task AddAsync(T entity) //void'in asenkron hali Task kullanıldı.//
        {
            await Table.AddAsync(entity); // asenkron olduğu için await kullanıldı.//
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity)); // asenkron bir şekilde update yapmak için. void yapısıda kullanılabilirdi. //
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnysAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
