using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.CategoryClasses
{
    public class CategoryService : ICategoryService
    {

        public CategoryService(ICategoryRepository repository)
        {
            Repository = repository;
        }

        public ICategoryRepository Repository { get; }

        public async Task<List<Category>> GetAll(int userId)
        {
            return await Repository.GetAll(userId);
        }

        public async Task<Category> GetByCategoryId(int categoryId)
        {
            return await Repository.GetByCategoryId(categoryId);
        }

        public async Task<int> Add(Category category)
        {
            return await Repository.Add(category);
        }
    }
}
