using System;
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
    public partial class UCGerenciarMatricula : UserControl
    {
        public UCGerenciarMatricula()
        {
            InitializeComponent();
        }

        public void listarAlunos()
        {
            dataGridAlunosMatri.DataSource = new Aluno().Select();
        }

        private void btnNovaMatricula_Click(object sender, EventArgs e)
        {
            if (!TelaPrincipal.Instance.PnlContainer.Controls.ContainsKey("UCNovaMatricula"))
            {
                UCNovaMatricula un = new UCNovaMatricula();
                un.Dock = DockStyle.Fill;
                TelaPrincipal.Instance.PnlContainer.Controls.Add(un);
            }
            TelaPrincipal.Instance.PnlContainer.Controls["UCNovaMatricula"].BringToFront();
            TelaPrincipal.Instance.BackButton.Visible = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar os campos//

            txtNomeComp.Text = "";
            txtEmail.Text = "";
            txtNomeM.Text = "";
            txtNomeP.Text = "";
            txtTelefone.Text = "";
            dtpDataNascEdit.Text = "";
            txtRua.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtCep.Text = "";
            cbEstadoEdit.Text = "";

            //Limpar os Error Provider//

            epNome.SetError(txtNomeComp, "");
            epEmail.SetError(txtEmail, "");
            epMae.SetError(txtNomeM, "");
            epPai.SetError(txtNomeP, "");
            epTelefone.SetError(txtTelefone, "");
            epDataNasc.SetError(dtpDataNascEdit, "");
            epRua.SetError(txtRua, "");
            epBairro.SetError(txtBairro, "");
            epCidade.SetError(txtCidade, "");
            epCep.SetError(txtCep, "");
            epEstado.SetError(cbEstadoEdit, "");
        }

        private void UCGerenciarMatricula_Load(object sender, EventArgs e)
        {
            pnlEditarDados.Visible = false;
            this.listarAlunos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbEstadoEdit.SelectedIndex = -1;
            txtNomeComp.Focus();
            pnlEditarDados.Visible = true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            pnlEditarDados.Visible = false;

            if (!txtId.Text.Trim().Equals("") && !txtNomeComp.Text.Equals("") && !txtNomeP.Text.Equals("")
            && !txtNomeM.Text.Equals("") && !txtEmail.Text.Equals("") && !txtTelefone.Equals("")
            && !txtCep.Text.Equals("") && !txtRua.Text.Equals("") && !txtBairro.Text.Equals("")
            && !txtCidade.Text.Equals("") && !cbEstadoEdit.Text.Equals(""))
            {

                Aluno aluno = new Aluno();
                //Como converter em INT
                aluno.IdAluno = int.Parse(txtId.Text);
                aluno.Nome = txtNomeComp.Text;
                aluno.NomeP = txtNomeP.Text;
                aluno.NomeM = txtNomeM.Text;
                aluno.Email = txtEmail.Text;
                aluno.Telefone = txtTelefone.Text;
                aluno.Cep = txtCep.Text;
                aluno.Rua = txtRua.Text;
                aluno.Bairro = txtBairro.Text;
                aluno.Cidade = txtCidade.Text;
                aluno.Estado = cbEstadoEdit.Text;
                aluno.DataNasc = dtpDataNascEdit.Text;

                if (aluno.Update())
                {
                    MessageBox.Show(
                        "Aluno Atualizado com sucesso!",
                        "Aviso!!!", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );

                    txtId.Clear();
                    txtNomeComp.Clear();
                    txtNomeP.Clear();
                    txtNomeM.Clear();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    txtCep.Clear();
                    txtRua.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();
                    dtpDataNascEdit.Value = DateTime.Today;
                    cbEstadoEdit.SelectedIndex = -1;

                    dataGridAlunosMatri.DataSource = new Aluno().Select();
                }
                else
                {
                    MessageBox.Show(
                       "Falha ao atualizar o Aluno!",
                       "AVISO!!", MessageBoxButtons.OK, MessageBoxIcon.Hand
                    );
                    txtId.Clear();
                    txtNomeComp.Clear();
                    txtNomeP.Clear();
                    txtNomeM.Clear();
                    txtEmail.Clear();
                    txtTelefone.Clear();
                    txtCep.Clear();
                    txtRua.Clear();
                    txtBairro.Clear();
                    txtCidade.Clear();
                    dtpDataNascEdit.Value = DateTime.Today;
                }
            }
        }

        private void dataGridAlunosMatri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridAlunosMatri.CurrentRow.Cells[0].Value.ToString();
            txtNomeComp.Text = dataGridAlunosMatri.CurrentRow.Cells[1].Value.ToString();
            txtNomeM.Text = dataGridAlunosMatri.CurrentRow.Cells[3].Value.ToString();
            txtNomeP.Text = dataGridAlunosMatri.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataGridAlunosMatri.CurrentRow.Cells[14].Value.ToString();
            txtCidade.Text = dataGridAlunosMatri.CurrentRow.Cells[12].Value.ToString();
            txtBairro.Text = dataGridAlunosMatri.CurrentRow.Cells[11].Value.ToString();
            txtCep.Text = dataGridAlunosMatri.CurrentRow.Cells[9].Value.ToString();
            txtRua.Text = dataGridAlunosMatri.CurrentRow.Cells[10].Value.ToString();
            txtTelefone.Text = dataGridAlunosMatri.CurrentRow.Cells[4].Value.ToString();
            cbEstadoEdit.Text = dataGridAlunosMatri.CurrentRow.Cells[13].Value.ToString();
            dtpDataNascEdit.Text = dataGridAlunosMatri.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnVoltarEditar_Click(object sender, EventArgs e)
        {
            cbEstadoEdit.SelectedIndex = -1;
            txtId.Clear();
            txtNomeComp.Clear();
            txtNomeM.Clear();
            txtNomeP.Clear();
            txtEmail.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtCep.Clear();
            txtRua.Clear();
            txtTelefone.Clear();
            dtpDataNascEdit.Value = DateTime.Today;
            pnlEditarDados.Visible = false;
        }
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string constring = @"Data Source=PE03Z28Z\SQLEXPRESS;Initial Catalog=bdSistemaEscolar;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constring);

            connection.Open();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM  tb_aluno WHERE nome like ('" + txtPesquisar.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridAlunosMatri.DataSource = dt;

            connection.Close();

        }
        private void txtPesquisar_MouseClick(object sender, MouseEventArgs e)
        {
            txtPesquisar.Text = "";
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
            if (string.IsNullOrEmpty(txtEmail.Text))
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

        private void dtpDataNascEdit_Leave(object sender, EventArgs e)
        {
            if ((DateTime.Now.Subtract(dtpDataNascEdit.Value).Days) / (365) < 15)
            {
                epDataNasc.Icon = Properties.Resources.Erro;
                epDataNasc.SetError(dtpDataNascEdit, "O aluno deve ter pelo menos 15 anos");
            }
            else
            {
                epDataNasc.Icon = Properties.Resources.Check;
                epDataNasc.SetError(dtpDataNascEdit, "OK");
            }
        }

        private void txtNomeM_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeM.Text))
            {
                epMae.Icon = Properties.Resources.Erro;
                epMae.SetError(txtNomeM, "Informe o nome da sua Mãe");
            }
            else
            {
                epMae.Icon = Properties.Resources.Check;
                epMae.SetError(txtNomeM, "OK");
            }
        }

        private void txtNomeP_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeP.Text))
            {
                epPai.Icon = Properties.Resources.Erro;
                epPai.SetError(txtNomeP, "Informe o nome do seu Pai");
            }
            else
            {
                epPai.Icon = Properties.Resources.Check;
                epPai.SetError(txtNomeP, "OK");
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

        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCep.Text))
            {
                epCep.Icon = Properties.Resources.Erro;
                epCep.SetError(txtCep, "Informe o seu CEP");             
            }
            else
            {
                epCep.Icon = Properties.Resources.Check;
                epCep.SetError(txtCep, "OK");
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

        private void cbEstadoEdit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbEstadoEdit.Text))
            {
                epEstado.Icon = Properties.Resources.Erro;
                epEstado.SetError(cbEstadoEdit, "Informe o seu estado");
            }
            else
            {
                epEstado.Icon = Properties.Resources.Check;
                epEstado.SetError(cbEstadoEdit, "OK");
            }
        }

        //Faz com que a mensagem de erro suma ao inserir um caractere na TextBox//
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Bloqueia letras//

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            {
                //Bloqueia a tecla espaço//

                if (e.KeyChar == ' ') e.Handled = true;
            }
        }

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

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            epTelefone.SetError(txtTelefone, "");

            {
                if (e.KeyChar == ' ') e.KeyChar = (char)0;
            }
        }

        private void txtNomeM_KeyPress(object sender, KeyPressEventArgs e)
        {
            epNome.SetError(txtNomeComp, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
            }
        }

        private void txtNomeP_KeyPress(object sender, KeyPressEventArgs e)
        {
            epNome.SetError(txtNomeComp, "");

            if (!char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
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

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        //Bloqueia escrita em Combo Box//

        private void cbEstadoEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            epEstado.SetError(cbEstadoEdit, "");

            e.Handled = true;
        }
    }
}