using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Website.Internal
{
    public class Manager
    {
        public static List<Categoria> Categorias { get; set; }
        public static void Inicialize()
        {
            Categorias = CategoriaEngine.Load();
            
        }

    }
}
