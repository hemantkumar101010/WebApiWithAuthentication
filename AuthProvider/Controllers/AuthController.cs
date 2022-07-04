using AuthProvider.ApiModel;
using EmployeeDataLib;
using EmployeeDataLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthProvider.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        private readonly IConfiguration _configuration;
     
        public AuthController( IConfiguration configuration, EmployeeDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public ActionResult LoginForEmployeeApi([FromBody] EmployeeApiModel empModel)
        {

            if (_context.Employees == null)
            {
                return BadRequest();
            }
            Employee emoloyee = new Employee();
            var employee = _context.Employees.Where(o => o.EmpEmail == empModel.EmpEmail && o.Password == empModel.Password).FirstOrDefault();
            if (employee != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, empModel.EmpName),
                    new Claim("Phone", empModel.EmpPhone),
                    new Claim(ClaimTypes.StreetAddress, empModel.EmpAddress),
                    new Claim(ClaimTypes.Email, empModel.EmpEmail),
                    new Claim("Password", empModel.Password),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = CreateToken(authClaims, _configuration["JWT:EmpAudienceWebApi"], _configuration["JWT:Secret1"]);

                return Ok(token);
           }
            return Ok("Sorry!! input does not matches with the server, you cann't access api methods");
        }

        [HttpPost]
        public ActionResult LoginForWeatherApi([FromBody] EmployeeApiModel empModel)
        {

            if (_context.Employees == null)
            {
                return BadRequest();
            }
            Employee emoloyee = new Employee();
            var employee = _context.Employees.Where(o => o.EmpEmail == empModel.EmpEmail && o.Password == empModel.Password).FirstOrDefault();
            if (employee != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, empModel.EmpName),
                    new Claim("Phone", empModel.EmpPhone),
                    new Claim(ClaimTypes.StreetAddress, empModel.EmpAddress),
                    new Claim(ClaimTypes.Email, empModel.EmpEmail),
                    new Claim("Password", empModel.Password),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var token = CreateToken(authClaims, _configuration["JWT:WeatherForeCastAudienceWebAPI"], _configuration["JWT:Secret2"]);

                return Ok(token);
            }
            return Ok("Sorry!! input does not matches with the server, you cann't access api methods");
        }

        private string CreateToken(List<Claim> authClaims, string audience, string secretKey)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: audience,
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
