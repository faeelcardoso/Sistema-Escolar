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
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Custo { get; set; }

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
                    command.CommandText = "INSERT INTO tb_curso ([nome], [custo]) " +
                                          "VALUES (@nome,@custo); SELECT SCOPE_IDENTITY();";
                    //SCOPE_IDENTITY é uma função que retorna o id do último registro inserido

                    command.Parameters.Add("nome", SqlDbType.VarChar).Value = Nome;                   

                    IdCurso = int.Parse(command.ExecuteScalar().ToString());

                    if (IdCurso != 0)
                        return true;

                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("Erro no Sistema CursoModel -> Insert: {0}", ex.Message),
                                  "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return false;
            }
        }
    }
}
