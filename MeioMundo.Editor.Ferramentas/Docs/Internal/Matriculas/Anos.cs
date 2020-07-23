using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Anos
    {
        public static Dictionary<int,string> Ano { get
            {
                Dictionary<int, string> keys = new Dictionary<int, string>();
                keys.Add(0, "Todos");

                keys.Add(11, "1º Ano");
                keys.Add(12, "2º Ano");
                keys.Add(13, "3º Ano");
                keys.Add(14, "4º Ano");

                keys.Add(21, "5º Ano");
                keys.Add(22, "6º Ano");

                keys.Add(31, "7º Ano");
                keys.Add(32, "8º Ano");
                keys.Add(33, "9º Ano");

                keys.Add(41, "10º Ano - Cientifico");
                

                return keys;
            } }
        public static string[] GetValues()
        {
            string[] values = Ano.Values.ToArray();
            return values;
        }
    }
}
