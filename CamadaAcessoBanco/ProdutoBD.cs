using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaAcessoBanco
{
    public class ProdutoBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();

        public bool Criar(Models.Produto produto)
        {
            string sql = @"insert into produto
                        (nome, descricao, valor, estoque, estrelas, categoria_cod) 
                         value(@nome, @descricao, @valor, @estoque, @estrelas, @categoria_cod);";

            var param = new Dictionary<string, object>();
            param.Add("@nome", produto.Nome);
            param.Add("@descricao", produto.Descricao);
            param.Add("@valor", produto.Valor);
            param.Add("@estoque", produto.Estoque);
            param.Add("@estrelas", produto.Estrelas);
            param.Add("@categoria_cod", produto.Categoria.Cod);

            int qndtExecs = _bd.ExecuteNonQuery(sql, param);

            if(qndtExecs > 0)
            {
                produto.Cod = _bd.UltimoId;
            }

            return qndtExecs > 0;
        }

        public Models.Produto ObterProdutoPorNome(string nome)
        {
            Models.Produto produto = null;
            string sql = @"select 
                                produto.cod, produto.nome, descricao, valor, estoque, estrelas, 
                                categoria.cod as categoria_cod, categoria.nome as categoria_nome
                           from 
                                produto, categoria
                           where 
                                produto.categoria_cod = categoria.cod and
                                produto.nome = @nome";

            var param = new Dictionary<string, object>();
            param.Add("@nome", nome);

            var dt = _bd.ExecutarSelect(sql, param);

            if(dt.Rows.Count > 0)
            {
                produto = Map(dt.Rows[0]);
            }

            return produto;
        }


        public List<Models.Produto> ObterProdutos()
        {
            string sql = @"select 
                            produto.cod, produto.nome, descricao, valor, estoque, estrelas, 
                            categoria.cod as categoria_cod, categoria.nome as categoria_nome
                        from produto, categoria
                        where produto.categoria_cod = categoria.cod
                        order by nome;";

            List<Models.Produto> produtos = null;

            var dt = _bd.ExecutarSelect(sql);

            if (dt.Rows.Count > 0)
            {
                produtos = new List<Models.Produto>();

                foreach (DataRow row in dt.Rows)
                {
                    produtos.Add(Map(row));
                }
            }

            return produtos;
        }

        public int obterQntdFotos(int codProd)
        {
            string sql = @"select count(*) as qntd from fotos where produto_cod = " + codProd;

            int qntd = 0;

            DataTable dt = _bd.ExecutarSelect(sql);

            if(dt.Rows.Count > 0)
            {
                qntd = Convert.ToInt32(dt.Rows[0]["qntd"]);
            }

            return qntd;
        }

        public Models.CategoriaProduto ObterCategoria(int cod)
        {
            Models.CategoriaProduto categoria = null;
            string sql = @"select categoria.cod as categoria_cod, categoria.nome as categoria_nome
                           from categoria 
                           where cod = @cod;";

            var param = new Dictionary<string, object>();
            param.Add("@cod", cod);

            var dt = _bd.ExecutarSelect(sql, param);

            if(dt.Rows.Count > 0)
            {
                categoria = MapCategoria(dt.Rows[0]);
            }

            return categoria;
        }

        public bool inserirFotosEmProduto(int idProduto, byte[][] fotos)
        {
            string sql = "insert into fotos (numero, foto, produto_cod)" +
                "values(@numero, @foto, @produto_cod)";

            var parametros = new Dictionary<string, object>();
            var parametrosBinarios = new Dictionary<string, byte[]>();
            int qntdLinhasAfetadas = 0;
            
            for(int i=0; i < fotos.Length; i++)
            {
                parametrosBinarios.Add("@foto", fotos[i]);
                parametros.Add("@produto_cod", idProduto);
                parametros.Add("@numero", i+1);

                qntdLinhasAfetadas += _bd.ExecuteNonQuery(sql, parametros, parametrosBinarios);

                parametros.Clear();
                parametrosBinarios.Clear();
            }


            return qntdLinhasAfetadas > 0;

        }

        public List<Models.CategoriaProduto> ObterCategorias()
        {
            string sql = @"select 
                            cod as categoria_cod,
                           nome as categoria_nome
                           from categoria";

            List<Models.CategoriaProduto> categoriaProdutos = null;

            var dt = _bd.ExecutarSelect(sql);

            if (dt.Rows.Count > 0)
            {
                categoriaProdutos = new List<Models.CategoriaProduto>();

                foreach (DataRow row in dt.Rows)
                {
                    categoriaProdutos.Add(MapCategoria(row));
                }
            }

            return categoriaProdutos;
        }

        public byte[] ObterUmaFoto(int id, int numero)
        {
            byte[] retorno = null;

            string sql = @"select foto 
                            from fotos 
                            where produto_cod = " + id + " and " + " numero = " + numero;

            object foto = _bd.ExecutarScalar(sql);

            if(foto != DBNull.Value)
            {
                retorno = (byte[]) foto;
            }

            return retorno;
        }

        //public byte[] ObterFotoDois(int id)
        //{
        //    byte[] retorno = null;

        //    string sql = @"select foto2 
        //                    from produto 
        //                    where cod = " + id;

        //    object foto = _bd.ExecutarScalar(sql);

        //    if (foto != DBNull.Value && foto != null)
        //    {
        //        retorno = (byte[])foto;
        //    }

        //    return retorno;
        //}

        public bool Excluir(int cod)
        {
            string select = @"delete 
                              from produto 
                              where cod = " + cod;

            string selectFotos = @"delete 
                                   from fotos 
                                   where produto_cod = " + cod;

            return _bd.ExecuteNonQuery(selectFotos) > 0 && _bd.ExecuteNonQuery(select) > 0;
        }

        public List<Models.Produto> Pesquisar(string nomeProd)
        {
            string sql = @"select 
                            produto.cod, produto.nome, descricao, valor, estoque, estrelas, 
                            categoria.cod as categoria_cod, categoria.nome as categoria_nome
                        from produto, categoria
                        where 
                            produto.categoria_cod = categoria.cod and
                            produto.nome like @nome  
                        order by nome";

            var param = new Dictionary<string, object>();
            List<Models.Produto> produtos = null;

            param.Add("@nome", "%" + nomeProd + "%");

            var dt = _bd.ExecutarSelect(sql, param);

            if (dt.Rows.Count > 0)
            {
                produtos = new List<Models.Produto>();

                foreach (DataRow row in dt.Rows)
                {
                    produtos.Add(Map(row));
                }
            }

            return produtos;
        }


        internal Models.CategoriaProduto MapCategoria(DataRow row)
        {
            Models.CategoriaProduto categoria = new Models.CategoriaProduto();

            categoria.Cod = Convert.ToInt32(row["categoria_cod"]);
            categoria.Nome = row["categoria_nome"].ToString();

            return categoria;
        }

        internal Models.Produto Map(DataRow row)
        {
            Models.Produto produto = new Models.Produto();
            Models.CategoriaProduto categoria = null;

            produto.Cod = Convert.ToInt32(row["cod"].ToString());
            produto.Nome = row["nome"].ToString();
            produto.Descricao = row["descricao"].ToString();
            produto.Valor = Convert.ToInt32(row["valor"]);
            produto.Estoque = Convert.ToInt32(row["estoque"]);
            produto.Estrelas = Convert.ToInt32(row["estrelas"]);

            produto.Categoria = MapCategoria(row);

            //categoria.Cod = Convert.ToInt32(row["categoria_cod"]);
            //categoria.Nome = row["categoria_nome"].ToString();

            return produto;
        }
    }
}
