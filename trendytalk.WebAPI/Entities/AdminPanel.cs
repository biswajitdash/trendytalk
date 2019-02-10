using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trendytalk.WebAPI.Entities
{
    public class AdminPanel
    {
        public int AdminPanelId { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public string Topic { get; set; }
        public string HyperLink { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public List<NewsChannel> NewsChannels { get; set; }
    }

    public class NewsChannel
    {
        public int NewsChannelId { get; set; }
        public int AdminPanelId { get; set; }
        public string NewsChannelName { get; set; }
        public int IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
