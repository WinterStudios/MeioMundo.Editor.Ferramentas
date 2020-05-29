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
        public string Nome { get => "Codigo de Barras"; set => Nome = value; }

        public Barcode()
        {

        }

    }
}
