using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.CamadaAcessoBanco
{
    public class UsuarioBD
    {
        MySQLPersistencia _bd = new MySQLPersistencia();
        
        public bool Criar(Models.Usuario usuario)
        {
            string sql = @"insert into usuario(nome, dataNasc, cpf, end_rua, end_num, end_cep, password, email)
                          values(@nome, @dataNasc, @cpf, @end_rua, @end_num, @end_cep, @password, @email);";

            var param = new Dictionary<string, object>();
            param.Add("@nome", usuario.Nome);
            param.Add("@dataNasc", usuario.DataNasc);
            param.Add("@cpf", usuario.Cpf);
            param.Add("@end_rua", usuario.Endereco.Rua);
            param.Add("@end_num", usuario.Endereco.Num);
            param.Add("@end_cep", usuario.Endereco.Cep);
            param.Add("@password", usuario.Password);
            param.Add("@email", usuario.Email);

            int qndLinhas = _bd.ExecuteNonQuery(sql, param);

            return qndLinhas > 0;
        }

        public bool CheckUsuarioByEmail(Models.Usuario usuario)
        {
            string sql = @"select count(*) as qntd 
                        from usuario where email = @email;";

            var param = new Dictionary<string, object>();
            param.Add("@email", usuario.Email);

            var dt = _bd.ExecutarSelect(sql, param);
            int qntd = Convert.ToInt32(dt.Rows[0]["qntd"]);
            return qntd > 0;
        }

        public Models.Usuario PegarUsuarioByEmail(string email)
        {
            Models.Usuario usuario = null;
            string sql = @"select * 
                        from usuario where email = @email;";

            var param = new Dictionary<string, object>();
            param.Add("@email", email);

            var dt = _bd.ExecutarSelect(sql, param);

            if(dt.Rows.Count == 1)
            {
                usuario = map(dt.Rows[0]);
            }

            return usuario;
        }

        public bool PegarUsuarioByNome(Models.Usuario usuario)
        {
            string sql = @"select count(*) as qntd 
                        from usuario where nome = @nome;";

            var param = new Dictionary<string, object>();
            param.Add("@nome", usuario.Nome);

            var dt = _bd.ExecutarSelect(sql, param);
            int qntd = Convert.ToInt32(dt.Rows[0]["qntd"]);
            return qntd > 0;
        }

        public Models.Usuario Pegar(int cod)
        {
            Models.Usuario usuario = null;
            string sql = @"select * 
                        from usuario where cod = @cod;";

            var param = new Dictionary<string, object>();
            param.Add("@cod", cod);

            var dt = _bd.ExecutarSelect(sql, param);

            usuario = map(dt.Rows[0]);

            return usuario;
        }

        public (bool, Models.Usuario) Validar(Models.Usuario usuario)
        {
            string sql = @"select cod
                            from usuario 
                            where email = @email and 
                            password = @password;";

            var param = new Dictionary<string, object>();
            param.Add("@email", usuario.Email);
            param.Add("@password", usuario.Password);

            var dt = _bd.ExecutarSelect(sql, param);

            int conta = dt.Rows.Count;

            if (conta > 0)
            {
                int cod = Convert.ToInt32(dt.Rows[0]["cod"]);

                usuario = Pegar(cod);
                return (true, usuario);
            }

            return (false, null);
        }

        internal Models.Usuario map(DataRow row)
        {
            Models.Usuario usuario = new Models.Usuario();
            usuario.Cod = Convert.ToInt32(row["cod"]);
            usuario.Email = row["email"].ToString();
            usuario.Password = row["password"].ToString();
            usuario.Nome = row["nome"].ToString();
            usuario.DataNasc = Convert.ToDateTime(row["dataNasc"]);
            usuario.Cpf = row["cpf"].ToString();

            usuario.Endereco = new Models.Endereco();
            usuario.Endereco.Cep = row["end_cep"].ToString();
            usuario.Endereco.Rua = row["end_rua"].ToString();
            usuario.Endereco.Num = Convert.ToInt32(row["end_num"]);

            return usuario;
        }
    }
}
