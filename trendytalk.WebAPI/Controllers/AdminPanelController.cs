using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using trendytalk.WebAPI.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private IAdminPanelService _adminpanelService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AdminPanelController(
           IAdminPanelService adminpanelService,
           IMapper mapper,
           IOptions<AppSettings> appSettings)
        {
            _adminpanelService = adminpanelService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
        [HttpPost("saveadminpanel")]
        public IActionResult SaveAdminPanel([FromBody]AdminPanel adminpanel)
        {
            // map dto to entity
            //var user = _mapper.Map<User>(userDto);

            try
            {
                // save 
                _adminpanelService.Create(adminpanel);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}