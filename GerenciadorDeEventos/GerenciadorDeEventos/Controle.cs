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
        public bool estadoAcesso = false, estadoDados = false, estadoCadastro;
        public String mensagem = "";

        public bool Acesso(String usuario, String senha)
        {
            //envia os dados do usuário para a verificação
            VerificarAcesso verificarAcesso = new VerificarAcesso();
            estadoAcesso = verificarAcesso.Verifica(usuario, senha);

            //se houver algum erro
            if (!verificarAcesso.Equals(""))
            {
                this.mensagem = verificarAcesso.mensagem;
            }

            return estadoAcesso;
        }

        public bool Cadastro(String usuario, String email, String senha)
        {
            //envia os dados do usuário para a verificação
            CriarCadastro criarCadastro = new CriarCadastro();
            estadoDados = criarCadastro.Verifica(usuario, email);

            if (estadoDados)
            {
                estadoCadastro = criarCadastro.Cadastra(usuario, email, senha);
            }

            //se houver algum erro
            if (!criarCadastro.Equals(""))
            {
                this.mensagem = criarCadastro.mensagem;
            }

            return estadoCadastro;
        }
    }
}
