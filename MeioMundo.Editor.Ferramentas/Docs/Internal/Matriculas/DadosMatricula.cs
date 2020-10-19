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
        private long _ISBN = 0;
        public string ISNB { get { if (_ISBN != 0) return _ISBN.ToString("### ### ### ###-#"); else return ""; } set { if (!string.IsNullOrEmpty(value)) _ISBN = long.Parse(value.Replace("-", "").Replace(" ", "")); else _ISBN = 0; } }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public bool Superior { get; set; }
        public bool OP1 { get; set; }
        public bool OP2 { get; set; }
        public bool OP3 { get; set; }
        public string Nivel { get; set; }
    }
    public static class DadosMatricula_Engine
    {
        public static DadosMatricula DadosMatricula { get; set; }
        public static void Save()
        {
            DadosMatricula.Componetes.OrderBy(x => x.Key);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(DadosMatricula, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(DocsInternal.DataBaseDirectory + string.Format("{0}.json", Escola.Escolas[DadosMatricula.Escola]), json);
        }

        public static void Load(int EscolaID)
        {
            DadosMatricula = new DadosMatricula();
            DadosMatricula.Escola = EscolaID;
            DadosMatricula.Componetes = new Dictionary<int, _Disciplina[]>();
            string file = DocsInternal.DataBaseDirectory + string.Format("{0}.json", Escola.Escolas[EscolaID]);
            if (!File.Exists(file))
                return;

            DadosMatricula = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosMatricula>(File.ReadAllText(file));
        }

        public static void Update(int ano, _Disciplina row)
        {
            if (DadosMatricula.Componetes.ContainsKey(ano))
            {
                if (DadosMatricula.Componetes[ano] == null)
                {
                    List<_Disciplina> dis = new List<_Disciplina>();
                    dis.Add(row);
                    DadosMatricula.Componetes.Add(ano, dis.ToArray());
                }
                else
                {
                    List<_Disciplina> ds = DadosMatricula.Componetes[ano].Where(x => x.Disciplina != 0).ToList();
                    if (ds.Count == 0)
                        ds = new List<_Disciplina>();
                    _Disciplina disciplina = ds.FirstOrDefault(x => x.ISNB == row.ISNB);
                    if (disciplina == null)
                        ds.Add(row);
                    else
                        disciplina = row;

                    if (string.IsNullOrEmpty(row.ISNB) && row.Disciplina != 0)
                        ds.Add(row);

                    DadosMatricula.Componetes[ano] = ds.ToArray();
                }
            }
            else
            {
                List<_Disciplina> disciplinas = new List<_Disciplina>();
                disciplinas.Add(row);
                DadosMatricula.Componetes.Add(ano, disciplinas.ToArray());
            }
        }


    }
    public static class _DisciplinasExtesions
    {
        public static string[] GetNames(this IEnumerable<int> d)
        {
            List<string> dsa = new List<string>();
            foreach (var item in d)
            {
                dsa.Add(Disciplinas.GetName(item));
            }
            return dsa.ToArray();
        }
    }
}
