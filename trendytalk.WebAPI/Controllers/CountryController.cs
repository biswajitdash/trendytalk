﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryService _countryService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CountryController(
           ICountryService countryService,
           IMapper mapper,
           IOptions<AppSettings> appSettings)
        {
            _countryService = countryService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [HttpGet("GetCountry")]
        public IActionResult GetCountry()
        {
            var countries = _countryService.GetCountry();
            return Ok(countries);
        }

 

        //// GET api/Country/GetCountryByID/5
        //[HttpGet, Route("GetCountryByID/{id}")]
        //public async Task<CountryModel> GetCountryByID(int id)
        //{
        //    CountryModel country = null;
        //    try
        //    {
        //        using (_ctx)
        //        {
        //            country = await _ctx.Country.FirstOrDefaultAsync(x => x.CountryId == id);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToString();
        //    }
        //    return country;
        //}


        //// POST api/Country/PostCountry
        //[HttpPost, Route("PostCountry")]
        //public async Task<object> PostCountry([FromBody]CountryModel model)
        //{
        //    object result = null; string message = "";
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }
        //    using (_ctx)
        //    {
        //        using (var _ctxTransaction = _ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                model.IsActive = 1;
        //                model.CreatedOn = DateTime.UtcNow;
        //                model.ModifiedOn = null;
        //                _ctx.Country.Add(model);
        //                await _ctx.SaveChangesAsync();
        //                _ctxTransaction.Commit();
        //                message = "Saved Successfully";
        //            }
        //            catch (Exception e)
        //            {
        //                _ctxTransaction.Rollback();
        //                e.ToString();
        //                message = "Saved Error";
        //            }

        //            result = new
        //            {
        //                message
        //            };
        //        }
        //    }
        //    return result;
        //}

        //// PUT api/Country/PutCountry/5
        //[HttpPut, Route("PutCountry/{id}")]
        //public async Task<object> PutCountry(int id, [FromBody]CountryModel model)
        //{
        //    object result = null; string message = "";
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }
        //    using (_ctx)
        //    {
        //        using (var _ctxTransaction = _ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var entityUpdate = _ctx.Country.FirstOrDefault(x => x.CountryId == id);
        //                if (entityUpdate != null)
        //                {
        //                    entityUpdate.CountryName = model.CountryName;
        //                    entityUpdate.IsActive = model.IsActive;
        //                    entityUpdate.CreatedOn = model.CreatedOn;
        //                    entityUpdate.ModifiedOn = DateTime.UtcNow;

        //                    await _ctx.SaveChangesAsync();
        //                }
        //                _ctxTransaction.Commit();
        //                message = "Entry Updated";
        //            }
        //            catch (Exception e)
        //            {
        //                _ctxTransaction.Rollback(); e.ToString();
        //                message = "Entry Update Failed!!";
        //            }

        //            result = new
        //            {
        //                message
        //            };
        //        }
        //    }
        //    return result;
        //}

        //// DELETE api/Country/DeleteCountryByID/5
        //[HttpDelete, Route("DeleteCountryByID/{id}")]
        //public async Task<object> DeleteCountryByID(int id)
        //{
        //    object result = null; string message = "";
        //    using (_ctx)
        //    {
        //        using (var _ctxTransaction = _ctx.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var idToRemove = _ctx.Country.SingleOrDefault(x => x.CountryId == id);
        //                if (idToRemove != null)
        //                {
        //                    _ctx.Country.Remove(idToRemove);
        //                    await _ctx.SaveChangesAsync();
        //                }
        //                _ctxTransaction.Commit();
        //                message = "Deleted Successfully";
        //            }
        //            catch (Exception e)
        //            {
        //                _ctxTransaction.Rollback(); e.ToString();
        //                message = "Error on Deleting!!";
        //            }

        //            result = new
        //            {
        //                message
        //            };
        //        }
        //    }
        //    return result;
        //}
    }
}