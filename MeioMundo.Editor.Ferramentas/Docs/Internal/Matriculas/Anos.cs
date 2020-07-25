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

                keys.Add(10, "1º Ciclo");
                keys.Add(11, "1º Ano");
                keys.Add(12, "2º Ano");
                keys.Add(13, "3º Ano");
                keys.Add(14, "4º Ano");

                keys.Add(20, "2º Ciclo");
                keys.Add(21, "5º Ano");
                keys.Add(22, "6º Ano");

                keys.Add(30, "3º Ciclo");
                keys.Add(31, "7º Ano");
                keys.Add(32, "8º Ano");
                keys.Add(33, "9º Ano");

                keys.Add(400, "Secundario");
                keys.Add(401, "10º Ano - Cientifico");
                keys.Add(402, "10º Ano - Humanidades");
                keys.Add(403, "10º Ano - Arte");
                keys.Add(404, "10º Ano - Economia");
                keys.Add(411, "11º Ano - Cientifico");
                keys.Add(412, "11º Ano - Humanidades");
                keys.Add(413, "11º Ano - Arte");
                keys.Add(414, "11º Ano - Economia");
                keys.Add(421, "12º Ano - Cientifico");
                keys.Add(422, "12º Ano - Humanidades");
                keys.Add(423, "12º Ano - Arte");
                keys.Add(424, "12º Ano - Economia");


                return keys;
            } }


        public static Dictionary<int, int[]> Disciplinas { get
            {
                Dictionary<int, int[]> keys = new Dictionary<int, int[]>();
                keys.Add(11, new int[] { 10, 30, 40 });
                keys.Add(12, new int[] { 10, 30, 40 });
                keys.Add(13, new int[] { 10, 30, 40, 11 });
                keys.Add(14, new int[] { 10, 30, 40, 11 });


                return null;
            } }


        public static string[] GetValues()
        {
            string[] values = Ano.Values.ToArray();
            return values;
        }
        public static string GetName(int index)
        {
            if (!Ano.ContainsKey(index))
                return "";
            return Ano[index];
        }
        public static int? GetValue(string name)
        {
            int value = Ano.First(x => x.Value == name).Key;
            return value;
        }
    }
}
