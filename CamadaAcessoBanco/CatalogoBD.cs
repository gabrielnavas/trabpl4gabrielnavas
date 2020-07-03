using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaAcessoBanco
{
    public class CatalogoBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();

        public List<Models.Produto> PegarTodos()
        {
            List<Models.Produto> prods = null;

            string sql = @"select * from produto";
            var dt = _bd.ExecutarSelect(sql);

            //if(dt.Rows.Count > 0)
            //{
            //    prods = new List<Models.Produto>();


            //    foreach(var line in dt.Rows)
            //    {
            //        prod = new Models.Produto();
            //        prod.Cod = line["cod"];
            //    }
            //}

            return prods;
        }
    }
}
