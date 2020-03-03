using System;
using Correios;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Data.SqlClient;

namespace TesteUiDemo
{
    public partial class UCNovaMatricula : UserControl
    {

        public UCNovaMatricula()
        {
            InitializeComponent();
        }

        private void btnCasdastrarMatricula_Click(object sender, EventArgs e)
        {
            //Maskedtext into datagridview estudar!
            TelaPrincipal.Instance.PnlContainer.Controls.Clear();

            if (!txtNomeComp.Text.Trim().Equals("") && !txtNomeMae.Text.Equals("") && !txtNomePai.Text.Equals("") && !txtEmail.Text.Equals("")
                && !txtRua.Text.Equals("") && !txtCidade.Text.Equals("") && !txtBairro.Text.Equals("") && !txtCep.Text.Equals("")
                && !txtTelefone.Text.Equals("") && !txtCpf.Text.Equals("") && !txtRg.Text.Equals("") && !dtpDataNascimento.Text.Equals(""))
            {
                Aluno aluno = new Aluno();

                aluno.Nome = txtNomeComp.Text;
                aluno.NomeP = txtNomePai.Text;
                aluno.NomeM = txtNomeMae.Text;
                aluno.Email = txtEmail.Text;
                aluno.Rua = txtRua.Text;
                aluno.Cidade = txtCidade.Text;
                aluno.Bairro = txtBairro.Text;
                aluno.Cep = txtCep.Text;
                aluno.Estado = cbEstado.Text;
                aluno.Telefone = txtTelefone.Text;
                aluno.Cpf = txtCpf.Text;
                aluno.Rg = txtRg.Text;
                aluno.DataNasc = dtpDataNascimento.Text;
                aluno.Genero = cbGenero.Text;
                aluno.FK_idCurso = (int)cbCurso.SelectedValue;

                if (aluno.Insert())
                {
                    MessageBox.Show(
                        "Registro inserido com sucesso!",
                        "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

                    txtNomeComp.Clear();
                    txtNomePai.Clear();
                    txtNomeMae.Clear();
                    txtEmail.Clear();
                    txtRua.Clear();
                    txtCidade.Clear();
                    txtBairro.Clear();
                    txtCep.Clear();
                    txtTelefone.Clear();
                    txtCpf.Clear();
                    txtRg.Clear();
                    cbEstado.SelectedIndex = -1;
                    cbGenero.SelectedIndex = -1;
                    cbCurso.SelectedIndex = -1;

                    dtpDataNascimento.Value = DateTime.Today;

                    txtNomeComp.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Falha ao inserir o registro!",
                        "AVISO!!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar os campos//

            txtNomeComp.Text = "";
            txtEmail.Text = "";
            txtNomeMae.Text = "";
            txtNomePai.Text = "";
            txtTelefone.Text = "";
            txtCpf.Text = "";
            txtRg.Text = "";
            dtpDataNascimento.Text = "";
            txtRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCep.Text = "";
            cbEstado.Text = "";
            cbGenero.Text = "";
            cbCurso.Text = "";

            //Limpar os Error Provider//

            epNome.SetError(txtNomeComp, "");
            epEmail.SetError(txtEmail, "");
            epMae.SetError(txtNomeMae, "");
            epPai.SetError(txtNomePai, "");
            epTelefone.SetError(txtTelefone, "");
            epCpf.SetError(txtCpf, "");
            epRg.SetError(txtRg, "");
            epDataNasc.SetError(dtpDataNascimento, "");
            epRua.SetError(txtRua, "");
            epBairro.SetError(txtBairro, "");
            epCidade.SetError(txtCidade, "");
            epCep.SetError(txtCep, "");
            epEstado.SetError(cbEstado, "");
            epGenero.SetError(cbGenero, "");
            epCurso.SetError(cbCurso, "");
        }
        
        private void groupBox4_Enter(object sender, EventArgs e)
        {
            cbCurso.SelectedIndex = -1;
            cbGenero.SelectedIndex = -1;
            //Código combobox
            cbCurso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurso.SelectedText = "";

            string constring = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bdSistemaEscolar;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM tb_curso;";

            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Columns.Add("idCurso", typeof(int));
            dt.Columns.Add("nome", typeof(string));

            dt.Load(reader);

            cbCurso.ValueMember = "idCurso";
            cbCurso.DisplayMember = "nomec";
            cbCurso.DataSource = dt;

            con.Close();

        }

        //------------ERROR PROVIDER------------//

        //Ao clicar na TextBox, a barra de digitação vai pro início//

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtTelefone.Select(0, 0);
            }
            );
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtCpf.Select(0, 0);
            }
            );
        }

        private void txtRg_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtRg.Select(0, 0);
            }
            );
        }

        private void txtCep_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txtCep.Select(0, 0);
            }
            );
        }

        //ErrorProvider para verificar se os campos estão vazios, entre outros erros//

        private void txtNomeComp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeComp.Text))
            {
                epNome.Icon = Properties.Resources.Erro;
                epNome.SetError(txtNomeComp, "Informe o seu nome");
            }
            else
            {
                epNome.Icon = Properties.Resources.Check;
                epNome.SetError(txtNomeComp, "OK");
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeComp.Text))
            {
                epEmail.Icon = Properties.Resources.Erro;
                epEmail.SetError(txtEmail, "Informe o seu e-mail");
            }
            else
            {
                epEmail.Icon = Properties.Resources.Check;
                epEmail.SetError(txtEmail, "OK");
            }
        }

        private void txtNomeMae_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeMae.Text))
            {
                epMae.Icon = Properties.Resources.Erro;
                epMae.SetError(txtNomeMae, "Informe o nome da sua Mãe");
            }
            else
            {
                epMae.Icon = Properties.Resources.Check;
                epMae.SetError(txtNomeMae, "OK");
            }
        }

        private void txtNomePai_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomePai.Text))
            {
                epPai.Icon = Properties.Resources.Erro;
                epPai.SetError(txtNomePai, "Informe o nome do seu Pai");
            }
            else
            {
                epPai.Icon = Properties.Resources.Check;
                epPai.SetError(txtNomePai, "OK");
            }
        }

        private void txtRua_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRua.Text))
            {
                epRua.Icon = Properties.Resources.Erro;
                epRua.SetError(txtRua, "Informe a sua rua");
            }
            else
            {
                epRua.Icon = Properties.Resources.Check;
                epRua.SetError(txtRua, "OK");
            }
        }

        private void txtCidade_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCidade.Text))
            {
                epCidade.Icon = Properties.Resources.Erro;
                epCidade.SetError(txtCidade, "Informe a sua cidade");
            }
            else
            {
                epCidade.Icon = Properties.Resources.Check;
                epCidade.SetError(txtCidade, "OK");
            }
        }

        private void txtBairro_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBairro.Text))
            {
                epBairro.Icon = Properties.Resources.Erro;
                epBairro.SetError(txtBairro, "Informe o seu bairro");
            }
            else
            {
                epBairro.Icon = Properties.Resources.Check;
                epBairro.SetError(txtBairro, "OK");
            }
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            if (txtTelefone.MaskCompleted)
            {
                epTelefone.Icon = Properties.Resources.Check;
                epTelefone.SetError(txtTelefone, "OK");
            }
            else
            {
                epTelefone.Icon = Properties.Resources.Erro;
                epTelefone.SetError(txtTelefone, "Informe o seu telefone");
            }
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            if (txtCpf.MaskCompleted)
            {
                epCpf.Icon = Properties.Resources.Check;
                epCpf.SetError(txtCpf, "OK");
            }
            else
            {
                epCpf.Icon = Properties.Resources.Erro;
                epCpf.SetError(txtCpf, "Informe o seu CPF");
            }
        }

        private void txtRg_Leave(object sender, EventArgs e)
        {
            if (txtRg.MaskCompleted)
            {
                epRg.Icon = Properties.Resources.Check;
                epRg.SetError(txtRg, "OK");
            }
            else
            {
                epRg.Icon = Properties.Resources.Erro;
                epRg.SetError(txtRg, "Informe o seu RG");
            }
        }

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (txtCep.MaskCompleted)
            {
                epCep.Icon = Properties.Resources.Check;
                epCep.SetError(txtCep, "OK");
            }
            else
            {
                epCep.Icon = Properties.Resources.Erro;
                epCep.SetError(txtCep, "Informe o seu CEP");
            }

            if (string.IsNullOrEmpty(txtCep.Text))
            {
                epCep.Icon = Properties.Resources.Erro;
                epCep.SetError(txtCep, "Informe o seu CEP");
            }
            else
            {
                CorreiosApi correiosApi = new CorreiosApi();
                var retorno = correiosApi.consultaCEP(txtCep.Text);

                if (retorno == null)
                {
                    epCep.Icon = Properties.Resources.Erro;
                    epCep.SetError(txtCep, "CEP não encontrado!!");
                    return;
                }         

                txtBairro.Text = retorno.bairro;
                txtCidade.Text = retorno.cidade;
                txtRua.Text = retorno.end;
                cbEstado.Text = retorno.uf;             
            }
        }

        private void dtpDataNascimento_Leave(object sender, EventArgs e)
        {
            if ((DateTime.Now.Subtract(dtpDataNascimento.Value).Days) / (365) < 15)
            {
                epDataNasc.Icon = Properties.Resources.Erro;
                epDataNasc.SetError(dtpDataNascimento, "O aluno deve ter pelo menos 15 anos");
            }
            else
            {
                epDataNasc.Icon = Properties.Resources.Check;
                epDataNasc.SetError(dtpDataNascimento, "OK");
            }
        }

        private void cbEstado_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstado.Text))
            {
                epEstado.Icon = Properties.Resources.Erro;
                epEstado.SetError(cbEstado, "Informe o seu estado");
            }
            else
            {
                epEstado.Icon = Properties.Resources.Check;
                epEstado.SetError(cbEstado, "OK");
            }
        }

        private void cbGenero_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbGenero.Text))
            {
                epGenero.Icon = Properties.Resources.Erro;
                epGenero.SetError(cbGenero, "Informe o seu gênero");
            }
            else
            {
                epGenero.Icon = Properties.Resources.Check;
                epGenero.SetError(cbGenero, "OK");
            }
        }

        //Faz com que a mensagem de erro suma ao inserir um caractere na TextBox//

        private void txtNomeComp_KeyPress(object sender, KeyPressEventArgs e)
        {
            epNome.SetError(txtNomeComp, "");

            //Bloqueia números//

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            epEmail.SetError(txtEmail, "");

            {
                //Bloqueia a tecla espaço//

                if (e.KeyChar == ' ') e.Handled = true;
            }
        }

        private void txtNomeMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            epNome.SetError(txtNomeComp, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtNomePai_KeyPress(object sender, KeyPressEventArgs e)
        {
            epNome.SetError(txtNomeComp, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            epTelefone.SetError(txtTelefone, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            epCpf.SetError(txtCpf, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        private void txtRg_KeyPress(object sender, KeyPressEventArgs e)
        {
            epRg.SetError(txtRg, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            epRua.SetError(txtRua, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            epBairro.SetError(txtBairro, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            epCidade.SetError(txtCidade, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            epCep.SetError(txtCep, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        //Bloqueia escrita em Combo Box//

        private void cbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            epEstado.SetError(cbEstado, "");

            e.Handled = true;
        }

        private void cbGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            epGenero.SetError(cbGenero, "");

            e.Handled = true;
        }

        private void cbCurso_KeyPress(object sender, KeyPressEventArgs e)
        {
            epCurso.SetError(cbCurso, "");

            e.Handled = true;
        }
    }
}