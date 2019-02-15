namespace CA.API.Controllers
{
    #region Using

    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain.Supervisor;
    using Domain.ViewModels;
    using Microsoft.AspNetCore.Authorization;

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

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserViewModel userViwModel)
        {
            try
            {
                var user = _caSupervisor.Authenticate(userViwModel.Email, userViwModel.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return new ObjectResult(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
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