using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Benaiah
{
    public class ListaDeRespostas
    {
        public string nomeDaAvaliadora;
        public string setorDaAvaliadora;
        public string nomeAvaliada;
        public string setorAvaliada;
        public string pergunta;
        public string resposta;

        // nomeDaAvaliadora: nome de quem está respondendo o formulário. Tem a palavra "Da".
        // setorDaAvaliadora: setor da funcionária que está respondendo o formulário. Tem a palavra "Da".
        // nomeAvaliada: nome de quem está recebendo o julgamento das colegas de trabalho. Não tem a palavra "Da".
        // setorAvaliada: setor ao qual pertence quem está recebendo o julgamento das colegas de trabalho. Não tem a palavra "Da".
        public ListaDeRespostas(string _nomeDaAvaliadora, string _setorDaAvaliadora, string _nomeAvaliada, string _setorAvaliada, string _pergunta, string _resposta)
        {
            nomeDaAvaliadora = _nomeDaAvaliadora;
            setorDaAvaliadora = _setorDaAvaliadora;
            nomeAvaliada = _nomeAvaliada;
            setorAvaliada = _setorAvaliada;
            pergunta = _pergunta;
            resposta = _resposta;

            GravaRespostasNoBanco(nomeDaAvaliadora, setorDaAvaliadora, nomeAvaliada, setorAvaliada, pergunta, resposta);
        }


        private void GravaRespostasNoBanco(string nomeDaAvaliadora, string setorDaAvaliadora, string nomeAvaliada, string setorAvaliada, string pergunta, string resposta)
        {
            //Versão antiga do banco de dados
            //using (var conexao = new SqlConnection("Server = ULTRABOOK\\SQLEXPRESS; Database = Benaiah; Trusted_Connection = True;"))
            //{
            //    conexao.Open();
            //    SqlCommand sqlContaLinha = new SqlCommand("select count(*) from respostas", conexao);
            //    int qtdeLinhas = (int)sqlContaLinha.ExecuteScalar();
            //    SqlCommand comando = new SqlCommand("insert into Respostas (ID, nomeDaAvaliadora, setorDaAvaliadora, nomeAvaliada, setorAvaliada, pergunta, resposta, DataHoraResposta) values (@id, @nomeDaAvaliadora, @setorDaAvaliadora, @nomeAvaliada, @setorAvaliada, @pergunta, @resposta, GETDATE())", conexao);
            //    comando.Parameters.AddWithValue("id", qtdeLinhas+1);
            //    comando.Parameters.AddWithValue("nomeDaAvaliadora", nomeDaAvaliadora);
            //    comando.Parameters.AddWithValue("setorDaAvaliadora", setorDaAvaliadora);
            //    comando.Parameters.AddWithValue("nomeAvaliada", nomeAvaliada);
            //    comando.Parameters.AddWithValue("setorAvaliada", setorAvaliada);
            //    comando.Parameters.AddWithValue("pergunta", pergunta);
            //    comando.Parameters.AddWithValue("resposta", resposta);
            //    comando.ExecuteNonQuery();
            //}

            #region Nova versão do banco de dados
            BancoDeDados bd = new BancoDeDados();
            using (var conexao = new SqlConnection(bd.StringConexao()))
            {
                conexao.Open();

                //SqlCommand sqlContaLinha = new SqlCommand("select count(*) from resposta", conexao);
                //int qtdeLinhas = (int)sqlContaLinha.ExecuteScalar();

                SqlCommand comando = new SqlCommand("select Funcionaria.IDfunc, Funcionaria.IDsetor from Funcionaria where nome = @nomeDaAvaliadora", conexao);
                comando.Parameters.AddWithValue("@nomeDaAvaliadora", nomeDaAvaliadora);

                int IDfuncAvaliadora = 0;
                int IDsetorAvaliadora = 0;

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        IDfuncAvaliadora = Convert.ToInt16(reader["IDfunc"].ToString().Trim());
                        IDsetorAvaliadora = Convert.ToInt16(reader["IDsetor"].ToString().Trim());
                    }
                }

                comando = new SqlCommand("select Funcionaria.IDfunc, Funcionaria.IDsetor from Funcionaria where nome = @nomeAvaliada", conexao);
                comando.Parameters.AddWithValue("@nomeAvaliada", nomeAvaliada);

                int IDfuncAvaliada = 0;
                int IDsetorAvaliada = 0;

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    { 
                        IDfuncAvaliada = Convert.ToInt16(reader["IDfunc"].ToString().Trim());
                        IDsetorAvaliada = Convert.ToInt16(reader["IDsetor"].ToString().Trim());
                    }
                }

                comando = new SqlCommand("insert into Resposta (IDfuncAvaliadora, IDsetorAvaliadora, IDfuncAvaliada, IDsetorAvaliada, pergunta, resposta, dataHoraResposta) values (@IDfuncAvaliadora, @IDsetorAvaliadora, @IDfuncAvaliada, @IDsetorAvaliada, @pergunta, @resposta, GETDATE())", conexao);
                //comando.Parameters.AddWithValue("id", qtdeLinhas + 1);
                comando.Parameters.AddWithValue("IDfuncAvaliadora", IDfuncAvaliadora);
                comando.Parameters.AddWithValue("IDsetorAvaliadora", IDsetorAvaliadora);
                comando.Parameters.AddWithValue("IDfuncAvaliada", IDfuncAvaliada);
                comando.Parameters.AddWithValue("IDsetorAvaliada", IDsetorAvaliada);
                comando.Parameters.AddWithValue("pergunta", pergunta);
                comando.Parameters.AddWithValue("resposta", resposta);
                comando.ExecuteNonQuery();
            }
# endregion
        }
    }
}
