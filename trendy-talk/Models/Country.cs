using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
