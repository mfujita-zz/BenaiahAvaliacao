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
        private string nomeDaAvaliadora;
        private string setorDaAvaliadora;
        private string nomeAvaliada;
        private string setorAvaliada;
        public static List<ListaDeRespostas> listaRespostas { get; set; }

        public TecnicaMesmoSetor(string _nomeAvaliada, string _setorAvaliada, string nomeRespondendoFormulario, string _setorAvaliadora)
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
        private void TecnicaMesmoSetor_Load(object sender, EventArgs e)
        {
            //int indiceUltimoGroupbox = 20;
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            //panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);
            TextoPerguntas perguntas = new TextoPerguntas();
            int numeroPergunta = 1;

            foreach (var item in perguntas.Tipo1())
            {
                formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta + ". " + item, 1);
                numeroPergunta++;
            }
            foreach (var item in perguntas.Tipo3())
            {
                formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta + ". " + item, 2);
                numeroPergunta++;
            }

            if (nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS"))
            {
                formulario.CriaGroupBoxes(20, "21. Liderança (encoraja o trabalho em equipe, direciona e conduz projetos).", 2);
            }

            int indiceUltimoGroupbox = formulario.ContagemGrupbox(); // Para posicionar abaixo do último groupbox o botão CONFIRMAR precisa contar a quantidade de grupbox

            //Procura o último groupbox para posicionar o botão CONFIRMAR.
            formulario.PosicionaBotao(BtnConfirmar);

            //Usado para teste. Deixa os radiobuttons marcados.
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
