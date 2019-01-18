using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trendytalk.Models;

namespace trendytalk.Controllers
{
    [Route("api/Category"), Produces("application/json"), EnableCors("AppPolicy")]
    public class CategoryController : Controller
    {
        private CategoryContext _ctx = null;
        public CategoryController(CategoryContext context)
        {
            _ctx = context;
        }


        // GET: api/Category/GetCategory
        [HttpGet, Route("GetCategory")]
        public async Task<object> GetCategory()
        {
            List<Category> categories = null;
            object result = null;
            try
            {
                using (_ctx)
                {
                    categories = await _ctx.Category.ToListAsync();
                    result = new
                    {
                        categories
                    };
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return categories;
        }

        // GET api/Category/GetCategoryByID/5
        [HttpGet, Route("GetCategoryByID/{id}")]
        public async Task<Category> GetCategoryByID(int id)
        {
            Category category = null;
            try
            {
                using (_ctx)
                {
                    category = await _ctx.Category.FirstOrDefaultAsync(x => x.CategoryId == id);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return category;
        }


        // POST api/Category/PostCategory
        [HttpPost, Route("PostCategory")]
        public async Task<object> PostCategory([FromBody]Category model)
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
                        model.IsActive = 1;
                        model.CreatedOn = DateTime.UtcNow;
                        model.ModifiedOn = null;
                        _ctx.Category.Add(model);
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

        // PUT api/Category/PutCategory/5
        [HttpPut, Route("PutCategory/{id}")]
        public async Task<object> PutCategory(int id, [FromBody]Category model)
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
                        var entityUpdate = _ctx.Category.FirstOrDefault(x => x.CategoryId == id);
                        if (entityUpdate != null)
                        {
                            entityUpdate.CategoryName = model.CategoryName;
                            entityUpdate.IsActive = model.IsActive;
                            entityUpdate.CreatedOn = model.CreatedOn;
                            entityUpdate.ModifiedOn = DateTime.UtcNow;

                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Entry Updated";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Entry Update Failed!!";
                    }

                    result = new
                    {
                        message
                    };
                }
            }
            return result;
        }

        // DELETE api/Category/DeleteCategoryByID/5
        [HttpDelete, Route("DeleteCategoryByID/{id}")]
        public async Task<object> DeleteCategoryByID(int id)
        {
            object result = null; string message = "";
            using (_ctx)
            {
                using (var _ctxTransaction = _ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var idToRemove = _ctx.Category.SingleOrDefault(x => x.CategoryId == id);
                        if (idToRemove != null)
                        {
                            _ctx.Category.Remove(idToRemove);
                            await _ctx.SaveChangesAsync();
                        }
                        _ctxTransaction.Commit();
                        message = "Deleted Successfully";
                    }
                    catch (Exception e)
                    {
                        _ctxTransaction.Rollback(); e.ToString();
                        message = "Error on Deleting!!";
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
