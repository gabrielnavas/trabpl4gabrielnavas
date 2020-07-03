using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    public class CadastrarUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Dictionary<string, string> body)
        {
            string msg = null;
            bool operacao = true;
            int num;

            if (body["email"] == null || body["password"] == null ||
                body["nome"] == null || body["cpf"] == null ||
                body["data"] == null || body["rua"] == null ||
                body["num"] == null || body["cep"] == null ||
                body["data"] == null || 
                !int.TryParse(body["num"], out num))
            {
                msg = "Verifique os campos, veja se estão preenchidos corretamente!";
                operacao = false;
            }
            else
            {
                Models.Endereco endereco = new Models.Endereco();
                Models.Usuario usuario = new Models.Usuario();
                    
                endereco.Rua = body["rua"];
                endereco.Cep = body["cep"].Replace("-", "").Trim();
                endereco.Num = num;

                usuario.Email = body["email"].Trim();
                usuario.Password= body["password"].Trim();
                usuario.Nome = body["nome"].Trim();
                usuario.Cpf = body["cpf"].Replace("-", "").Replace(".","").Trim();
                usuario.Endereco = endereco;

                try
                {
                    usuario.DataNasc = DateTime.Parse(body["data"]);

                    CamadaNegocio.UsuarioCN usuarioCN = new CamadaNegocio.UsuarioCN();
                    (operacao, msg) = usuarioCN.Inserir(usuario);
                }
                catch(Exception ex)
                {
                    msg = "Erro interno.";
                    operacao = false;
                }
            }

            return Json(new { 
                operacao, 
                msg,
            });
        }


        [HttpGet]
        public IActionResult PegarUsuarioByEmail(string email)
        {
            bool operacao = false;
            string msgs = null;
            Models.Usuario usuario = null;
            object user = null;

            CamadaNegocio.UsuarioCN usuarioCN = new CamadaNegocio.UsuarioCN();

            if(email != null)
            {
                (operacao, msgs, usuario) = usuarioCN.PegarUsuarioByEmail(email);
                
                if(usuario != null)
                {
                    user = new
                    {
                        cpf=usuario.Cpf,
                        dataNasc=usuario.DataNasc,
                        email=usuario.Email,
                        endereco=usuario.Endereco,
                        nome=usuario.Nome,
                        cod=usuario.Cod,
                    };
                }
            }
            else
            {
                msgs = "email está nulo";
            }

            return Json(new
            {
                operacao,
                msgs,
                user
            });
        }

        public IActionResult IndexObterPerfil()
        {
            return View();
        }
    }
}