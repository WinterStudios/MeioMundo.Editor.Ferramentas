using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class DadosMatricula
    {
        public int Escola { get; set; }
        public Dictionary<int, _Disciplina[]> Componetes { get; set; }
    }
    public class _Disciplina
    {
        public int Disciplina { get; set; }
        public string Nome { get; set; }
        public string ISNB { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
    }
    public static class DadosMatricula_Engine
    {
        public static void Save(DadosMatricula dados)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(dados, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(DocsInternal.DataBaseDirectory + string.Format("{0}.json", Escola.Escolas[dados.Escola]), json);
        }
    }
}
