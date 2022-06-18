using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Product> GetById(int? id);

        Task<Product> Create(Category category);
        Task<Product> Update(Category category);
        Task<Product> Delete(Category category);
    }
}
