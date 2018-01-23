using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Classe que contém todas as perguntas. Todos os formulários são montados buscando as questões aqui.

namespace Benaiah
{
    class TextoPerguntas
    {
        public List<string> Tipo1() // Perguntas 1 a 13
        {
            List<string> lista = new List<string>();
            lista.Add("Permanece regularmente no local de trabalho para execução de suas atribuições.");
            lista.Add("Cumpre o horário estabelecido.");
            lista.Add("Informa antecipadamente imprevistos que impeçam o seu comparecimento ou cumprimento do horário.");
            lista.Add("Relaciona-se bem com os colegas de trabalho.");
            lista.Add("Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
            lista.Add("Age de acordo com as normas legais e regulamentares.");
            lista.Add("Organiza suas atividades diárias para realizá-las no prazo estabelecido.");
            lista.Add("Realiza com qualidade as atividades que lhe são designadas.");
            lista.Add("Apresenta sugestões para o aperfeiçoamento do serviço.");
            lista.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
            lista.Add("Busca novos conhecimentos que contribuam para o desenvolvimento dos trabalhos.");
            lista.Add("Habilidade para perceber, interpretar e discernir aspectos importantes no desenvolvimento do trabalho.");
            lista.Add("Capacidade de lidar com situações fora da rotina e a habilidade para criar e desenvolver novas ideias, percebendo, interpretando e discernindo aspectos importantes no desenvolvimento do trabalho.");
            return lista;
        }

        public List<string> Tipo2() //Perguntas 1, 4, 5 e 10
        {
            List<string> lista = new List<string>();
            lista.Add("Permanece regularmente no local de trabalho para execução de suas atribuições.");
            lista.Add("Relaciona-se bem com os colegas de trabalho.");
            lista.Add("Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
            lista.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
            return lista;
        }

        public List<string> Tipo3() // Perguntas 15, 16, 17, 18, 19, 20 e 21
        {
            List<string> lista = new List<string>();
            lista.Add("Comunicação (ouve e encoraja outros expressar suas ideias e opiniões de modo objetivo).");
            lista.Add("Trabalho em equipe (contribui ativamente para o esforço da equipe, divide seu conhecimento e experiência com os outros).");
            lista.Add("Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas).");
            lista.Add("Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).");
            lista.Add("Melhoria contínua (promove inovações, busca aperfeiçoar-se).");
            lista.Add("Capacidade de organização (organização do tempo e distribuição de serviços).");
            lista.Add("Visão global do ambiente (entendimento do processo de atendimento dos idosos).");
            return lista;
        }

        public List<string> Tipo4() //Perguntas 4, 5 - Opções A maior parte do tempo, A menor parte do tempo, Sempre, Nunca
        {
            List<string> lista = new List<string>();
            lista.Add("Relaciona-se bem com os colegas de trabalho.");
            lista.Add("Trata com cortesia e respeito os idosos que precisam do trabalho designado.");            
            return lista;
        }

        public List<string> Tipo5() // Perguntas 10 e 18 - Opções Excede expectativas, Atinge Expectativas, Precisa melhorar, Insatisfatório
        {
            List<string> lista = new List<string>();
            lista.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
            lista.Add("Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).");
            return lista;
        }

        public List<string> Tipo6() // Perguntas 10, 17 e 18 - Opções Excede expectativas, Atinge Expectativas, Precisa melhorar, Insatisfatório
        {
            List<string> lista = new List<string>();
            lista.Add("Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
            lista.Add("Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas).");
            lista.Add("Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).");
            return lista;
        }
    }
}
