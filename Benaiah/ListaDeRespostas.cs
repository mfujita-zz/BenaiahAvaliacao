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
            using (var conexao = new SqlConnection("Server = ULTRABOOK\\SQLEXPRESS; Database = Benaiah; Trusted_Connection = True;"))
            {
                conexao.Open();
                SqlCommand sqlContaLinha = new SqlCommand("select count(*) from respostas", conexao);
                int qtdeLinhas = (int)sqlContaLinha.ExecuteScalar();
                //if (qtdeLinhas == 0)
                //{
                //    qtdeLinhas = 1;
                //}
                SqlCommand comando = new SqlCommand("insert into Respostas (ID, nomeDaAvaliadora, setorDaAvaliadora, nomeAvaliada, setorAvaliada, pergunta, resposta, DataHoraResposta) values (@id, @nomeDaAvaliadora, @setorDaAvaliadora, @nomeAvaliada, @setorAvaliada, @pergunta, @resposta, GETDATE())", conexao);
                comando.Parameters.AddWithValue("id", qtdeLinhas+1);
                comando.Parameters.AddWithValue("nomeDaAvaliadora", nomeDaAvaliadora);
                comando.Parameters.AddWithValue("setorDaAvaliadora", setorDaAvaliadora);
                comando.Parameters.AddWithValue("nomeAvaliada", nomeAvaliada);
                comando.Parameters.AddWithValue("setorAvaliada", setorAvaliada);
                comando.Parameters.AddWithValue("pergunta", pergunta);
                comando.Parameters.AddWithValue("resposta", resposta);
                comando.ExecuteNonQuery();
            }
        }
    }
}
