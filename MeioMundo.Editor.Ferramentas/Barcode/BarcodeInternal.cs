using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundo.Editor.API;
using MeioMundo.Editor.API.Plugin;

namespace MeioMundo.Editor.Ferramentas.Barcode
{
    class BarcodeInternal : IPlugin
    {
        public string Nome => "Codigo de Barras";
        public string Descrição => "Permite criar codigos de barras e codigos bidemensionais";
        VersionSystem IPlugin.Version => VersionSystem.SetVersion("0.0.1-alpha");
        PluginType IPlugin.Type =>  PluginType.TabPage;
        string IPlugin.args => "Ferramentas/Codigo de Barras";
        Type IPlugin.ObjectType => typeof(Barcode);
    }
}
