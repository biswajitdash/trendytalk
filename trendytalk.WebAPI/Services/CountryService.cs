using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Entities;
using trendytalk.WebAPI.Entities;

namespace WebApi.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountry();
        //Category Create(Category category);
    }

    public class CountryService : ICountryService
    {
        private DataContext _context;

        public CountryService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountry()
        {
            return _context.country;
        }

        //public Category Create(Category category)
        //{
        //    // validation
        //    if (string.IsNullOrWhiteSpace(category.CategoryName))
        //        throw new AppException("Name is required");   

        //    _context.category.Add(category);
        //    _context.SaveChanges();

        //    return category;
        //}
    }
}
