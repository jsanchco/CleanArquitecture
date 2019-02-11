namespace CA.API.Controllers
{
    #region Using

    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Supervisor;
    using Domain.ViewModels;

    #endregion

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ICASupervisor _caSupervisor;

        public UsersController(ICASupervisor caSupervisor)
        {
            _caSupervisor = caSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<UserViewModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new ObjectResult(await _caSupervisor.GetAllUserAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}