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
        private string nomeDaAvaliadora;
        private string setorDaAvaliadora;
        private string nomeAvaliada;
        private string setorAvaliada;

        //private int IDfuncAvaliadora;
        //private int IDsetorAvaliadora;
        //private int IDfuncAvaliada;
        //private int IDsetorAvaliada;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public SetorIgual(string _nomeAvaliada, string _setorAvaliada, string nomeRespondendoFormulario, string _setorAvaliadora)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + _nomeAvaliada + " (" + _setorAvaliada + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeAvaliada = _nomeAvaliada;
            setorAvaliada = _setorAvaliada;
            nomeDaAvaliadora = nomeRespondendoFormulario;
            setorDaAvaliadora = _setorAvaliadora;
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
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            //panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);
            TextoPerguntas perguntas = new TextoPerguntas();
            int numeroPergunta = 0;

            foreach (var item in perguntas.Tipo1())
            {
                //formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 1);
                formulario.CriaGroupBoxes(numeroPergunta, item, 1);
                numeroPergunta++;
            }

            //Procura o último groupbox para posicionar o botão CONFIRMAR.
            formulario.PosicionaBotao(BtnConfirmar);

            foreach (var box in panel1.Controls.OfType<GroupBox>())
            {
                foreach (var rb in box.Controls.OfType<RadioButton>())
                {
                    //if (rb.Text.Equals("A maior parte do tempo") || rb.Text.Equals("Excede expectativas"))
                    //if (rb.Text.Equals("A menor parte do tempo") || rb.Text.Equals("Atinge Expectativas"))
                    if (rb.Text.Equals("Sempre") || rb.Text.Equals("Precisa melhorar"))
                    //if (rb.Text.Equals("Nunca") || rb.Text.Equals("Insatisfatório"))
                    {
                        rb.Checked = true;
                    }
                }
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            DesenhaFormulario formulario = new DesenhaFormulario(panel1);
            if (formulario.ProcessaResposta())
            {
                foreach (var box in panel1.Controls.OfType<GroupBox>())
                {
                    foreach (var rb in box.Controls.OfType<RadioButton>().Where(x => x.Checked))
                    {
                        //ListaDeRespostas lista = new ListaDeRespostas(nomeAvaliada, setorAvaliada, box.Text, rb.Text);
                        //ListaDeRespostas lista = new ListaDeRespostas(nomeDaAvaliadora, setorDaAvaliadora, nomeAvaliada, setorAvaliada, box.Text, rb.Text);

                        ListaDeRespostas lista = new ListaDeRespostas(nomeDaAvaliadora, setorDaAvaliadora, nomeAvaliada, setorAvaliada, box.Text, rb.Text);
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
