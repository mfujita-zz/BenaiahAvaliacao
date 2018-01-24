using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benaiah
{
    class DesenhaFormulario
    {
        Panel panel1;

        public DesenhaFormulario(Panel painel)
        {
            panel1 = painel;
        }

        public void CriaGroupBoxes(int num, string texto, int tipo)
        {
            int distanciaVertical = 15;

            GroupBox gb = new GroupBox();
            panel1.Controls.Add(gb);
            gb.Tag = num;
            // Alterar o posicionamento do BtnConfirmar.Location se mexer no segundo parâmetro do gb.Size
            gb.Size = new Size(panel1.ClientRectangle.Width * 90 / 100, 160); // Se mexer na posição do groupbox, altere o segundo parâmetro do gb.Size
            if (num == 0)
                gb.Location = new Point(panel1.Left, 0);
            else
            {
                gb.Location = new Point(panel1.Left, 170 * num); //260 * num);
            }
            gb.BackColor = Color.LightGoldenrodYellow;
            gb.Text = texto;

            RadioButton rb1 = new RadioButton();
            RadioButton rb2 = new RadioButton();
            RadioButton rb3 = new RadioButton();
            RadioButton rb4 = new RadioButton();
            gb.Controls.Add(rb1);
            gb.Controls.Add(rb2);
            gb.Controls.Add(rb3);
            gb.Controls.Add(rb4);
            if (tipo.Equals(1))
            { 
                rb1.Text = "A maior parte do tempo";
                rb2.Text = "A menor parte do tempo";
                rb3.Text = "Sempre";
                rb4.Text = "Nunca";
            }
            else if (tipo.Equals(2))
            {
                rb1.Text = "Excede expectativas";
                rb2.Text = "Atinge Expectativas";
                rb3.Text = "Precisa melhorar";
                rb4.Text = "Insatisfatório";
            }
            Size tamanho = TextRenderer.MeasureText(rb1.Text, new Font("Microsoft Sans Serif", 12));
            rb1.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
            tamanho = TextRenderer.MeasureText(rb2.Text, new Font("Microsoft Sans Serif", 12));
            rb2.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
            tamanho = TextRenderer.MeasureText(rb3.Text, new Font("Microsoft Sans Serif", 12));
            rb3.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
            tamanho = TextRenderer.MeasureText(rb4.Text, new Font("Microsoft Sans Serif", 12));
            rb4.Size = new Size((int)(tamanho.Width * 1.5), (int)(tamanho.Height * 1.2));
            rb1.Location = new Point(gb.Left + distanciaVertical, 40);
            rb2.Location = new Point(gb.Left + distanciaVertical, 60);
            rb3.Location = new Point(gb.Left + distanciaVertical, 80);
            rb4.Location = new Point(gb.Left + distanciaVertical, 100);            

            TextBox txtObs = new TextBox();
            gb.Controls.Add(txtObs);
            txtObs.Tag = num;
            txtObs.Multiline = true;
            //txtObs.Location = new Point(gb.Left + distanciaVertical, 150);
            txtObs.Location = new Point(rb1.Right + 100, rb1.Top);
            txtObs.Size = new Size(gb.Width * 60 / 100, 60);
        }

        public int ContagemGrupbox()
        {
            int qtdeGroupbox = 0; // Conta a quantidade de groupbox

            foreach (var item in panel1.Controls.OfType<GroupBox>())
            {
                qtdeGroupbox++;
            }

            return qtdeGroupbox;
        }

        //Conta os groupbox do formulário e posiciona o botão abaixo do último groupbox
        public void PosicionaBotao(Button BtnConfirmar)
        {
            BtnConfirmar.Location = new Point((panel1.Right - BtnConfirmar.Width) / 2, ContagemGrupbox() * 170 + 100);
            BtnConfirmar.BackColor = Color.LightGoldenrodYellow;
            BtnConfirmar.Text = "Confirmar";
        }

        public bool ProcessaResposta()
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
