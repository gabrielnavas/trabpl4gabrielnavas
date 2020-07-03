using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Authorize("CookieAuth")]
    public class LogarController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Logar([FromBody] Dictionary<string, string> body)
        {
            string msg = null;
            bool operacao = false;




            if (body["email"] == null && body["password"] == null)
            {
                msg = "Email ou senha inválidos";
            }
            else
            {
                Models.Usuario usuario = new Models.Usuario();
                usuario.Email = body["email"];
                usuario.Password = body["password"];

                CamadaNegocio.UsuarioCN usuarioCN = new CamadaNegocio.UsuarioCN();
                (operacao, msg, usuario) = usuarioCN.Logar(usuario);

                //criar cookie
                if (operacao)
                {

                    #region criando as cookie de autenticação

                    var usuarioClaims = new List<Claim>()
                    {
                        new Claim("usuarioId", usuario.Cod.ToString()),
                        new Claim("usuarioNome", usuario.Nome)
                    };

                    var identificacao = new ClaimsIdentity(usuarioClaims, "Identificação do Usuário");
                    var principal = new ClaimsPrincipal(identificacao);


                    //gerar a cookie
                    Microsoft.AspNetCore
                        .Authentication
                        .AuthenticationHttpContextExtensions
                        .SignInAsync(HttpContext, principal);
                }


                #endregion

            }


            return Json(new
            {
                operacao,
                msg
            });
        }

        public IActionResult Sair()
        {

            //excluir a cokkie
            Microsoft.AspNetCore
                .Authentication
                .AuthenticationHttpContextExtensions
                .SignOutAsync(HttpContext);


            return Redirect("/Logar/");
        }
    }
}