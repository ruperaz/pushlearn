using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.CategoryClasses
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll(int userId);
        Task<Category> GetByCategoryId(int categoryId);

        Task<int> Add(Category category);
    }
}
