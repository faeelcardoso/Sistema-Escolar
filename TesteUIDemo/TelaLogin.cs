using System;
using Modelo;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TesteUiDemo
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO:")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO:";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            if (txtSenha.Text == "SENHA:")
            {
                txtSenha.Text = "";
                txtSenha.ForeColor = Color.LightGray;
                txtSenha.UseSystemPasswordChar = true;
                ;
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text == "")
            {
                txtSenha.Text = "SENHA:";
                txtSenha.ForeColor = Color.DimGray;
                txtSenha.UseSystemPasswordChar = false;
            }
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void TelaLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 15)
            {
                Controle controle = new Controle();
                controle.acessar(txtUsuario.Text, txtSenha.Text);
            
                if (controle.mensagem.Equals(""))
                {
                    if (controle.ok)
                    {
                        MessageBox.Show("Logado com sucesso",
                                        "Entrando",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        TelaPrincipal Tela = new TelaPrincipal();
                        Tela.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login não encontrado, Verifique o Login e Senha",
                                        "ERRO!",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(controle.mensagem);
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(txtUsuario.Text, txtSenha.Text);

            if (controle.mensagem.Equals(""))
            {
                if (controle.ok)
                {
                    MessageBox.Show("Logado com sucesso",
                                    "Entrando",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Hide();
                    TelaWelcome welcome = new TelaWelcome();
                    welcome.ShowDialog();
                    TelaPrincipal Tela = new TelaPrincipal();
                    Tela.Show();
                }
                else
                {
                    txtSenha.Text = "";
                    txtUsuario.Focus();
                    MessageBox.Show("Login não encontrado, Verifique o Login e Senha",
                                    "ERRO!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
    }
}