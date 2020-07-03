using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaNegocio
{
    public class CatalogoCN
    {
        public List<object> ObterProdutos()
        {
            CamadaAcessoBanco.ProdutoBD produtoBD = new CamadaAcessoBanco.ProdutoBD();
            

            List<object> produtosQntd = new List<object>();

            var prods = produtoBD.ObterProdutos();

            if(prods.Count > 0)
                foreach (var prod in prods)
                {
                    produtosQntd.Add(
                        new
                        {
                            cod = prod.Cod,
                            nome = prod.Nome,
                            descricao = prod.Descricao,
                            valor = prod.Valor,
                            estoque = prod.Estoque,
                            estrelas = prod.Estrelas, //usando pra feedback de clientes que compraram....
                            categoria = prod.Categoria,
                            qntdFotos = produtoBD.obterQntdFotos(prod.Cod)
                        });
                }

            return produtosQntd;
        }
    }
}
