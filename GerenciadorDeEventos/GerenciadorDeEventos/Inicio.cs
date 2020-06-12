using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerenciadorDeEventos
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void acesso_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.Acesso(usuarioAcesso.Text, senhaAcesso.Text);

            if (controle.mensagem.Equals(""))
            {
                if(controle.estadoAcesso)
            {
                    MessageBox.Show("Sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dados incorretos", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Ocorreu um erro", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cadastro_Click(object sender, EventArgs e)
        {
            if (senhaCadastro.Text == confSenhaCadastro.Text)
            {
                Controle controle = new Controle();
                controle.Cadastro(usuarioCadastro.Text, emailCadastro.Text, senhaCadastro.Text);
                
                if (controle.mensagem.Equals(""))
                {
                    if (controle.estadoAcesso)
                    {
                        MessageBox.Show("Sucesso", "Cadastrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dados já existem", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ocorreu um erro", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Senhas desiguais", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
