using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("logintoken")]
        public async Task<ActionResult> LoginWithToken([FromBody] Users users)
        {
            //_loginToken.Login(users);
            //return Ok(users);
            try
            {
                var obj = new Entity<string>();
                var user = await _authRepository.LoginWithToken(users.TokenKey);
                if (user == null)
                {
                    obj.Status = false;
                    obj.Message = "Kullanıcı bulunamadı";

                    return Ok(obj);
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Appsettings:Token").Value);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                     new Claim(ClaimTypes.NameIdentifier,user.UyeSapKodu.ToString()),
                    }),

                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                obj.Status = true;
                obj.Message = "ok";
                obj.Result = tokenString;

                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}