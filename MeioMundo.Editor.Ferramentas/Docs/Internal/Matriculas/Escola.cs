using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas
{
    public class Escola
    {
        public static Dictionary<int,string> Escolas { get
            {
                Dictionary<int, string> pairs = new Dictionary<int, string>();

                pairs.Add(0, "Oliveira do Hospital");
                pairs.Add(1, "Lagares da Beira");
                pairs.Add(2, "Cordinha");
                pairs.Add(3, "Ponte das Três Entradas");
                pairs.Add(4, "Escola Margarida F.C. da Matta - MIDÕES");
                pairs.Add(5, "Agrupamento de Escolas de Arganil");

                pairs.Add(999, "Branco");

                return pairs;
            } 
        }
        /// <summary>
        /// Get Escolas nomes as Array
        /// </summary>
        /// <returns></returns>
        public static string[] GetEscolasNomes() => Escolas.Values.ToArray();
        public static Dictionary<int, int[]> EscolaAnos { get
            {
                Dictionary<int, int[]> keyValues = new Dictionary<int, int[]>();

                keyValues.Add(0, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33, 401, 402, 403, 404, 411, 412, 413, 414, 421, 422, 423, 424 });
                keyValues.Add(1, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33 });
                keyValues.Add(2, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33 });
                keyValues.Add(3, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33 });
                keyValues.Add(4, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33 });
                keyValues.Add(5, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33, 401, 402, 403, 404, 411, 412, 413, 414, 421, 422, 423, 424 });

                keyValues.Add(999, new int[] { 11, 12, 13, 14, 21, 22, 31, 32, 33, 401, 402, 403, 404, 411, 412, 413, 414, 421, 422, 423, 424 });

                return keyValues;
            } 
        }
        /// <summary>
        /// Get the name of the school
        /// </summary>
        /// <param name="s"></param>
        /// <remarks>Return 999 if the school doesnt exits (Branco)</remarks>
        /// <returns>Return the key of the dicinionary</returns>
        public static int GetKey(string s)
        {
            int? i = Escolas.First(X => X.Value == s).Key;
            if (i == null)
                return 999;

            return i.Value;
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

    public static class Extension
    {
        
    }
}
