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
        private string nomeDaAvaliadora;
        private string setorDaAvaliadora;
        private string nomeAvaliada;
        private string setorAvaliada;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public Tecnica(string _nomeAvaliada, string _setorAvaliada, string nomeRespondendoFormulario, string _setorAvaliadora)
        {
            InitializeComponent();
            txtNome.Text = "Avalie " + _nomeAvaliada + " (" + _setorAvaliada + ")";
            txtNome.Font = new Font("Microsoft Sans Serif", 25f);
            nomeDaAvaliadora = nomeRespondendoFormulario;
            setorDaAvaliadora = _setorAvaliadora;
            nomeAvaliada = _nomeAvaliada;
            setorAvaliada = _setorAvaliada;
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
            TextoPerguntas perguntas = new TextoPerguntas();
            int numeroPergunta = 0;

            foreach (var item in perguntas.Tipo4())
            {
                formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta + 1 + ". " + item, 1);
                numeroPergunta++;
            }
            foreach (var item in perguntas.Tipo2())
            {
                formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta + 1 + ". " + item, 2);
                numeroPergunta++;
            }

            if (nomeAvaliada.Equals("TAMIRES DE ANGELO CANDIDO") && setorDaAvaliadora.Equals("Cozinha") ||
                nomeAvaliada.Equals("MARIANA SINICIATO HENRIQUES") && setorDaAvaliadora.Equals("Enfermagem") ||
                nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS") && setorDaAvaliadora.Equals("Serviços gerais"))
            {                
                formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)", 2);                
            }


            //Procura o último groupbox para posicionar o botão CONFIRMAR.
            formulario.PosicionaBotao(BtnConfirmar);

            foreach (var box in panel1.Controls.OfType<GroupBox>())
            {
                foreach (var rb in box.Controls.OfType<RadioButton>())
                {
                    if (rb.Text.Equals("A maior parte do tempo") || rb.Text.Equals("Excede expectativas"))
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
