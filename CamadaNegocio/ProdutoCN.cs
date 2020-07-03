using ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaNegocio
{
    public class ProdutoCN
    {
        public ProdutoCN() { }

        public (bool, string) Inserir(Models.Produto produto)
        {
            Models.CategoriaProduto categoriaProduto;
            CamadaAcessoBanco.ProdutoBD produtoBD;

            string msg = "Produto inserido com sucesso!";
            bool operacao = true;

            if(produto.Nome.Length < 2 || produto.Nome.Length > 45)
            {
                msg = "É preciso inserir um nome entre 2 a 45 caracteres.";
                operacao = false;
            }
            
            if (produto.Descricao.Length < 10 || produto.Descricao.Length > 255)
            {
                msg = "É preciso inserir uma descrição entre 10 a 255 caracteres.";
                operacao = false;
            }

            if (produto.Valor < 0 || produto.Valor > 9999999 )
            {
                msg = "É preciso digitar um valor não negativo e não muito grande.";
                operacao = false;
            }

            if (produto.Estoque < 0 || produto.Estoque > 999999999)
            {
                msg = "É preciso digitar uma quantidade não negativa e não muito grande.";
                operacao = false;
            }

            if (produto.Categoria.Cod <= 0)
            {
                msg = "É necessário uma categoria válida.";
                operacao = false;
            }

            if(operacao)
            {
                produtoBD = new CamadaAcessoBanco.ProdutoBD();
                categoriaProduto = produtoBD.ObterCategoria(produto.Categoria.Cod);
                produto.Estrelas = 0;

                if(categoriaProduto == null)
                {
                    msg = "Categoria não cadastrada.";
                    operacao = false;
                }
                else if(produtoBD.ObterProdutoPorNome(produto.Nome) != null)
                {
                    msg = "Nome de produto já cadastrado.";
                    operacao = false;
                }
                else
                {
                    if(!produtoBD.Criar(produto))
                    {
                        msg = "Problema ao gravar o produto.";
                        operacao = false;
                    }
                }
            }

            return (operacao, msg);
        }

        public (bool, string) inserirFotosEmProduto(int id, byte[][] fotos)
        {

            bool operacao = true;
            string msgs = "";

            if(id == 0)
            {
                operacao = false;
                msgs = "id do produto inválido";
            }

            //if (foto.LongCount() > 10 * (1024 * 3))
            //{
            //    msg = "Arquivo muito grande.";
            //}
            //else

            if(operacao)
            {
                CamadaAcessoBanco.ProdutoBD produtoBD = new CamadaAcessoBanco.ProdutoBD();
                produtoBD.inserirFotosEmProduto(id, fotos);
                msgs = "Inserido com sucesso";
            }

            return (operacao, msgs);
        }

        public List<Models.CategoriaProduto> ObterCategorias()
        {
            CamadaAcessoBanco.ProdutoBD produtoBD = new CamadaAcessoBanco.ProdutoBD();

            return produtoBD.ObterCategorias();
        }

        public (bool, string, List<Produto>) Pesquisar(string nomeProd)
        {
            List<Models.Produto> produtos = null;
            CamadaAcessoBanco.ProdutoBD produtoBD;
            bool operacao = true;
            string msg = "";

            if(nomeProd.Length == 0)
            {
                msg = "Não é possível realizar uma pesquisa sem filtro por nome.";
                operacao = false;
            }
            else
            {
                nomeProd=nomeProd.ToLower();

                //pesquisa mesmo se nao tiver filtro, trás
                produtoBD = new CamadaAcessoBanco.ProdutoBD();
                produtos = produtoBD.Pesquisar(nomeProd);

                if(produtos == null)
                {
                    operacao = false;
                }
            }

            return (operacao, msg, produtos);
        }

        public bool Excluir(int cod)
        {
            CamadaAcessoBanco.ProdutoBD produtoBD = new CamadaAcessoBanco.ProdutoBD();
            return produtoBD.Excluir(cod);
        }

        public byte[] ObterUmaFoto(int id, int numero)
        {
            CamadaAcessoBanco.ProdutoBD produtoCN = new CamadaAcessoBanco.ProdutoBD();
            return produtoCN.ObterUmaFoto(id, numero);
        }

        //public byte[] ObterFotoDois(int id)
        //{
        //    CamadaAcessoBanco.ProdutoBD produtoCN = new CamadaAcessoBanco.ProdutoBD();
        //    return produtoCN.ObterFotoDois(id);
        //}
    }
}
