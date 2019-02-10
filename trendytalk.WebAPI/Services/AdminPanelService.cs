using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;
using WebApi.Entities;
using trendytalk.WebAPI.Entities;

namespace WebApi.Services
{
    public interface IAdminPanelService
    {
        AdminPanel Create(AdminPanel adminpanel);
    }

    public class AdminPanelService : IAdminPanelService
    {
        private DataContext _context;

        public AdminPanelService(DataContext context)
        {
            _context = context;
        }

        public AdminPanel Create(AdminPanel adminpanel)
        {
            // validation
            //if (string.IsNullOrWhiteSpace(adminpanel.))
            //    throw new AppException("Name is required");

            _context.adminpanel.Add(adminpanel);
            _context.SaveChanges();

            return adminpanel;
        }
    }
}
