using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MeioMundo.Editor.Ferramentas.Documentos.DataBase.Internal
{
    public class Livro
    {
        public int Ano { get; set; }
        public Disciplina.Disciplinas? Disciplina { get; set; }
        public string Nome { get; set; }
        public long ISBN { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
    }
}
