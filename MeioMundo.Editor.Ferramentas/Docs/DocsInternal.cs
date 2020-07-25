using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;


namespace MeioMundo.Editor.Ferramentas.Docs
{
    public class DocsInternal : IPlugin
    {
        public string Nome => "Criador de Documentos";
        public string Descrição => "";
        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.723-alpha.1");
        public PluginType Type => PluginType.TabPage;
        public string args => "Ferramentas/Documentos";
        public Type ObjectType => typeof(UC_DocumentosEngine);



        public static string DataBaseDirectory
        {
            get
            {
                string d = System.IO.Directory.GetCurrentDirectory() + "/DataBase/";
                if (!System.IO.Directory.Exists(d))
                    System.IO.Directory.CreateDirectory(d);
                return System.IO.Directory.GetCurrentDirectory() + "/DataBase/";
                
            }
        }
    }
}
