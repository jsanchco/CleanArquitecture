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
    public class AddressesController : ControllerBase
    {
        private readonly ICASupervisor _caSupervisor;

        public AddressesController(ICASupervisor caSupervisor)
        {
            _caSupervisor = caSupervisor;
        }

        [HttpGet]
        [Produces(typeof(List<AddressViewModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return new ObjectResult(await _caSupervisor.GetAllAddressAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}