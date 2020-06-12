using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEventos
{
    class VerificarAcesso
    {
        //classe para verificar dados de um usuario existente
        public bool estadoAcesso = false;
        public String mensagem = "";
        SqlCommand comando = new SqlCommand();
        Conexao conexao = new Conexao();
        SqlDataReader dataReader;

        public bool Verifica(String email, String senha)
        {
            //verifica se os dados recebidos existem no banco de dados
            comando.CommandText = "select * from dados_usuarios where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);

            try
            {
                //tenta abrir um conexao
                comando.Connection = conexao.AbrirConexao();
                dataReader = comando.ExecuteReader();

                //se os dados do usuário existirem
                if (dataReader.HasRows)
                {
                    estadoAcesso = true;
                }
            }
            catch (SqlException)
            {
                //caso ocorra algum erro do banco de dados
                this.mensagem = "Erro no banco de dados.";
            }

            return estadoAcesso;
        }
    }
}
