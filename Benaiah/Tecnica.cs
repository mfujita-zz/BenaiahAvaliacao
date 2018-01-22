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
    public partial class Tecnica : Form
    {
        private string nomeAvaliada;
        private string setorAvaliada;
        private string setorAvaliadora;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public Tecnica(string nomeFuncionaria, string setorFuncionaria, string _setorAvaliadora)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + nomeFuncionaria + " (" + setorFuncionaria + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeAvaliada = nomeFuncionaria;
            setorAvaliada = setorFuncionaria;
            setorAvaliadora = _setorAvaliadora;
            listaRespostas = new List<ListaDeRespostas>();
        }

        /// <summary>
        /// CriaFormulario(int, string, int)
        /// int i: índice para posicionar o groupbox
        /// string: A pergunta para a entrevistada
        /// int 1 ou 2: Os textos do radiobutton podem ser de 2 tipo: A maior parte do tempo, A menor parte do tempo, Sempre, Nunca ou
        ///             Excede expectativas, Atinge Expectativas, Precisa melhorar, Insatisfatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tecnica_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);            

            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    formulario.CriaGroupBoxes(i, "1. Relaciona-se bem com os colegas de trabalho.", 1);
                }
                else if (i == 1)
                {
                    formulario.CriaGroupBoxes(i, "2. Trata com cortesia e respeito os idosos que precisam do trabalho designado.", 1);
                }
                else if (i == 2)
                {
                    formulario.CriaGroupBoxes(i, "3. Comunicação (ouve e encoraja outros expressar suas ideias e opiniões de modo objetivo).", 2);
                }
                else if (i == 3)
                {
                    formulario.CriaGroupBoxes(i, "4. Trabalho em equipe (contribui ativamente para o esforço da equipe, divide seu conhecimento e experiência com os outros).", 2);
                }
                else if (i == 4)
                {
                    formulario.CriaGroupBoxes(i, "5. Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas).", 2);
                }
                else if (i == 5)
                {
                    formulario.CriaGroupBoxes(i, "6. Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).", 2);
                }
                else if (i == 6)
                {
                    formulario.CriaGroupBoxes(i, "7. Melhoria Contínua (promove inovações, busca aperfeiçoar-se).", 2);
                }
                else if (i == 7)
                {
                    formulario.CriaGroupBoxes(i, "8. Capacidade de organização (organização do tempo e distribuição de serviços).", 2);
                }
                else if (i == 8)
                {
                    formulario.CriaGroupBoxes(i, "9. Visão global do ambiente (entendimento do processo de atendimento dos idosos).", 2);
                }                
            }

            if (nomeAvaliada.Equals("TAMIRES DE ANGELO CANDIDO") && setorAvaliadora.Equals("Cozinha") ||
                nomeAvaliada.Equals("MARIANA SINICIATO HENRIQUES") && setorAvaliadora.Equals("Enfermagem") ||
                nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS") && setorAvaliadora.Equals("Serviços gerais"))
            {                
                formulario.CriaGroupBoxes(9, "10. Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)", 2);                
            }

            //if (nomeAvaliada.Equals("MARIANA SINICIATO HENRIQUES") && setorAvaliadora.Equals("Enfermagem"))
            //{
            //    formulario.CriaGroupBoxes(9, "10. Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)");
            //}

            //Conta a quantidade de groupbox para posicionar o botão abaixo do último groupbox
            int qtdeGroupbox = formulario.ContagemGrupbox();
            foreach (var item in panel1.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString().Equals((qtdeGroupbox-1).ToString())))
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
                        ListaDeRespostas lista = new ListaDeRespostas(nomeAvaliada, setorAvaliada, box.Text, rb.Text);
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
