using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEventos
{
    class CriarCadastro
    {
        //classe para efetuar cadastro de dados
        public bool estadoCadastro = false, estadoDados = true;
        public String mensagem = "";

        public bool Verifica(String usuario, String email)
        {
            SqlCommand comando1 = new SqlCommand();
            SqlCommand comando2 = new SqlCommand();
            Conexao conexao = new Conexao();
            SqlDataReader dataReader;

            //verifica se os dados recebidos existem no banco de dados
            comando1.CommandText = "select * from dados_usuarios where usuario = @usuario";
            comando2.CommandText = "select * from dados_usuarios where email = @email";
            comando1.Parameters.AddWithValue("@usuario", usuario);
            comando2.Parameters.AddWithValue("@email", email);

            try
            {
                //tenta abrir uma conexao
                comando1.Connection = conexao.AbrirConexao();
                comando2.Connection = conexao.AbrirConexao();
                dataReader = comando1.ExecuteReader();

                //se os dados do usuário existirem
                if (dataReader.HasRows)
                {
                    estadoDados = false;
                }
                dataReader.Close();
                dataReader = comando2.ExecuteReader();

                if(dataReader.HasRows)
                {
                    estadoDados = false;
                }

            }
            catch (SqlException)
            {
                //caso ocorra algum erro do banco de dados
                this.mensagem = "Erro no banco de dados.";
            }

            return estadoDados;
        }

        public bool Cadastra(String usuario, String email, String senha)
        {
            SqlCommand comando = new SqlCommand();
            Conexao conexao = new Conexao();

            //insere os dados recebidos no banco de dados
            comando.CommandText = "insert into dados_usuarios values (@usuario, @email, @senha)";
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);

            try
            {
                //tenta abrir um conexao
                comando.Connection = conexao.AbrirConexao();
                comando.ExecuteReader();

                estadoCadastro = true;
            }
            catch (SqlException)
            {
                //caso ocorra algum erro do banco de dados
                this.mensagem = "Erro no banco de dados.";
            }

            return estadoCadastro;
        }
    }
}
