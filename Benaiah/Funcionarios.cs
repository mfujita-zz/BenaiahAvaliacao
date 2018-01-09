using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaiah
{
    class Funcionarios
    {
        public string Funcionario { get; set; }
        public string Setor { get; set; }
        public string Senha { get; set; }

        //public Funcionarios(string nome, string _setor)
        //{
        //    Funcionario = nome;
        //    Setor = _setor;
        //}

        public Funcionarios(string nome, string _setor, string _senha)
        {
            Funcionario = nome;
            Setor = _setor;
            Senha = _senha;
        }
    }
}
