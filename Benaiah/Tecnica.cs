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
        private string nomeEntrevistada;
        private string setorEntrevistada;

        public Tecnica(string nomeFuncionaria, string setorFuncionaria)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + nomeFuncionaria + " (" + setorFuncionaria + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeEntrevistada = nomeFuncionaria;
            setorEntrevistada = setorFuncionaria;
        }

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
                    formulario.CriaGroupBoxes(i, "1. Relaciona-se bem com os colegas de trabalho.");
                }
                else if (i == 1)
                {
                    formulario.CriaGroupBoxes(i, "2. Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
                }
                else if (i == 2)
                {
                    formulario.CriaGroupBoxes(i, "3. Comunicação (ouve e encoraja outros expressar suas ideias e opiniões de modo objetivo).");
                }
                else if (i == 3)
                {
                    formulario.CriaGroupBoxes(i, "4. Trabalho em equipe (contribui ativamente para o esforço da equipe, divide seu conhecimento e experiência com os outros).");
                }
                else if (i == 4)
                {
                    formulario.CriaGroupBoxes(i, "5. Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas).");
                }
                else if (i == 5)
                {
                    formulario.CriaGroupBoxes(i, "6. Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade).");
                }
                else if (i == 6)
                {
                    formulario.CriaGroupBoxes(i, "7. Melhoria Contínua (promove inovações, busca aperfeiçoar-se).");
                }
                else if (i == 7)
                {
                    formulario.CriaGroupBoxes(i, "8. Capacidade de organização (organização do tempo e distribuição de serviços).");
                }
                else if (i == 8)
                {
                    formulario.CriaGroupBoxes(i, "9. Visão global do ambiente (entendimento do processo de atendimento dos idosos).");
                }                
            }

            //Tag = 3 é o último groupbox e o botão localiza-se abaixo.
            foreach (var item in panel1.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString().Equals("3")))
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
    }
}
