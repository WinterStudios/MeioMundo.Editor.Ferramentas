using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Website.Internal
{
    public class ProductInternal
    {
        private static string webPath { get => Directory.GetCurrentDirectory() + "/Data/Web/"; }
        private static string marcasPath { get => Directory.GetCurrentDirectory() + "/Data/Web/_marcas.json"; }

        public static string[] MARCAS
        {
            get
            {
                if (!Directory.Exists(webPath))
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/Data/Web");

                string[] t_marcas = new string[0];

                t_marcas = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(File.ReadAllText(marcasPath));

                return t_marcas;
            }
            set 
            {
                File.WriteAllText(marcasPath, Newtonsoft.Json.JsonConvert.SerializeObject(value));
            }
        }


    }
}
