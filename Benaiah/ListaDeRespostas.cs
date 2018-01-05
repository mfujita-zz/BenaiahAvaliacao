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
        public string resposta;

        public ListaDeRespostas(string nomeFunc, string setorFunc, string respostaFunc)
        {
            nome = nomeFunc;
            setor = setorFunc;
            resposta = respostaFunc;
        }
    }
}
