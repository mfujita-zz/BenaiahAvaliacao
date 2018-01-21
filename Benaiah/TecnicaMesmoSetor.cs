using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benaiah
{
    public partial class TecnicaMesmoSetor : Form
    {
        private string nomeAvaliada;
        private string setorAvaliada;
        private string setorAvaliadora;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public TecnicaMesmoSetor(string nomeFuncionaria, string setorFuncionaria, string _setorAvaliadora)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + nomeFuncionaria + " (" + setorFuncionaria + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeAvaliada = nomeFuncionaria;
            setorAvaliada = setorFuncionaria;
            setorAvaliadora = _setorAvaliadora;
            listaRespostas = new List<ListaDeRespostas>();
        }

        private void TecnicaMesmoSetor_Load(object sender, EventArgs e)
        {
            //int indiceUltimoGroupbox = 20;
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            //panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);

            for (int i = 0; i < 20; i++)
            {
                if (i == 0)
                {
                    formulario.CriaGroupBoxes(i, "1. Permanece regularmente no local de trabalho para execução de suas atribuições.");
                }
                else if (i == 1)
                {
                    formulario.CriaGroupBoxes(i, "2. Cumpre o horário estabelecido.");
                }
                else if (i == 2)
                {
                    formulario.CriaGroupBoxes(i, "3. Informa antecipadamente imprevistos que impeçam o seu comparecimento ou cumprimento do horário.");
                }
                else if (i == 3)
                {
                    formulario.CriaGroupBoxes(i, "4. Relaciona-se bem com os colegas de trabalho.");
                }
                else if (i == 4)
                {
                    formulario.CriaGroupBoxes(i, "5. Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
                }
                else if (i == 5)
                {
                    formulario.CriaGroupBoxes(i, "6. Age de acordo com as normas legais e regulamentares.");
                }
                else if (i == 6)
                {
                    formulario.CriaGroupBoxes(i, "7. Organiza suas atividades diárias para realizá-las no prazo estabelecido.");
                }
                else if (i == 7)
                {
                    formulario.CriaGroupBoxes(i, "8. Realiza com qualidade as atividades que lhe são designadas.");
                }
                else if (i == 8)
                {
                    formulario.CriaGroupBoxes(i, "9. Apresenta sugestões para o aperfeiçoamento do serviço.");
                }
                else if (i == 9)
                {
                    formulario.CriaGroupBoxes(i, "10. Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
                }
                else if (i == 10)
                {
                    formulario.CriaGroupBoxes(i, "11.Busca novos conhecimentos que contribuam para o desenvolvimento dos trabalhos.");
                }
                else if (i == 11)
                {
                    formulario.CriaGroupBoxes(i, "12. Habilidade para perceber, interpretar e discernir aspectos importantes no desenvolvimento do trabalho.");
                }
                else if (i == 12)
                {
                    formulario.CriaGroupBoxes(i, "13. Capacidade de lidar com situações fora da rotina e a habilidade para criar e desenvolver novas ideias, percebendo, interpretando e discernindo aspectos importantes no desenvolvimento do trabalho.");
                }
                else if (i == 13)
                {
                    formulario.CriaGroupBoxes(i, "14. Comunicação (ouve e encoraja outros expressar suas ideias e opiniões de modo objetivo).");
                }
                else if (i == 14)
                {
                    formulario.CriaGroupBoxes(i, "15. Trabalho em equipe (contribui ativamente para o esforço da equipe, divide seu conhecimento e experiência com os outros).");
                }
                else if (i == 15)
                {
                    formulario.CriaGroupBoxes(i, "16. Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas).");
                }
                else if (i == 16)
                {
                    formulario.CriaGroupBoxes(i, "17. Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).");
                }
                else if (i == 17)
                {
                    formulario.CriaGroupBoxes(i, "18. Melhoria Contínua (promove inovações, busca aperfeiçoar-se).");
                }
                else if (i == 18)
                {
                    formulario.CriaGroupBoxes(i, "19. Capacidade de organização (organização do tempo e distribuição de serviços).");
                }
                else if (i == 19)
                {
                    formulario.CriaGroupBoxes(i, "20. Visão global do ambiente (entendimento do processo de atendimento dos idosos).");
                }
            }

            if (nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS"))
            {
                formulario.CriaGroupBoxes(20, "21. Liderança (encoraja o trabalho em equipe, direciona e conduz projetos).");
            }

            int indiceUltimoGroupbox = formulario.ContagemGrupbox(); // Para posicionar abaixo do último groupbox o botão CONFIRMAR precisa contar a quantidade de grupbox

            //Procura o último groupbox para posicionar o botão CONFIRMAR.
            foreach (var item in panel1.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString().Equals(indiceUltimoGroupbox.ToString())))
            {
                BtnConfirmar.Location = new Point((panel1.Right - BtnConfirmar.Width) / 2, item.Bottom + 100);
            }
            BtnConfirmar.BackColor = Color.LightGoldenrodYellow;
            BtnConfirmar.Text = "Confirmar";

            foreach (var box in panel1.Controls.OfType<GroupBox>())
            {
                foreach (var rb in box.Controls.OfType<RadioButton>())
                {
                    rb.Checked = true;
                }
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            DesenhaFormulario formulario = new DesenhaFormulario(panel1);
            int qtdeGroupbox = formulario.ContagemGrupbox(); // Conta a quantidade de groupbox
            int qtdeRadiobuttonChecked = 0; // conta a quantidade de radiobutton marcado

            foreach (var item in panel1.Controls.OfType<GroupBox>())
            {
                foreach (var rb in item.Controls.OfType<RadioButton>().Where(x => x.Checked))
                {
                    qtdeRadiobuttonChecked++;
                }
            }

            if (qtdeGroupbox == qtdeRadiobuttonChecked) // Se a quantidade de groupbox for igual a de radiobutton marcado, então todas as respostas foram marcadas
            {
                foreach (var box in panel1.Controls.OfType<GroupBox>())
                {
                    foreach (var rb in box.Controls.OfType<RadioButton>().Where(x => x.Checked))
                    {
                        //listaRespostas.Add(rb.Text);
                        ListaDeRespostas lista = new ListaDeRespostas(nomeAvaliada, setorAvaliada, box.Text, rb.Text); //box = pergunta; rb = resposta assinalada
                        listaRespostas.Add(lista);
                    }
                }

                Close();
            }
            else
            {
                MessageBox.Show("Verifique a questão sem resposta.");
            }
        }
    }
}
