using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using trendytalk.WebAPI.Services;
using WebApi.Helpers;

namespace trendytalk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CategoryController(
           ICategoryService categoryService,
           IMapper mapper,
           IOptions<AppSettings> appSettings)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
    }
}