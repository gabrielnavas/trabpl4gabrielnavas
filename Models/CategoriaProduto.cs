using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class CategoriaProduto
    {
        int _cod;
        string _nome;

        public int Cod { get => _cod; set => _cod = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public CategoriaProduto(int id, string nome)
        {
            _cod = id;
            _nome = nome;
        }

        public CategoriaProduto()
        {
            _cod = 0;
            _nome = "";
        }


    }
}
