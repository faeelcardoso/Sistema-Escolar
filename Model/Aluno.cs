using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    public class Aluno 
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string DataNasc { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Genero { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string NomeM { get; set; }
        public string NomeP { get; set; }
        public int FK_idCurso { get; set; }

        public DataTable Select()
        {
            DataTable aluno = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();                    

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT tb_aluno.idAluno, tb_aluno.nome, tb_aluno.nomeP, tb_aluno.nomeM, tb_aluno.telefone, tb_aluno.dataNasc, tb_aluno.cpf, tb_aluno.rg, tb_aluno.genero, tb_aluno.cep, " +
                                          "tb_aluno.rua, tb_aluno.bairro, tb_aluno.cidade, tb_aluno.estado, tb_aluno.email, tb_curso.nomeC FROM tb_aluno " +
                                          "INNER JOIN tb_curso ON tb_aluno.FK_idCurso = tb_curso.idCurso; ";
                   
                    //ExecuteNonQuery, ExecuteReader, ExecuteScalar
                    //ExecuteReader SELECT com vários (0..N) registros
                    SqlDataReader query = command.ExecuteReader();

                    if (query.HasRows)
                        aluno.Load(query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Erro no Sistema AlunoModel -> Select: {0}",
                        ex.Message
                    ),
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            return aluno;
        }

        public bool Insert()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT idAluno FROM tb_aluno; INSERT INTO tb_aluno ([nome], [nomeP], [nomeM], [email], [telefone], [cpf], [rg], [cep], [rua], [estado], [genero], [bairro], [cidade], [dataNasc],[FK_idCurso]) " +
                                          "VALUES (@nome,@nomeP,@nomeM,@email,@telefone,@cpf,@rg,@cep,@rua,@estado,@genero,@bairro,@cidade,@dataNasc,@FK_idCurso);";

                    //SCOPE_IDENTITY é uma função que retorna o id do último registro inserido

                    command.Parameters.Add("nome", SqlDbType.VarChar).Value =  Nome;
                    command.Parameters.Add("nomeP", SqlDbType.VarChar).Value = NomeP;
                    command.Parameters.Add("nomeM", SqlDbType.VarChar).Value = NomeM;
                    command.Parameters.Add("email", SqlDbType.VarChar).Value = Email;
                    command.Parameters.Add("telefone", SqlDbType.VarChar).Value = Telefone;
                    command.Parameters.Add("cep", SqlDbType.VarChar).Value = Cep;
                    command.Parameters.Add("rua", SqlDbType.VarChar).Value = Rua;
                    command.Parameters.Add("bairro", SqlDbType.VarChar).Value = Bairro;
                    command.Parameters.Add("cidade", SqlDbType.VarChar).Value = Cidade;
                    command.Parameters.Add("estado", SqlDbType.VarChar).Value = Estado;
                    command.Parameters.Add("cpf", SqlDbType.VarChar).Value = Cpf;
                    command.Parameters.Add("rg", SqlDbType.VarChar).Value = Rg;
                    command.Parameters.Add("genero", SqlDbType.VarChar).Value = Genero;
                    command.Parameters.Add("dataNasc", SqlDbType.VarChar).Value = DataNasc;
                    command.Parameters.Add("FK_idCurso", SqlDbType.Int).Value = FK_idCurso;

                    IdAluno = int.Parse(command.ExecuteScalar().ToString());
                    
                    if (IdAluno == 0)
                        return false;

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Erro no Sistema AlunoModel -> Insert: {0}", ex.Message),
                                  "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = Properties.Settings.Default.ConnectionString;
                    connection.Open();

                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE tb_aluno " +
                                          "SET nome = @nome, nomeP = @nomeP, nomeM = @nomeM, dataNasc = @dataNasc, email = @email, telefone = @telefone, cep = @cep, rua = @rua, bairro = @bairro, cidade = @cidade, estado = @estado " +
                                          "WHERE idAluno = @idAluno;";

                    command.Parameters.Add("idAluno", SqlDbType.Int).Value = IdAluno;
                    command.Parameters.Add("nome", SqlDbType.Text).Value = Nome;
                    command.Parameters.Add("nomeP", SqlDbType.Text).Value = NomeP;
                    command.Parameters.Add("nomeM", SqlDbType.Text).Value = NomeM;
                    command.Parameters.Add("email", SqlDbType.Text).Value = Email;
                    command.Parameters.Add("estado", SqlDbType.Text).Value = Estado;
                    command.Parameters.Add("telefone", SqlDbType.Text).Value = Telefone;
                    command.Parameters.Add("cep", SqlDbType.Text).Value = Cep;
                    command.Parameters.Add("rua", SqlDbType.Text).Value = Rua;
                    command.Parameters.Add("bairro", SqlDbType.Text).Value = Bairro;
                    command.Parameters.Add("cidade", SqlDbType.Text).Value = Cidade;
                    command.Parameters.Add("dataNasc", SqlDbType.Date).Value = DataNasc;

                    if (command.ExecuteNonQuery() == 1)
                        return true;

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Erro no sistema AlunoModel -> Update: {0}", ex.Message),
                                  "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}