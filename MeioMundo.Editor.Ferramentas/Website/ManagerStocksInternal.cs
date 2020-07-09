using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;

namespace MeioMundo.Editor.Ferramentas.Website
{
    public class ManagerStocksInternal : IPlugin
    {
        public string Nome => "Gestor de Stock";
        public string Descrição => "Permite gerir os stock do site";
        public VersionSystem Version => VersionSystem.SetVersion("v.0.0.1-alpha.1");
        public PluginType Type => PluginType.TabPage;
        public string args => "Ferramentas/Gertor de Stocks";
        public Type ObjectType => typeof(ManagerStocks);
    }
}
