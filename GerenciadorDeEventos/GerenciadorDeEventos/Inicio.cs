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
            if (!usuarioAcesso.Text.Equals("Usuário") && !senhaAcesso.Text.Equals("Senha"))
            {
                Controle controle = new Controle();
                controle.Acesso(usuarioAcesso.Text, senhaAcesso.Text);

                if (controle.mensagem.Equals(""))
                {
                    if (controle.estadoAcesso)
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
            else
            {
                MessageBox.Show("Preencha todos os campos", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cadastro_Click(object sender, EventArgs e)
        {
            if (!usuarioCadastro.Text.Equals("Usuário") && !emailCadastro.Text.Equals("Seu melhor email") && !senhaCadastro.Text.Equals("Nova senha") && !confSenhaCadastro.Text.Equals("Confirmação de senha"))
            {
                if (senhaCadastro.Text == confSenhaCadastro.Text)
                {
                    Controle controle = new Controle();
                    controle.Cadastro(usuarioCadastro.Text, emailCadastro.Text, senhaCadastro.Text);

                    if (controle.mensagem.Equals(""))
                    {
                        if (controle.estadoCadastro)
                        {
                            MessageBox.Show("Sucesso", "Cadastrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Os dados inseridos já pertencem a outra conta", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            else
            {
                MessageBox.Show("Preencha todos os campos", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximizarDiminuir_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                areaTitulo.Location = new Point(460, 100);
                areaInteracao.Location = new Point(400, 250);
                maximizarDiminuir.BackgroundImage = new Bitmap(GerenciadorDeEventos.Properties.Resources._201_browsers);
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                areaTitulo.Location = new Point(133, 25);
                areaInteracao.Location = new Point(52, 99);
                maximizarDiminuir.BackgroundImage = new Bitmap(GerenciadorDeEventos.Properties.Resources._201_browser);
            }
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void usuarioAcesso_Click(object sender, EventArgs e)
        {
            if (usuarioAcesso.Text == "Usuário")
            {
                usuarioAcesso.ForeColor = Color.FromArgb(64, 64, 64);
                usuarioAcesso.Text = "";
            }
        }

        private void usuarioAcesso_Validated(object sender, EventArgs e)
        {
            if (usuarioAcesso.Text == "")
            {
                usuarioAcesso.ForeColor = Color.Gray;
                usuarioAcesso.Text = "Usuário";
            }
        }

        private void senhaAcesso_Click(object sender, EventArgs e)
        {
            if (senhaAcesso.Text == "Senha")
            {
                senhaAcesso.ForeColor = Color.FromArgb(64, 64, 64);
                senhaAcesso.UseSystemPasswordChar = true;
                senhaAcesso.Text = "";
            }
        }

        private void senhaAcesso_Validated(object sender, EventArgs e)
        {
            if (senhaAcesso.Text == "")
            {
                senhaAcesso.ForeColor = Color.Gray;
                senhaAcesso.Text = "Senha";

                if (senhaAcesso.Text == "Senha")
                {
                    senhaAcesso.UseSystemPasswordChar = false;
                }
            }
        }

        private void usuarioCadastro_Click(object sender, EventArgs e)
        {
            if (usuarioCadastro.Text == "Usuário")
            {
                usuarioCadastro.ForeColor = Color.FromArgb(64, 64, 64);
                usuarioCadastro.Text = "";
            }
        }

        private void usuarioCadastro_Validated(object sender, EventArgs e)
        {
            if (usuarioCadastro.Text == "")
            {
                usuarioCadastro.ForeColor = Color.Gray;
                usuarioCadastro.Text = "Usuário";
            }
        }

        private void emailCadastro_Click(object sender, EventArgs e)
        {
            if (emailCadastro.Text == "Seu melhor email")
            {
                emailCadastro.ForeColor = Color.FromArgb(64, 64, 64);
                emailCadastro.Text = "";
            }
        }

        private void emailCadastro_Validated(object sender, EventArgs e)
        {
            if (emailCadastro.Text == "")
            {
                emailCadastro.ForeColor = Color.Gray;
                emailCadastro.Text = "Seu melhor email";
            }
        }

        private void senhaCadastro_Click(object sender, EventArgs e)
        {
            if (senhaCadastro.Text == "Nova senha")
            {
                senhaCadastro.ForeColor = Color.FromArgb(64, 64, 64);
                senhaCadastro.UseSystemPasswordChar = true;
                senhaCadastro.Text = "";
            }
        }

        private void senhaCadastro_Validated(object sender, EventArgs e)
        {
            if (senhaCadastro.Text == "")
            {
                senhaCadastro.Text = "Nova senha";

                if (senhaCadastro.Text == "Nova senha")
                {
                    senhaCadastro.UseSystemPasswordChar = false;
                    senhaCadastro.ForeColor = Color.Gray;
                }
            }
        }

        private void confSenhaCadastro_Click(object sender, EventArgs e)
        {
            if (confSenhaCadastro.Text == "Confirmação de senha")
            {
                confSenhaCadastro.ForeColor = Color.FromArgb(64, 64, 64);
                confSenhaCadastro.UseSystemPasswordChar = true;
                confSenhaCadastro.Text = "";
            }
        }

        private void confSenhaCadastro_Validated(object sender, EventArgs e)
        {
            if (confSenhaCadastro.Text == "")
            {
                confSenhaCadastro.Text = "Confirmação de senha";

                if (confSenhaCadastro.Text == "Confirmação de senha")
                {
                    confSenhaCadastro.UseSystemPasswordChar = false;
                    confSenhaCadastro.ForeColor = Color.Gray;
                }
            }
        }
    }
}
