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
    public partial class SetorIgual : Form
    {
        private string nomeAvaliada;
        private string setorAvaliada;
        private string setorAvaliadora;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public SetorIgual(string nomeFuncionaria, string setorFuncionaria, string _setorAvaliadora)
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
        private void SetorIgual_Load(object sender, EventArgs e)
        {
            int indiceUltimoGroupbox = 12;
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            //panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);

            for (int i = 0; i < 13; i++)
            {
                if (i == 0)
                {
                    formulario.CriaGroupBoxes(i, "1. Permanece regularmente no local de trabalho para execução de suas atribuições.", 1);
                }
                else if (i == 1)
                {
                    formulario.CriaGroupBoxes(i, "2. Cumpre o horário estabelecido.", 1);
                }
                else if (i == 2)
                {
                    formulario.CriaGroupBoxes(i, "3. Informa antecipadamente imprevistos que impeçam o seu comparecimento ou cumprimento do horário.", 1);
                }
                else if (i == 3)
                {
                    formulario.CriaGroupBoxes(i, "4. Relaciona-se bem com os colegas de trabalho.", 1);
                }
                else if (i == 4)
                {
                    formulario.CriaGroupBoxes(i, "5. Trata com cortesia e respeito os idosos que precisam do trabalho designado.", 1);
                }
                else if (i == 5)
                {
                    formulario.CriaGroupBoxes(i, "6. Age de acordo com as normas legais e regulamentares.", 1);
                }
                else if (i == 6)
                {
                    formulario.CriaGroupBoxes(i, "7. Organiza suas atividades diárias para realizá-las no prazo estabelecido.", 1);
                }
                else if (i == 7)
                {
                    formulario.CriaGroupBoxes(i, "8. Realiza com qualidade as atividades que lhe são designadas.", 1);
                }
                else if (i == 8)
                {
                    formulario.CriaGroupBoxes(i, "9. Apresenta sugestões para o aperfeiçoamento do serviço.", 1);
                }
                else if (i == 9)
                {
                    formulario.CriaGroupBoxes(i, "10. Colabora com os colegas de trabalho, visando manter a coesão e a harmonia na equipe.", 1);
                }
                else if (i == 10)
                {
                    formulario.CriaGroupBoxes(i, "11.Busca novos conhecimentos que contribuam para o desenvolvimento dos trabalhos.", 1);
                }
                else if (i == 11)
                {
                    formulario.CriaGroupBoxes(i, "12. Habilidade para perceber, interpretar e discernir aspectos importantes no desenvolvimento do trabalho.", 1);
                }
                else if (i == 12)
                {
                    formulario.CriaGroupBoxes(i, "13. Capacidade de lidar com situações fora da rotina e a habilidade para criar e desenvolver novas ideias, percebendo, interpretando e discernindo aspectos importantes no desenvolvimento do trabalho.", 1);
                }
            }            



            /*int indiceUltimoGroupbox = ContagemGrupbox();*/ // Para posicionar abaixo do último groupbox o botão CONFIRMAR precisa contar a quantidade de grupbox

            //Procura o último groupbox para posicionar o botão CONFIRMAR.
            foreach (var item in panel1.Controls.OfType<GroupBox>().Where(x => x.Tag.ToString().Equals(indiceUltimoGroupbox.ToString())))
            {
                BtnConfirmar.Location = new Point((panel1.Right - BtnConfirmar.Width)/2, item.Bottom+100);
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
            //int contaRespostas = 0;
            //foreach (var item in panel1.Controls.OfType<GroupBox>())
            //{
            //    foreach (var rb in item.Controls.OfType<RadioButton>().Where(x => x.Checked))
            //    {
            //        contaRespostas++;
            //    }
            //}

            //if (contaRespostas != 13)
            //{
            //    MessageBox.Show("Verifique a questão sem resposta.");
            //}
            //else
            //{
            //    //List<string> listaRespostas = new List<string>();                

            //    foreach (var box in panel1.Controls.OfType<GroupBox>())
            //    {
            //        foreach (var rb in box.Controls.OfType<RadioButton>().Where(x => x.Checked))
            //        {
            //            //listaRespostas.Add(rb.Text);
            //            ListaDeRespostas lista = new ListaDeRespostas(nome, setor, box.Text, rb.Text);
            //            listaRespostas.Add(lista);
            //        }
            //    }

            //    Close(); // Se as 13 respostas foram preenchidas, permite sair do form
            //}

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

        //private int ContagemGrupbox()
        //{
        //    int qtdeGroupbox = 0; // Conta a quantidade de groupbox
            
        //    foreach (var item in panel1.Controls.OfType<GroupBox>())
        //    {
        //        qtdeGroupbox++;
        //    }

        //    return qtdeGroupbox;
        //}

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
        //        gb.Location = new Point(panel1.Left, 260*num);          
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
