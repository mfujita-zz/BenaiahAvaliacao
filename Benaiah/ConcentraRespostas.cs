using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaiah
{
    class ConcentraRespostas
    {
        public void GeraRelatorio(List<ListaDeRespostas> todasRespostas, string nome, string setor)
        {
            //FileStream fs = new FileStream("relatorio.html", FileMode.Create);
            FileStream fs = new FileStream(nome+".html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor: " + setor + "</h4>");
            sw.WriteLine("<table border=1>");
            foreach (var item in todasRespostas)
            {
                sw.WriteLine("<tr><td>" + item.nomeAvaliada + "</td> <td>" + item.setorAvaliada + "</td> <td>" + item.pergunta + "</td> <td>" + item.resposta + "</td> </tr>");
            }

            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();

            //RelatorioCozinha(todasRespostas);
            //RelatorioEnfermagem(todasRespostas);
            //RelatorioServicosGerais(todasRespostas);
            //RelatorioTecnica(todasRespostas);
            //RelatorioOutros(todasRespostas);
        }

        private void TesteListagem()
        {
            List<string> question = new List<string>();
            question.Add("Permanece regularmente no local de trabalho para execução de suas atribuições.");
            question.Add("Cumpre o horário estabelecido.");
            question.Add("Informa antecipadamente imprevistos que impeçam o seu comparecimento ou cumprimento do horário.");
            question.Add("Relaciona-se bem com os colegas de trabalho.");
            question.Add("Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
            question.Add("Age de acordo com as normas legais e regulamentares.");
            question.Add("Organiza suas atividades diárias para realizá-las no prazo estabelecido.");
            question.Add("Realiza com qualidade as atividades que lhe são designadas.");
            question.Add("Apresenta sugestões para o aperfeiçoamento do serviço.");
            question.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
            question.Add("Busca novos conhecimentos que contribuam para o desenvolvimento dos trabalhos.");
            question.Add("Habilidade para perceber, interpretar e discernir aspectos importantes no desenvolvimento do trabalho.");
            question.Add("Capacidade de lidar com situações fora da rotina e a habilidade para criar e desenvolver novas ideias, percebendo, interpretando e discernindo aspectos importantes no desenvolvimento do trabalho.");
            question.Add("Permanece regularmente no local de trabalho para execução de suas atribuições.");
            question.Add("Relaciona-se bem com os colegas de trabalho.");
            question.Add("Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
            question.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");

            FileStream fs = new FileStream("geral.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            sw.WriteLine("<table border=1>");

            BancoDeDados bd = new BancoDeDados();
            using (SqlConnection conexao = new SqlConnection(bd.StringConexao()))
            {
                conexao.Open();
                foreach (var item in question)
                {
                    using (SqlCommand comando = new SqlCommand("select * from Resposta where pergunta = " + item + "and nome = 'ALDENIRA PEREIRA MORAES'", conexao))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        { 
                            while (reader.Read())
                            {
                                sw.WriteLine("<tr><td>" + reader["nome"] + "</td><td>" + reader["setor"] + "</td><td>" + reader["pergunta"] + "</td><td>" + reader["resposta"] + "</td></tr>");
                            }
                        }
                    }
                }                
            }
            sw.Close();
        }

        //select * from Respostas where pergunta like '%Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)'
        //select resposta from Respostas where pergunta = '1. Permanece regularmente no local de trabalho para execução de suas atribuições.' and nome = 'ALDENIRA PEREIRA MORAES' group by resposta


        private void RelatorioCozinha(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("cozinha.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            //sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor Cozinha</h4>");
            sw.WriteLine("<table border=1>");

            foreach (var it in todasRespostas)
            {
                if (it.setorAvaliada.Equals("Cozinha"))
                { 
                    sw.WriteLine("<tr><td>" + it.nomeAvaliada + "</td><td>" + it.pergunta + "</td><td>" + it.resposta + "</td></tr>");
                }
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }

        private void RelatorioEnfermagem(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("enfermagem.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            //sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor Enfermagem</h4>");
            sw.WriteLine("<table border=1>");

            foreach (var it in todasRespostas)
            {
                if (it.setorAvaliada.Equals("Enfermagem"))
                {
                    sw.WriteLine("<tr><td>" + it.nomeAvaliada + "</td><td>" + it.pergunta + "</td><td>" + it.resposta + "</td></tr>");
                }
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }

        private void RelatorioServicosGerais(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("servicos_gerais.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            //sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor Serviços Gerais</h4>");
            sw.WriteLine("<table border=1>");

            foreach (var it in todasRespostas)
            {
                if (it.setorAvaliada.Equals("Serviços gerais"))
                {
                    sw.WriteLine("<tr><td>" + it.nomeAvaliada + "</td><td>" + it.pergunta + "</td><td>" + it.resposta + "</td></tr>");
                }
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }

        private void RelatorioTecnica(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("tecnica.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            //sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor Técnica</h4>");
            sw.WriteLine("<table border=1>");

            foreach (var it in todasRespostas)
            {
                if (it.setorAvaliada.Equals("Técnica"))
                {
                    sw.WriteLine("<tr><td>" + it.nomeAvaliada + "</td><td>" + it.pergunta + "</td><td>" + it.resposta + "</td></tr>");
                }
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }

        private void RelatorioOutros(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("outros.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            //sw.WriteLine("<h4>Avaliação feita por: " + nome + "</h4>");
            sw.WriteLine("<h4>Setor Outros</h4>");
            sw.WriteLine("<table border=1>");

            foreach (var it in todasRespostas)
            {
                if (it.setorAvaliada.Equals("Outros"))
                {
                    sw.WriteLine("<tr><td>" + it.nomeAvaliada + "</td><td>" + it.pergunta + "</td><td>" + it.resposta + "</td></tr>");
                }
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }
    }
}
