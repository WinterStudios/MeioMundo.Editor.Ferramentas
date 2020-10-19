using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;

namespace MeioMundo.Editor.Ferramentas.Website
{
    public class WebSiteManagerInternal : IPlugin
    {
        public string Nome => "Gestor WebSite";
        public string Descrição => "Permie gerir o site";
        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.1-alpha.1");
        public PluginType Type => PluginType.TabPage;
        public string args => "Ferramentas/WebSite/Gestor";
        public Type ObjectType => typeof(WebSiteManager);
    }
}
