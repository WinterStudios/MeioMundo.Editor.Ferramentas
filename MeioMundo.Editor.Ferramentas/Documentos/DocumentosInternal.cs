using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Documentos
{
    public class DocumentosInternal : IPlugin
    {
        public string Nome => "Documentos";

        public string Descrição => "Documentos";

        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.1-alpha.1");

        public PluginType Type => PluginType.TabPage;

        public string args => "Ferramentas/Gertor de Documentos";

        public Type ObjectType => typeof(UC_Documentos);
    }
}
