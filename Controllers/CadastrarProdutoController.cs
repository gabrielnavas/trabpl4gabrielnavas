using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [Authorize("CookieAuth")]
    public class CadastrarProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexListar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirProduto([FromBody] Dictionary<string, string> dados)
        {
            string msg = null;
            bool operacao = true;
            Models.Produto produto = null;


            if (dados["nome"] == null ||
                dados["descricao"] == null ||
                dados["valor"] == null ||
                dados["estoque"] == null ||
                dados["categoria"] == null)
            {
                msg = "Verifique os campos, veja se estão preenchidos corretamente!";
                operacao = false;
            }
            else
            {
                Models.CategoriaProduto categoriaProduto = new Models.CategoriaProduto();
                produto = new Models.Produto();

                CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();

                produto.Nome = dados["nome"];
                produto.Descricao = dados["descricao"];

                try
                {
                    produto.Valor = Convert.ToDecimal(dados["valor"]);
                }
                catch(Exception ex)
                {
                    msg = "Valor tem que ser formato númerico.";
                }

                try
                {
                    produto.Estoque = Convert.ToInt32(dados["estoque"]);
                }
                catch(Exception ex)
                {
                    msg = "Quantidade de estoque deve ser númerico.";
                }

                try
                {
                    categoriaProduto.Cod = Convert.ToInt32(dados["categoria"]);
                }
                catch (Exception ex)
                {
                    msg = "Selecione uma cartegoria corretamente.";
                }

                produto.Categoria = categoriaProduto;

                if (operacao)
                {
                    (operacao, msg) = produtoCN.Inserir(produto);
                }

            }

            return Json(new
            {
                produto,
                msg,
                operacao
            });
        }

        [HttpPost]
        public IActionResult InserirFotos()
        {
            bool operacao = true;
            string msg = "";

            int id=0;
            List<byte[]> arquivos;
            string nome;
    
            try
            {
                id = Convert.ToInt32(Request.Form["cod"]);
            }
            catch(Exception ex)
            {
                operacao = false;
                msg = "id do produto inválido";
            }

            if(Request.Form.Files.Count < 2)
            {
                operacao = false;
                msg = "Necessário pelo menos duas fotos.";
            }

            if (operacao)
            {
                arquivos = new List<byte[]>();

                for(int i=0; operacao && i < Request.Form.Files.Count; i++)
                {
                    nome = Request.Form.Files[i].FileName;

                    if(System.IO.Path.GetExtension(nome) != ".jpg")
                    {
                        operacao = false;
                        msg = "Formato da foto " + (i+1) + " inválido";
                    }
                    else
                    {
                        //joga o arquivo para memoria manipulável
                        MemoryStream ms = new MemoryStream();
                        Request.Form.Files[i].CopyTo(ms);
                        arquivos.Add(ms.ToArray());
                    }
                }
    

                //tudo certo, inserir
                if(operacao)
                {
                    CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();
                    (operacao, msg) = produtoCN.inserirFotosEmProduto(id, arquivos.ToArray());
                }

            }

            return Json(new
            {
                operacao,
                msg
            });
        }

        public IActionResult ObterUmaFoto(int id, int numero)
        {
            CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();

            byte[] foto = produtoCN.ObterUmaFoto(id, numero);


            if(foto == null)
            {
                return File("~/img/sem_foto.jpg", "image/jpg");
            }
            return File(foto, "image/jpg");

        }

        //public IActionResult ObterFotoDois(int id)
        //{
        //    CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();

        //    byte[] foto = produtoCN.ObterFotoDois(id);

        //    if (foto == null)
        //    {
        //        return File("~/img/sem_foto.jpg", "image/jpg");
        //    }
        //    return File(foto, "image/jpg");

        //}

        public IActionResult ObterCategoriasProdutos()
        {
            CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();
            return Json(produtoCN.ObterCategorias());
        }

        public IActionResult Pesquisar(string prodNome)
        {
            List<Models.Produto> produtos = null;
            List<object> produtosLimpos = null;
            CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN(); ;
            string msg = null;
            bool operacao = false;

            if (prodNome == null)
                prodNome = "";

            (operacao, msg, produtos) = produtoCN.Pesquisar(prodNome);

            //filtrar quantidade de estoque, pois é pesquisa é para o comprador
            if(produtos != null && produtos.Count > 0)
            {
                produtosLimpos = new List<object>();

                foreach (var prod in produtos)
                {
                    produtosLimpos.Add(new
                    {
                        Cod=prod.Cod,
                        Nome=prod.Nome,
                        Descricao= prod.Descricao,
                        Valor=prod.Valor,
                        Estrelas=prod.Estrelas,
                        Categoria=prod.Categoria,
                    });
                }
            }


            return Json(new {
                operacao, 
                msg,
                produtos=produtosLimpos
            });
        }

        [HttpDelete]
        public IActionResult ExcluirProduto(int cod)
        {
            CamadaNegocio.ProdutoCN produtoCN = new CamadaNegocio.ProdutoCN();
            bool operacao = false;

            if (cod != null)
            {
                operacao = produtoCN.Excluir(cod);
            }

            return Json(new
            {
                operacao
            });
        }

    }
}