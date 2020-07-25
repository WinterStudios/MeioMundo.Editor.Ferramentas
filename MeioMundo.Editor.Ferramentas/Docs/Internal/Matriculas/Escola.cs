using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    class Escola
    {
        public static Dictionary<int,string> Escolas { get
            {
                Dictionary<int, string> pairs = new Dictionary<int, string>();

                pairs.Add(0, "Oliveira do Hospital");


                return pairs;
            } 
        }

        public static Dictionary<int, int[]> EscolaAnos { get
            {
                Dictionary<int, int[]> keyValues = new Dictionary<int, int[]>();

                keyValues.Add(0, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33, 401, 402, 403, 404, 411, 412, 413, 414, 421, 422, 423, 424 });

                return keyValues;
            } 
        }


        public static string[] GetAnos(int escolaIndex)
        {
            int[] anos = new int[0];
            EscolaAnos.TryGetValue(escolaIndex, out anos);
            string[] anosNomes = new string[anos.Length];
            for (int i = 0; i < anos.Length; i++)
            {
                anosNomes[i] = Anos.Ano[anos[i]];
            }
            return anosNomes;
        }
    }
}
