using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaiah
{
    public class ListaDeRespostas
    {
        public string nome;
        public string setor;
        public string pergunta;
        public string resposta;

        public ListaDeRespostas(string nomeFunc, string setorFunc, string _pergunta, string respostaFunc)
        {
            nome = nomeFunc;
            setor = setorFunc;
            pergunta = _pergunta;
            resposta = respostaFunc;
        }
    }
}
