using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trendytalk.Models;

namespace trendytalk.Controllers
{
    [Route("api/AdminPanel"), Produces("application/json"), EnableCors("AppPolicy")]
    public class AdminPanelController : Controller
    {

        private dbCoreContext _ctx = null;
        public AdminPanelController(dbCoreContext context)
        {
            _ctx = context;
        }

        // POST api/AdminPanel/PostAdminPanel
        [HttpPost, Route("PostAdminPanel")]
        public async Task<object> PostAdminPanel(IEnumerable<AdminPanelModel> model)
        {
            object result = null; string message = "";
            if (model == null)
            {
                return BadRequest();
            }
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        //AdminPanelModel adModel = new AdminPanelModel()
                        //{
                        //    CategoryId = model.CategoryId,
                        //    CountryId = model.CountryId,
                        //    Topic = model.Topic,
                        //    HyperLink = model.HyperLink,
                        //    IsActive = model.IsActive,
                        //    CreatedOn = DateTime.UtcNow,
                        //    ModifiedOn = model.ModifiedOn
                        //};

                        //NewsChannels ncModel = new NewsChannels()
                        //{
                        //    NewsChannelName = model.NewsChannels.NewsChannelName,
                        //    IsActive = model.NewsChannels.IsActive,
                        //    CreatedOn = DateTime.UtcNow,
                        //    ModifiedOn = model.NewsChannels.ModifiedOn
                        //};

                        //_ctx.AdminPanel.Add(adModel);
                        //_ctx.NewsChannel.Add(ncModel);
                        await _ctx.SaveChangesAsync();
                        _ctxTransaction.Commit();
                        message = "Saved Successfully";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback();
                        e.ToString();
                        message = "Saved Error";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }
    }
}
