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

        /// <summary>
        /// CriaFormulario(int, string, int)
        /// int i: índice para posicionar o groupbox
        /// string: A pergunta para a entrevistada
        /// int 1 ou 2: Os textos do radiobutton podem ser de 2 tipo: A maior parte do tempo, A menor parte do tempo, Sempre, Nunca ou
        ///             Excede expectativas, Atinge Expectativas, Precisa melhorar, Insatisfatório
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetorDiferente_Load(object sender, EventArgs e)
        {
            panel1.Size = new Size(ClientRectangle.Width, Height * 90 / 100);
            panel1.Location = new Point(0, 50);
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;

            DesenhaFormulario formulario = new DesenhaFormulario(panel1);
            TextoPerguntas perguntas = new TextoPerguntas();
            int numeroPergunta = 0;

            if (setorAvaliadora.Equals("Cozinha") && setorAvaliada.Equals("Enfermagem") ||
                setorAvaliadora.Equals("Cozinha") && setorAvaliada.Equals("Serviços gerais") ||
                setorAvaliadora.Equals("Enfermagem") && setorAvaliada.Equals("Cozinha") ||
                setorAvaliadora.Equals("Enfermagem") && setorAvaliada.Equals("Serviços gerais") ||
                setorAvaliadora.Equals("Serviços gerais") && setorAvaliada.Equals("Cozinha") ||
                setorAvaliadora.Equals("Serviços gerais") && setorAvaliada.Equals("Enfermagem") ||
                setorAvaliadora.Equals("Outros") && setorAvaliada.Equals("Cozinha") ||
                setorAvaliadora.Equals("Outros") && setorAvaliada.Equals("Enfermagem") ||
                setorAvaliadora.Equals("Outros") && setorAvaliada.Equals("Serviços gerais"))
            {
                foreach (var item in perguntas.Tipo2())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 1);
                    numeroPergunta++;
                }
            }

            else if (setorAvaliadora.Equals("Cozinha") && setorAvaliada.Equals("Outros") ||
                setorAvaliadora.Equals("Enfermagem") && setorAvaliada.Equals("Outros") ||
                setorAvaliadora.Equals("Serviços gerais") && setorAvaliada.Equals("Outros"))
            {
                foreach (var item in perguntas.Tipo4())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 1);
                    numeroPergunta++;
                }
                foreach (var item in perguntas.Tipo5())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 2);
                    numeroPergunta++;
                }
            }

            else if (setorAvaliadora.Equals("Técnica") && setorAvaliada.Equals("Outros"))
            {
                foreach (var item in perguntas.Tipo4())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 1);
                    numeroPergunta++;
                }
                foreach (var item in perguntas.Tipo6())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 2);
                    numeroPergunta++;
                }
            }

            else if (setorAvaliadora.Equals("Outros") && setorAvaliada.Equals("Técnica"))
            {
                foreach (var item in perguntas.Tipo4())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 1);
                    numeroPergunta++;
                }
                foreach (var item in perguntas.Tipo3())
                {
                    formulario.CriaGroupBoxes(numeroPergunta, numeroPergunta+1 + ". " + item, 2);
                    numeroPergunta++;
                }

                if (nomeAvaliada.Equals("JULIANA PINARELLI DE CURTIS"))
                {
                    formulario.CriaGroupBoxes(formulario.ContagemGrupbox(), formulario.ContagemGrupbox()+1 + ". Liderança (encoraja o trabalho em equipe, direciona e conduz projetos)", 2);
                }
            }

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
