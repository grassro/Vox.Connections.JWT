using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxConnections.JWT.JwtModels;
using VoxConnections.JWT.Models;
using Microsoft.AspNetCore.Mvc;
using VoxConnections.JWT.Repository;
using VoxConnections.JWT.Context;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;

namespace VoxConnections.JWT.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class TokenController : Controller
    {
        private readonly VoxContext repo;

        public TokenController(VoxContext _repo)
        {
            repo = _repo;
        }


        [HttpPost]
        public IActionResult Post([FromBody]LoginModel loginModel)
        {
            bool credenciaisValidas = false;
            var usuarioBase = new UsuarioRepository(repo).Find(loginModel);

            //verifica se foi informado o usuário e a senha
            if (loginModel != null)
            {
                credenciaisValidas = (usuarioBase != null &&
                    loginModel.Username == usuarioBase.Result.Email &&
                    loginModel.Password == usuarioBase.Result.Senha);
            }

            if (!credenciaisValidas)
                return Unauthorized();

            var perfil = usuarioBase.Result.TipoUsuario.ToString();
            var perfilCod = (int)usuarioBase.Result.TipoUsuario;
            var usuario = usuarioBase.Result.IdUsuario.ToString();
            var idPerfil = 0;

            if (perfil == "Candidato")
            {
                idPerfil = new UsuarioRepository(repo).FindCandidato(usuarioBase.Result.IdUsuario).Result;
            }
            else if (perfil == "Headhunter")
            {
                idPerfil = new UsuarioRepository(repo).FindHead(usuarioBase.Result.IdUsuario).Result;
            }
            else if (perfil == "Gestor")
            {
                idPerfil = new UsuarioRepository(repo).FindGestor(usuarioBase.Result.IdUsuario).Result;
            }


            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("a-password-very-big-to-be-good"))
                                .AddSubject(usuarioBase.Result.Nome)
                                .AddIssuer("voxconnections.com")
                                .AddAudience("voxconnections.com")
                                .AddNameId(loginModel.Username)
                                .AddClaim("Perfil", perfil)
                                .AddClaim("IdPerfil", idPerfil.ToString())
                                .AddClaim("IdUsuario", usuario)
                                .AddExpiry(5)
                                .Build();

            return Ok(token);
        }


    }
}
