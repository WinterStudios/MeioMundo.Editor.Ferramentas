using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundoEditor.API.Plugin;

namespace MeioMundo.Editor.Ferramentas.Barcode
{
    public class Barcode : Plugin
    {
        public string PluginName => "Barcode";
        public string PluginDescription => "Permite criar codigos de barras e qr codes";
        public PluginType PluginType => throw new NotImplementedException();
        public string PluginMenuItemLocation => throw new NotImplementedException();
        public PluginInfo PluginInfo => new PluginInfo { Nome = "Barcode", Versão = "0.1.32" };

        public Barcode()
        {

        }


    }
}
