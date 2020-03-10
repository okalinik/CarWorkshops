using CarWorkshops.Domain.Models;
using CarWorkshops.Domain.Models.Enum;
using CarWorkshops.Infrastructure;
using CarWorkshops.Infrastructure.Attributes;
using CarWorkshops.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [TypeFilter(typeof(ApiExceptionFilter), Arguments = new[] { nameof(UserController) })]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController.BaseController
    {
        private const int CacheItemInSeconds = 60;
        private IUserService _userService;
        private IWorkshopService _workshopService;
        private IAppointmentService _appointmentService;

        public UserController(
            IUserService userService,
            IWorkshopService workshopService,
            IAppointmentService appointmentService,
            IMemoryCache cache) : base(cache)
        {
            _userService = userService;
            _workshopService = workshopService;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [AuthorizeRoles(new[] { UserRole.Admin, UserRole.Staff })]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
            => Ok(await _userService.GetUserById(userId));


        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpGet("workshop/{city}")]
        public async Task<IActionResult> GetWorkshopByCity(string city)
            => Ok(await _workshopService.GetWorkhopsByCity(city));

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllAppoinments(string city)
           => Ok(await _appointmentService.GetAllAppoinments());


        [HttpGet("carworkshops")]
        public async Task<IActionResult> GetAllAppoinments([FromBody] string city, string trademark)
           => Ok(await _workshopService.GetWorkhopsByCityAndTrademarkCount(city, trademark));
    }
}