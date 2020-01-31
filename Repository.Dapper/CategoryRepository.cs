using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.CardClasses;
using ApplicationCore.CategoryClasses;

namespace Repository.Dapper
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<List<Category>> GetAll(int userId)
        {
            var query = @"select c.id,
                               c.createdAt,
                               c.isActive,
                               c.title,
                               c.userId,
                               c.createdAt,
                               COUNT(cards.id) as card_count
                        from Categories c
                                 left join cards on cards.categoryId = c.id
                        where c.userId = 1
                        group by c.id, c.createdAt, c.isActive, c.title, c.userId, c.createdAt";
            return (await SqlServerDbConnection.QueryAsync<Category>(query,new {userId })).ToList();
        }

        public async Task<Category> GetByCategoryId(int categoryId)
        {
            var query = "select top 1 * from Categories where Id=@categoryId";
            return (await SqlServerDbConnection.QueryAsync<Category>(query, new {categoryId})).FirstOrDefault();
        }

        public async Task<int> Add(Category category)
        {
            var query =
                @"Insert categories (title,userId) values (@title , @userId)";
            return await SqlServerDbConnection.ExecuteAsync(query,
                new {category.title, category.userId});
        }
    }
}