using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Endereco
    {
        int _cod;
        string _rua;
        int _num;
        string _cep;

        public Endereco()
        {
            _cod = 0;
            _rua = "";
            _num = 0;
            _cep = "";
        }

        public Endereco(int cod, string rua, int num, string cep)
        {
            _cod = cod;
            _rua = rua;
            _num = num;
            _cep = cep;
        }

        public int Cod { get => _cod; set => _cod = value; }
        public string Rua { get => _rua; set => _rua = value; }
        public int Num { get => _num; set => _num = value; }
        public string Cep { get => _cep; set => _cep = value; }
    }
}
