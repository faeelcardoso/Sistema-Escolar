using System;
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
    public partial class TelaPrincipal : Form
    {
        static TelaPrincipal _obj;

        public static TelaPrincipal Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new TelaPrincipal();
                }
                return _obj;
            }
        }
       
        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Button BackButton
        {
            get { return btnBackPrincipal; }
            set { btnBackPrincipal = value; }
        }

        public TelaPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsd, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {
            btnBackPrincipal.Visible = false;
            _obj = this;

            UCTelaPrincipal uc = new UCTelaPrincipal();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["UCTelaPrincipal"].BringToFront();
            btnBackPrincipal.Visible = false;
        }

        private void btnGerenciaMatricula_Click(object sender, EventArgs e)
        {
            if (!TelaPrincipal.Instance.PnlContainer.Controls.ContainsKey("UCGerenciarMatricula"))
            {
                UCGerenciarMatricula un = new UCGerenciarMatricula();
                un.Dock = DockStyle.Fill;
                TelaPrincipal.Instance.PnlContainer.Controls.Add(un);
            }
            TelaPrincipal.Instance.PnlContainer.Controls["UCGerenciarMatricula"].BringToFront();
            TelaPrincipal.Instance.BackButton.Visible = true;
        }

        private void btnArrastaMenu_Click(object sender, EventArgs e)
        {
            if (menuVertical.Width == 230)
            {
                menuVertical.Width = 62;
            }
            else
            {
                menuVertical.Width = 230;
            }
        }

        private void iconFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblData.Text = DateTime.Now.ToLongDateString();
        }

        private void btnYouTube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=KmCYVkY0te4");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/marthinnetto");
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pt-br.facebook.com/ravesbr/");
        }

        private void btnInstagram_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/faeelcardoso/?hl=pt-br");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            if (!TelaPrincipal.Instance.PnlContainer.Controls.ContainsKey("UCCadastroUsuario"))
            {
                UCCadastroUsuario un = new UCCadastroUsuario();
                un.Dock = DockStyle.Fill;
                TelaPrincipal.Instance.PnlContainer.Controls.Add(un);
            }
            TelaPrincipal.Instance.PnlContainer.Controls["UCCadastroUsuario"].BringToFront();
            TelaPrincipal.Instance.BackButton.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!TelaPrincipal.Instance.PnlContainer.Controls.ContainsKey("UCQr"))
            {
                UCQr un = new UCQr();
                un.Dock = DockStyle.Fill;
                TelaPrincipal.Instance.PnlContainer.Controls.Add(un);
            }
            TelaPrincipal.Instance.PnlContainer.Controls["UCQr"].BringToFront();
            TelaPrincipal.Instance.BackButton.Visible = true;
        }
    }
}