using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Livros
    {
        public int? Ano { get; set; }
        private string _Disciplina;
        public string Disciplina { get => _Disciplina; set => _Disciplina = Disciplinas.GetName(int.Parse(value)); }
        public long? ISBN { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

    }
}
