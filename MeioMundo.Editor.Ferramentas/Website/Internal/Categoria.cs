using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeioMundo.Editor.Ferramentas.Website.Internal
{
    public class Categoria
    {
        public int TreeIndex { get; set; }
        public string Text { get; set; }
        public List<Categoria> Childrens { get; set; }
    }
}
