using Model.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Controle
    {
        public bool ok;
        public String mensagem = "";

        public bool acessar(String nome, String senha)
        {
            CodigoLogin conexao = new CodigoLogin();
            ok = conexao.verificarLogin(nome, senha);
            return ok;

            if (!conexao.mensagem.Equals(""))
            {
                this.mensagem = conexao.mensagem;
            }
            return ok;
        }
    }
}