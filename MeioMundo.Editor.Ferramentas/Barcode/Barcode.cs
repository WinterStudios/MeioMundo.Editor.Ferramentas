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
        public string Name => "Codigo de Barras";
        public string Description => "Permite Gerar Codigos de Barras e de Data";
        public Barcode()
        {

        }
    }
}
