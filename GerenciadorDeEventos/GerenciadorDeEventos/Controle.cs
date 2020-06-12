using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEventos
{
    class Controle
    {
        //classe para auxiliar na troca de dados
        public bool estadoAcesso;
        public String mensagem = "";

        public bool Acesso(String email, String senha)
        {
            //envia os dados do usuário para a verificação
            VerificarAcesso verificarAcesso = new VerificarAcesso();
            estadoAcesso = verificarAcesso.Verifica(email, senha);

            //se houver algum erro
            if (!verificarAcesso.Equals(""))
            {
                this.mensagem = verificarAcesso.mensagem;
            }

            return estadoAcesso;
        }

        public String Cadastro(String usuario, String email, String senha, String confSenha)
        {
            return mensagem;
        }
    }
}
