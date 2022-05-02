using ETITC_EquipmentControlAPI.Models;
using ETITC_EquipmentControlAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;


namespace ETITC_EquipmentControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUsersColletion db = new UsersColletion();
        public static InternalUsers InternalUsersDto = new InternalUsers();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string Identification, string Password)
        {
            if (Identification == null || Identification == string.Empty)
                return BadRequest("Identificación no valida");
            if (Password == null || Password == string.Empty)
                return BadRequest("Password no puede ser vacio");

            Users user = await db.ReadUser(Identification);

            if (!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Contraseña no coincide");
            }

            return Ok("Autenticación Exitosa");
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}
