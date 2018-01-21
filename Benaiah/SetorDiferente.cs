using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benaiah
{
    public partial class SetorDiferente : Form
    {
        private string nomeAvaliada;
        private string setorAvaliada;
        private string setorAvaliadora;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public SetorDiferente(string nomeFuncionaria, string setorFuncionaria, string _setorAvaliadora)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + nomeFuncionaria + " (" + setorFuncionaria + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeAvaliada = nomeFuncionaria;
            setorAvaliada = setorFuncionaria;
            setorAvaliadora = _setorAvaliadora;
            listaRespostas = new List<ListaDeRespostas>();
        }

        private void SetorDiferente_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);

            if (setorAvaliada.Equals("Cozinha") || setorAvaliada.Equals("Enfermagem") || setorAvaliada.Equals("Serviços gerais"))
            { 
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        formulario.CriaGroupBoxes(i, "1. Permanece regularmente no local de trabalho para execução de suas atribuições."); // 1
                    }
                    else if (i == 1)
                    {
                        formulario.CriaGroupBoxes(i, "2. Relaciona-se bem com os colegas de trabalho."); // 4
                    }
                    else if (i == 2)
                    {
                        formulario.CriaGroupBoxes(i, "3. Trata com cortesia e respeito os idosos que precisam do trabalho designado."); // 5
                    }
                    else if (i == 3)
                    {
                        formulario.CriaGroupBoxes(i, "4. Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe."); // 10
                    }
                }
            }
            else if (setorAvaliadora.Equals("Técnica") && setorAvaliada.Equals("Outros"))
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        formulario.CriaGroupBoxes(i, "1. Relaciona-se bem com os colegas de trabalho."); // 4
                    }
                    else if (i == 1)
                    {
                        formulario.CriaGroupBoxes(i, "2. Trata com cortesia e respeito os idosos que precisam do trabalho designado."); // 5
                    }
                    else if (i == 2)
                    {
                        formulario.CriaGroupBoxes(i, "3. Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe."); // 10
                    }
                    else if (i == 3)
                    {
                        formulario.CriaGroupBoxes(i, "4. Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas)."); // 17
                    }
                    else if (i == 4)
                    {
                        formulario.CriaGroupBoxes(i, "5. Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade)."); //18
                    }
                }
            }
            else if (setorAvaliadora.Equals("Outros") && setorAvaliada.Equals("Técnica"))
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i == 0)
                    {
                        formulario.CriaGroupBoxes(i, "1. Relaciona-se bem com os colegas de trabalho."); // 4
                    }
                    else if (i == 1)
                    {
                        formulario.CriaGroupBoxes(i, "2. Trata com cortesia e respeito os idosos que precisam do trabalho designado."); // 5
                    }
                    else if (i == 2)
                    {
                        formulario.CriaGroupBoxes(i, "3. Comunicação (ouve e encoraja outros expressar suas ideias e opiniões de modo objetivo)."); // 15
                    }
                    else if (i == 3)
                    {
                        formulario.CriaGroupBoxes(i, "4. Trabalho em equipe (contribui ativamente para o esforço da equipe, divide seu conhecimento e experiência com os outros)."); // 16
                    }
                    else if (i == 4)
                    {
                        formulario.CriaGroupBoxes(i, "5. Solução de problemas (toma decisões e faz julgamentos informais sobre como executar o trabalho; pensa estrategicamente, criativa nas propostas para solução de problemas)."); //17
                    }
                    else if (i == 5)
                    {
                        formulario.CriaGroupBoxes(i, "6. Técnica/funcional (tem profundo conhecimento e capacidade em sua especialidade)."); // 18
                    }
                    else if (i == 6)
                    {
                        formulario.CriaGroupBoxes(i, "7. Melhoria Contínua (promove inovações, busca aperfeiçoar-se)."); // 19
                    }
                    else if (i == 7)
                    {
                        formulario.CriaGroupBoxes(i, "8. Capacidade de organização (organização do tempo e distribuição de serviços)."); // 20
                    }
                    else if (i == 8)
                    {
                        formulario.CriaGroupBoxes(i, "9. Visão global do ambiente (entendimento do processo de atendimento dos idosos)."); // 21
                    }
                }

                if (nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS"))
                {
                    formulario.CriaGroupBoxes(9, "10. Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)");
                }
            }

            //Conta a quantidade de groupbox para posicionar o botão abaixo do último groupbox
            int qtdeGroupbox = formulario.ContagemGrupbox();
            foreach (var item in panel1.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString().Equals((qtdeGroupbox - 1).ToString())))
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

        //private void CriaGroupBoxes(int num, string texto)
        //{
        //    int distanciaVertical = 15;

        //    GroupBox gb = new GroupBox();
        //    panel1.Controls.Add(gb);
        //    gb.Tag = num;
        //    gb.Size = new Size(ClientRectangle.Width * 90 / 100, 250);
        //    if (num == 0)
        //        gb.Location = new Point(panel1.Left, 0);
        //    else
        //    {
        //        gb.Location = new Point(panel1.Left, 260 * num);
        //    }
        //    gb.BackColor = Color.LightGoldenrodYellow;
        //    gb.Text = texto;

        //    RadioButton rb1 = new RadioButton();
        //    RadioButton rb2 = new RadioButton();
        //    RadioButton rb3 = new RadioButton();
        //    RadioButton rb4 = new RadioButton();
        //    gb.Controls.Add(rb1);
        //    gb.Controls.Add(rb2);
        //    gb.Controls.Add(rb3);
        //    gb.Controls.Add(rb4);
        //    rb1.Text = "A maior parte do tempo";
        //    rb2.Text = "A menor parte do tempo";
        //    rb3.Text = "Sempre";
        //    rb4.Text = "Nunca";
        //    Size tamanho = TextRenderer.MeasureText(rb1.Text, new Font("Microsoft Sans Serif", 12));
        //    rb1.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
        //    tamanho = TextRenderer.MeasureText(rb2.Text, new Font("Microsoft Sans Serif", 12));
        //    rb2.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
        //    tamanho = TextRenderer.MeasureText(rb3.Text, new Font("Microsoft Sans Serif", 12));
        //    rb3.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
        //    tamanho = TextRenderer.MeasureText(rb4.Text, new Font("Microsoft Sans Serif", 12));
        //    rb4.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
        //    rb1.Location = new Point(gb.Left + distanciaVertical, 40);
        //    rb2.Location = new Point(gb.Left + distanciaVertical, 60);
        //    rb3.Location = new Point(gb.Left + distanciaVertical, 80);
        //    rb4.Location = new Point(gb.Left + distanciaVertical, 100);

        //    TextBox txtObs = new TextBox();
        //    gb.Controls.Add(txtObs);
        //    txtObs.Tag = num;
        //    txtObs.Multiline = true;
        //    txtObs.Location = new Point(gb.Left + distanciaVertical, 150);
        //    txtObs.Size = new Size(gb.Width * 90 / 100, 60);
        //}
    }
}
