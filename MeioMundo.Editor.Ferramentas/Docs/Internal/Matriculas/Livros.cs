using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Livros
    {
        private int _ano;
        public string Ano { get => Anos.GetName(_ano); set => _ano = int.Parse(value); }
        private int _Disciplina;
        public string Disciplina { get => Disciplinas.GetName(_Disciplina); set => _Disciplina = int.Parse(value); }
        public long? ISBN { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

        public SerializeLivros GetSerialize()
        {
            SerializeLivros serialize = new SerializeLivros()
            {
                Ano = _ano,
                Disciplina = _Disciplina,
                ISBN = this.ISBN,
                Nome = this.Nome,
                Autor = this.Autor,
                Editora = this.Editora
            };
            return serialize;

        }

    }
    public class SerializeLivros
    {
        public int? Ano { get; set; }
        public int? Disciplina { get; set; }
        public long? ISBN { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }

    public static class Extention
    {
        public static List<SerializeLivros> GetSerialize(this IEnumerable<Livros> livros)
        {
            List<SerializeLivros> serializes = new List<SerializeLivros>();
            Livros[] livrosArray = livros.ToArray();
            for (int i = 0; i < livros.Count(); i++)
            {
                SerializeLivros serialize = new SerializeLivros()
                {
                    Ano = Anos.GetValue(livrosArray[i].Ano),
                    Disciplina = Disciplinas.GetValue(livrosArray[i].Disciplina),
                    ISBN = livrosArray[i].ISBN,
                    Nome = livrosArray[i].Nome,
                    Autor = livrosArray[i].Autor,
                    Editora = livrosArray[i].Editora
                };
                serializes.Add(serialize);
            }
            return serializes;
        }
    }
}
