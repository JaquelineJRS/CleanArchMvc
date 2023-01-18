using CleanArchMvc.Dominio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Dominio.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Category> GetByIdAsync(int? id);

        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
