using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TesteUiDemo
{
    public partial class UCQr : UserControl
    {
        
        private int counter = 60;
        public UCQr()
        {
            InitializeComponent();
            txt2.Visible = false;
            txt3.Visible = false;
            if (string.IsNullOrWhiteSpace(txt1.Text))
            {
                btnQr.Enabled = false;
            }

        }

        private void btnQr_Click(object sender, EventArgs e)
        {

   
            String source = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=bdSistemaEscolar;Integrated Security=True";
            SqlConnection con = new SqlConnection(source);
            con.Open();

            String sqlSelectQuery = "SELECT tb_curso.nome, tb_aluno.nome FROM tb_curso INNER JOIN tb_aluno ON tb_curso.idCurso = FK_idCurso WHERE idAluno =  " + int.Parse(txt1.Text);

            SqlCommand cmd = new SqlCommand(sqlSelectQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txt2.Text = "Nome: " + (dr["nome"].ToString());
                txt3.Text = "Curso: " +(dr["nome"].ToString());
            }

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txt2.Text +
                  txt3.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            pcbQr.Image = code.GetGraphic(5);

            timer2.Interval = 10000;
            timer2.Tick += timer2_Tick;
            timer2.Start();


            btnQr.Enabled = false;
            txt1.Visible = false;
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt1.Text))
            {
                btnQr.Enabled = false;
            }
            else
            {
                btnQr.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            TelaPrincipal tela = new TelaPrincipal();
            pcbQr.Visible = false;
            timer2.Stop();
            
            tela.Show();
        }
    }
}