using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaiah
{
    class ConcentraRespostas
    {
        public void GeraRelatorio(List<ListaDeRespostas> todasRespostas)
        {
            FileStream fs = new FileStream("relatorio.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<meta charset=utf8>");
            sw.WriteLine("<table border=1>");
            foreach (var item in todasRespostas)
            {
                sw.WriteLine("<tr><td>" + item.nome + "</td> <td>" + item.setor + "</td> <td>" + item.resposta + "</td> </tr>");
            }
            sw.WriteLine("</table>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
        }
    }
}
