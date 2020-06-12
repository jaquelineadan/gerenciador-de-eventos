using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEventos
{
    class Conexao
    {
        //classe para estabelecer uma conexão com o banco de dados
        SqlConnection conexao = new SqlConnection();

        public Conexao()
        {
            conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=BancoGE;Integrated Security=True";
        }

        public SqlConnection AbrirConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
            {
                conexao.Open();
            }
            return conexao;
        }

        public SqlConnection FecharConexao()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
            return conexao;
        }
    }
}
