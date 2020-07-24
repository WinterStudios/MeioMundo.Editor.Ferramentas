using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Disciplinas
    {
        public static Dictionary<int,string> Disciplina { get
            {
                Dictionary<int, string> keys = new Dictionary<int, string>();
                keys.Add(10, "Portuges");
                keys.Add(11, "Ingles");


                return keys;
            } }

        public static string GetName(int index)
        {
            if (Disciplina.ContainsKey(index))
                return Disciplina[index];
            else
                return "Unknow";
        }
    }
}
