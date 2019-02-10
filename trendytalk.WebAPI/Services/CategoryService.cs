using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Entities;

namespace WebApi.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategory();
        Category Create(Category category);
    }

    public class CategoryService: ICategoryService
    {
        private DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategory()
        {
            return _context.category;
        }

        public Category Create(Category category)
        {
            // validation
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new AppException("Name is required");   

            _context.category.Add(category);
            _context.SaveChanges();

            return category;
        }
    }
}
