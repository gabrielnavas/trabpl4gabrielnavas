using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Usuario
    {
        int cod;
        string nome;
        string email;
        string password;
        DateTime dataNasc;
        Endereco endereco;
        string cpf;

        public Usuario()
        {
            this.nome = "";
            this.email = "";
            this.password = "";
            this.endereco = null;
            this.cpf = "";
        }

        public Usuario(string nome, string email, string password, Endereco endereco, string cpf)
        {
            this.nome = nome;
            this.email = email;
            this.password = password;
            this.endereco = endereco;
            this.cpf = cpf;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime DataNasc { get => dataNasc; set => dataNasc = value; }
        public Endereco Endereco { get => endereco; set => endereco = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public int Cod { get => cod; set => cod = value; }
        public Endereco Endereco1 { get => endereco; set => endereco = value; }
    }
}
