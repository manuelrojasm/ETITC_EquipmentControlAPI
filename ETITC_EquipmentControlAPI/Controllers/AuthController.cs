using ETITC_EquipmentControlAPI.Models;
using ETITC_EquipmentControlAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;


namespace ETITC_EquipmentControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IUsersColletion db = new UsersColletion();
        public static InternalUsers InternalUsersDto = new InternalUsers();
        public static LoggedUsers LoggedUsersDto = new LoggedUsers();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(string Identification, string Password)
        {
            if (Identification == null || Identification == string.Empty)
                return BadRequest("Identificación no valida");
            if (Password == null || Password == string.Empty)
                return BadRequest("Password no puede ser vacio");

            Users user = await db.ReadUser(Identification);

            if (user == null)
                return BadRequest("Usuario aún no ha sido creado");

            if (!VerifyPasswordHash(Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Contraseña no coincide");
            }

            LoggedUsersDto.Id = user.Id;
            LoggedUsersDto.IdentificationNumber = user.IdentificationNumber;
            LoggedUsersDto.Name = user.Email;
            LoggedUsersDto.LastName = user.Email;
            LoggedUsersDto.Email = user.Email;
            LoggedUsersDto.Telephone = user.Email;
            LoggedUsersDto.Token = CreateToken(user);
            LoggedUsersDto.ExpirationToken = DateTime.Now.AddMinutes(30);
            LoggedUsersDto.status = user.status;   
            
            return Ok(LoggedUsersDto);
        }
        
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Constants.SecrectKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
