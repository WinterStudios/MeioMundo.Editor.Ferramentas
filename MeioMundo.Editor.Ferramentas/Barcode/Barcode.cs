using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeioMundoEditor.API.Plugin;

namespace MeioMundo.Editor.Ferramentas.Barcode
{
    public class Barcode : IPlugin
    {
        public string Nome => "Codigo de Barras";
        public string Descrição => "Permite Criar Codigos";
        public string Versão => "0.0.31";
        public string[] Args => new string[] { "Ferramentas/Gerar Codigos" };
        public PluginType Type => PluginType.TabPage;

        public Barcode()
        {

        }

        
    }
}
