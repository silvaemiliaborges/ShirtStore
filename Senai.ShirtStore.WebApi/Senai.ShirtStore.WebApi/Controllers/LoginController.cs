using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.Repositories;
using Senai.ShirtStore.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Controllers
{
        [Route("api/[controller]")]
        [Produces("application/json")]
        [ApiController]
        public class LoginController : ControllerBase
        {
            LoginRepository LoginRepository = new LoginRepository();

            public LoginController(LoginRepository loginRepository)
            {
                LoginRepository = loginRepository;
            }

            [HttpPost]
            public IActionResult Login(LoginViewModel login)
            {
                try
                {
                    Usuario Usuarios = LoginRepository.BuscarEmailESenha(login);
                    if (Usuarios == null)
                    {
                        return NotFound(new { mensagem = "Email ou senha inválidos." });
                    }

                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, Usuarios.Email),
                    new Claim("chave", "valor"),
                    new Claim(JwtRegisteredClaimNames.Jti, Usuarios.IdUsuario.ToString())
                };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ShirtStore-chave-autenticacao"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "ShirtStore.WebApi",
                        audience: "ShirtStore.WebApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(45),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                }
                catch (Exception ex)
                {
                    return BadRequest(new { mensagem = "Erro." + ex.Message });
                }
            }
        }
}
