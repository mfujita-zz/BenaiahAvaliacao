﻿using System;
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

        public void CriaGroupBoxes(int num, string texto)
        {
            int distanciaVertical = 15;

            GroupBox gb = new GroupBox();
            panel1.Controls.Add(gb);
            gb.Tag = num;
            gb.Size = new Size(panel1.ClientRectangle.Width * 90 / 100, 250);
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