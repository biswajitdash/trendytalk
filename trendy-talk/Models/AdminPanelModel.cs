using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.Models
{
    public class AdminPanelModel
    {
        [Key]
        public int AdminPanelId { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public string Topic { get; set; }
        public string HyperLink { get; set; }
        public int NewsChannelId { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public NewsChannels NewsChannels { get; set; }
    }

    public class NewsChannels
    {
        [Key]
        public int NewsChannelId { get; set; }
        public string NewsChannelName { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
