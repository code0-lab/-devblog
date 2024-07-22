using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.Entities;

namespace Blog.Data.Repositories.Abstractions
{
    public interface IRepository<T> where T : class, IEntityBase, new() //IEntityBase'den kalıtım alınarak IEntityBase'den türetilen sınıfların kullanılması sağlandı. T = TEntity olarakta kullanılabilir kısa hali kullanıldı.//
    {
        Task AddAsync(T entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties) ;
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity); //Bu metod tam olarak silmez bunun için HardDeleteAsync metodunu kullanmak gerekir. bu metodu admin rolüne ver.//
        Task <bool> AnysAsync(Expression<Func<T, bool>> predicate); //bool türü, bir ifade veya koşul doğru ise true değerini alırken, yanlış ise false değerini alır.//
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);  
    }
}
