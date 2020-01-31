using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.CardClasses;
using ApplicationCore.CategoryClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Utils;

namespace WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(ICategoryService service)
        {
            Service = service;
        }

        public ICategoryService Service { get; }

        public async Task<List<Category>> GetAll(int categoryId)
        {
            var userId=  User.GetLoggedInUserId<int>();
            return await Service.GetAll(userId);
        }


        public async Task<Category> GetByCategoryId(int categoryId)
        {
            return await Service.GetByCategoryId(categoryId);
        }
        
        [HttpPost]
        public async Task<int> Add(Category category)
        {
            category.userId = User.GetLoggedInUserId<int>();
            return await Service.Add(category);
        }
    }
}