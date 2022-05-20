using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DisneyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(auth request)
        {
            CrearContraseñaHash(request.Contraseña, out byte[] contraseñaHash, out byte[] contraseñaSalt);

            user.Usuario = request.Usuario;
            user.ContraseñaHash = contraseñaHash;
            user.ContraseñaSalt = contraseñaSalt;

            EnvioMail().Wait();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(auth request)
        {
            if (user.Usuario != request.Usuario)
                return BadRequest("Usuario no encontrado");
            if (!VerificacionContraseñaHash(request.Contraseña, user.ContraseñaHash, user.ContraseñaSalt))
                return BadRequest("Contraseña incorrecta");

            string token = CrearToken(user);

            return Ok(token);    
        }

        private string CrearToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Usuario)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CrearContraseñaHash(string contraseña, out byte[] contraseñaHash, out byte[] contraseñaSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                contraseñaSalt = hmac.Key;
                contraseñaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contraseña));

            }
        }

        private bool VerificacionContraseñaHash(string contraseña, byte[] contraseñaHash, byte[] contraseñaSalt)
        {
            using (var hmac = new HMACSHA256(contraseñaSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(contraseña));
                return computedHash.SequenceEqual(contraseñaHash);
            }
        }


        private async Task EnvioMail()
        {
            var client = new SendGridClient("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");

            var from = new EmailAddress("edgardomm95@gmail.com", "Registro Disney");
            var subject = "Bienvenido a la API de Disney"; 
            var to = new EmailAddress("edgardomm95@gmail.com", "Registro Disney");
            var plainTexContent = "Gracias por registrarse en Disney API";
            var htmlContent = "<stronger>Gracias por registrarse en Disney API</stronger>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTexContent, htmlContent);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
