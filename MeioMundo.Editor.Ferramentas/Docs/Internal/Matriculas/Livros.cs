using System;
using System.Collections.Generic;
using System.IO;
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

    public static class LivrosEngine
    {
        public static List<Livros> Livros { get; set; }

        /// <summary>
        /// Load Livros from a file
        /// </summary>
        public static void Load()
        {
            if (File.Exists(DocsInternal.DataBaseDirectory + "Books.json"))
                Livros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Matriculas.Livros>>(File.ReadAllText(DocsInternal.DataBaseDirectory + "Books.json"));
            else
                Livros = new List<Livros>();
        }

        /// <summary>
        /// Save Livros in to a file
        /// </summary>
        public static void Save() => _Save(true);
        /// <summary>
        /// Save Livros in to a file
        /// </summary>
        /// <param name="format">Format the text for easy to understand</param>
        public static void Save(bool format) => _Save(format);

        /// <summary>
        /// Save Livros in to a file
        /// </summary>
        /// <param name="format">Easy to Read</param>
        private static void _Save(bool format)
        {
            Newtonsoft.Json.Formatting formatting = Newtonsoft.Json.Formatting.None;
            if (format)
                formatting = Newtonsoft.Json.Formatting.Indented;

            File.WriteAllText(DocsInternal.DataBaseDirectory + "Books.json", Newtonsoft.Json.JsonConvert.SerializeObject(Livros.GetSerialize().OrderBy(x => x.Ano).ThenBy(x=> x.Disciplina), formatting));
        }
        public static IEnumerable<Livros> GetLivrosWithCiclo(int ano)
        {
            List<Livros> livros = new List<Livros>();
            int ciclo = Anos.GetCiclo(ano);
            livros.AddRange(Livros.Where(x => x.Ano == Anos.GetName(ciclo)));
            livros.AddRange(Livros.Where(x => x.Ano == Anos.GetName(ano)));
            return livros;
        }
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
