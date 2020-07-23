using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Documentos.DataBase.Internal
{
    public class Anos
    {
        public enum Ano
        {
            

        }
        //public static string[] GetNames()
        //{
        //    string[] Names = new string[13];

        //    Names[0] = "Todos";
        //    Names[1] = "1º - Ano";
        //    Names[2] = "2º - Ano";
        //    Names[3] = "3º - Ano";
        //    Names[4] = "4º - Ano";
        //    Names[5] = "5º - Ano";
        //    Names[6] = "6º - Ano";
        //    Names[7] = "7º - Ano";
        //    Names[8] = "8º - Ano";
        //    Names[9] = "9º - Ano";
        //    Names[10] = "10º - Ano";
        //    Names[11] = "11º - Ano";
        //    Names[12] = "12º - Ano";

        //    return Names;
        //}
        public static int[] GetNames()
        {
            List<int> Y = new List<int>();
            for (int i = 0; i < 14; i++)
            {
                Y.Add(i);
            }
            return Y.ToArray();
        }
    }
}
