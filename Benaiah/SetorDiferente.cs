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
    public partial class SetorDiferente : Form
    {
        public SetorDiferente(string nome, string setor)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + nome + " (" + setor + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
        }

        private void SetorDiferente_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    CriaGroupBoxes(i, "1. Permanece regularmente no local de trabalho para execução de suas atribuições.");
                }
                else if (i == 1)
                {
                    CriaGroupBoxes(i, "2. Relaciona-se bem com os colegas de trabalho.");
                }
                else if (i == 2)
                {
                    CriaGroupBoxes(i, "3. Trata com cortesia e respeito os idosos que precisam do trabalho designado.");
                }
                else if (i == 3)
                {
                    CriaGroupBoxes(i, "4. Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.");
                }
            }

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

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            int contaRespostas = 0;
            foreach (var item in panel1.Controls.OfType<GroupBox>())
            {
                foreach (var rb in item.Controls.OfType<RadioButton>().Where(x => x.Checked))
                {
                    contaRespostas++;
                }
            }

            if (contaRespostas != 4)
            {
                MessageBox.Show("Verifique a questão sem resposta.");
            }
            else
            {
                List<string> listaRespostas = new List<string>();
                foreach (var box in panel1.Controls.OfType<GroupBox>())
                {
                    foreach (var rb in box.Controls.OfType<RadioButton>().Where(x => x.Checked))
                    {
                        listaRespostas.Add(rb.Text);
                    }
                }

                Close(); // Se as 4 respostas foram preenchidas, permite sair do form
            }
        }

        private void CriaGroupBoxes(int num, string texto)
        {
            int distanciaVertical = 15;

            GroupBox gb = new GroupBox();
            panel1.Controls.Add(gb);
            gb.Tag = num;
            gb.Size = new Size(ClientRectangle.Width * 90 / 100, 250);
            if (num == 0)
                gb.Location = new Point(panel1.Left, 0);
            else
            {
                gb.Location = new Point(panel1.Left, 260 * num);
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
            rb1.Text = "A maior parte do tempo";
            rb2.Text = "A menor parte do tempo";
            rb3.Text = "Sempre";
            rb4.Text = "Nunca";
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
            txtObs.Location = new Point(gb.Left + distanciaVertical, 150);
            txtObs.Size = new Size(gb.Width * 90 / 100, 60);
        }
    }
}
