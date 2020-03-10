using CarWorkshops.Domain.Models;
using CarWorkshops.Infrastructure.Attributes;
using CarWorkshops.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;


namespace WebApi.Controllers
{
    [TypeFilter(typeof(ApiExceptionFilter), Arguments = new[] { nameof(BrandController) })]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController.BaseController
    {
        private const int CacheItemInSeconds = 60;
        private IUserService _userService;
        private IWorkshopService _workshopService;
        private IBrandService _brandService;

        public BrandController(IUserService userService,
            IWorkshopService workshopService,
            IBrandService brandService,
            IMemoryCache cache) : base(cache)
        {
            _brandService = brandService;
            _userService = userService;
            _workshopService = workshopService;
        }

        [HttpGet("brands")]
        public IActionResult GetAllBrands()
          //also, we can use automapper to Map view model
          => Ok(GetOrCreateCacheEntry<IEnumerable<Brand>>($"brands", _brandService.GetAllBrands, CacheItemInSeconds));
    }
}