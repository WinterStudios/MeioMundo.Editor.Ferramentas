using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeioMundo.Editor.Ferramentas.Documentos.DataBase
{
    public class Matriculas
    {

        public class AnoLectivo
        {
            public int Ano { get; set; }
            public Area? Area { get; set; }
            public IEnumerable<Disciplina> Disciplina { get; set; }
        }
        public enum Area
        {
            Artes,
            Cientificos,
            Humanidades,
        }
        public class Disciplina
        {
            public string Name { get; set; }
            public bool ComponenteEspecifica { get; set; }
            public Livro Manual { get; set; }
        }
        public class Livro
        {
            public string Nome { get; set; }
            public long ISBN { get; set; }
            public string Autor { get; set; }
            public string Editora { get; set; }
        }
    }
}
