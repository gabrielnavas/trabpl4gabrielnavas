using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Produto
    {
        int _cod;
        string _nome;
        string _descricao;
        decimal _valor;
        int _estoque;
        int _estrelas; //usando pra feedback de clientes que compraram....
        CategoriaProduto _categoria;

        public Produto()
        {
            _cod = 0;
            _nome = "";
            _descricao = "";
            _valor = 0.0m;
            _categoria = null;
            _estrelas = 0;
        }


        public Produto(int cod, string nome, string descricao, decimal valor, int estrelas, CategoriaProduto categoria)
        {
            _cod = cod;
            _nome = nome;
            _descricao = descricao;
            _valor = valor;
            _estrelas = estrelas;
            _categoria = categoria;
        }

        public int Cod { get => _cod; set => _cod = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Descricao { get => _descricao; set => _descricao = value; }
        public decimal Valor { get => _valor; set => _valor = value; }
        public CategoriaProduto Categoria { get => _categoria; set => _categoria = value; }
        public int Estrelas { get => _estrelas; set => _estrelas = value; }
        public int Estoque { get => _estoque; set => _estoque = value; }
    }
}
