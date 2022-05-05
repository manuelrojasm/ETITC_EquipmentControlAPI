using ETITC_EquipmentControlAPI.Models;
using ETITC_EquipmentControlAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ETITC_EquipmentControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterDevicesController : Controller
    {
        private IRegisterDevicesColletion db = new RegisterDevicesColletion();

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllRegisterDevices()
        {
            return Ok(await db.GetAllRegisterDevices());
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateRegisterDevices([FromBody] RegisterDevices registerDevices)
        {
            if (registerDevices == null)
                return BadRequest();

            await db.CreateRegisterDevices(registerDevices);
            return Created("Registro creado", true);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> ReadRegisterDevices(string Id)
        {
            return Ok(await db.ReadRegisterDevices(Id));
        }

        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> UpdateRegisterDevices([FromBody] RegisterDevices registerDevices, string Id)
        {
            registerDevices.Id = new MongoDB.Bson.ObjectId(Id);
            await db.UpdateRegisterDevices(registerDevices);
            return Created("Actulizaste el registro", true);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> DeleteRegisterDevices(string id)
        {
            await db.DeleteRegisterDevices(id);
            return StatusCode(202);
        }

    }
}
