using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaNegocio
{
    public class UsuarioCN
    {
        public (bool, string, Models.Usuario) Logar(Models.Usuario usuario)
        {
            bool operacao;
            string msg;

            var ubd = new CamadaAcessoBanco.UsuarioBD();

            (operacao, usuario) = ubd.Validar(usuario);

            if (operacao)
            {
                operacao = true;
                msg = "Logado com sucesso";
            }
            else
            {
                operacao = false;
                msg = "Login ou senha inválidos.";
            }

            return (operacao, msg, usuario);
        }


        public (bool, string) Inserir(Models.Usuario usuario)
        {
            string msg;
            bool operacao;

            (operacao, msg) = ValidaUsuarioInserir(usuario);


            if (operacao)
            {
                var ubd = new CamadaAcessoBanco.UsuarioBD();
                if (!ubd.CheckUsuarioByEmail(usuario) && !ubd.PegarUsuarioByNome(usuario))
                {
                    if (ubd.Criar(usuario))
                    {
                        operacao = true;
                        msg = "Usuário inserido com sucesso!";
                    }
                    else
                    {
                        operacao = false;
                        msg = "Ocorreu um problema, tenta novamente mais tarde.";
                    }
                }
                else
                {
                    operacao = false;
                    msg = "Email já em uso ou Nome já em uso.";
                }
            }

            return (operacao, msg);

        }

        public bool ValidarUsuarioLogin(Models.Usuario usuario)
        {
            if (usuario.Email.Length == 0 || usuario.Email.Length > 30 ||
                !usuario.Email.Contains("@") && !usuario.Email.Contains(".") || 
                usuario.Password.Length == 0 || usuario.Password.Length > 30 /*|| usuario.Password.Length < 10*/)
            {
                return false;
            }

            return true;
        }

        public (bool, string, Models.Usuario) PegarUsuarioByEmail(string email)
        {
            CamadaAcessoBanco.UsuarioBD ubd = new CamadaAcessoBanco.UsuarioBD();
            
            var user = ubd.PegarUsuarioByEmail(email);
            string msgs = (user == null) ? "usuário não existe" : null;

            return (user != null, msgs, user);
        }

        private (bool, string) ValidaUsuarioInserir(Models.Usuario usuario)
        {
            string msg = null;
            bool operacao = true;

            if (!usuario.Email.Contains("@")|| !usuario.Email.Contains(".") || usuario.Email.Length == 0 || usuario.Email.Length > 30)
            {
                msg = "Email deve ter @ e ponto(.) entre 1 e 30 caracteres";
                operacao = false;

            } 
            else if(usuario.DataNasc.ToString().Split(" ")[0].Split("/").Length != 3)
            {
                msg = "É preciso ter dia, mês e ano na data de nascimento.";
                operacao = false;
            }
            else if(usuario.Nome.Length == 0 || usuario.Nome.Length > 30)
            {
                msg = "Nome tem que ser menor que 30 caracteres!";
                operacao = false;
            }
            else if (usuario.Cpf.Length == 0 || usuario.Cpf.Length < 11 || usuario.Cpf.Length > 11)
            {
                msg = "CPF tem que ter 11 caracteres!";
                operacao = false;
            }
            else if (usuario.Endereco.Rua.Length == 0 || usuario.Endereco.Rua.Length > 50)
            {
                msg = "Rua deve ter menos que 50 caracteres!";
                operacao = false;
            }
            else if (usuario.Endereco.Num <= 0 || usuario.Endereco.Num > 9999999)
            {
                msg = "Número muito grande!";
                operacao = false;

            }
            else if (usuario.Endereco.Cep.Length == 0 || usuario.Endereco.Cep.Length < 8 || usuario.Endereco.Cep.Length > 8)
            {
                msg = "CEP deve ter 8 caracteres";
                operacao = false;

            }
            else if (usuario.Password.Length == 0 || usuario.Password.Length > 30)
            {
                msg = "Senha tem que ser menor que 30 caracteres!";
                operacao = false;
            }
            else
            {
                operacao = true;
            }

            return (operacao, msg);
        }
    }
}
