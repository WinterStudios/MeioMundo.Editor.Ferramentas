using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Componentes
    {
        public string Disciplina { get; set; }
        public string ISBN { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public static Componentes[] GetComponentes(List<Livros> livros)
        {
            return null;
        }
    }
}
