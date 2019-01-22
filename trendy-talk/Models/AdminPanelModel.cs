using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.Models
{
    public class AdminPanelModel
    {
        public List<CategoryModel> categoryList { get; set; }
        public List<CountryModel> countryList { get; set; }
    }
}
