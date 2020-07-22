using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Documentos.DataBase.Internal
{
    public class Anos
    {
        public enum AnoLectivo
        {
            All = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Eleve = 11,
            Twelve = 12
        }
        public static string[] GetNames()
        {
            IEnumerable<int> values = (IEnumerable<int>)Enum.GetValues(typeof(AnoLectivo));
            string[] Names = new string[values.Count()];

            Names[0] = "Todos";
            Names[1] = "1º - Ano";
            Names[2] = "2º - Ano";
            Names[3] = "3º - Ano";
            Names[4] = "4º - Ano";
            Names[5] = "5º - Ano";
            Names[6] = "6º - Ano";
            Names[7] = "7º - Ano";
            Names[8] = "8º - Ano";
            Names[9] = "9º - Ano";
            Names[10] = "10º - Ano";
            Names[11] = "11º - Ano";
            Names[12] = "12º - Ano";

            return Names;
        }
    }
}
