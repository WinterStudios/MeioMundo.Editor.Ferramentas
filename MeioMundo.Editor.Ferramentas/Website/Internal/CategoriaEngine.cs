using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MeioMundo.Editor.Ferramentas.Website.Internal
{
    public class CategoriaEngine
    {
        private static string categoriasPath { get => Directory.GetCurrentDirectory() + "/Data/Web/_categorias.json"; }
        public static List<Categoria> Categorias { get => Load(); }
        public static void Save(List<Categoria> categorias)
        {
            File.WriteAllText(categoriasPath, JsonConvert.SerializeObject(categorias, Formatting.Indented));
        }
        public static List<Categoria> Load()
        {
            List<Categoria> categorias = new List<Categoria>();
            if (File.Exists(categoriasPath))
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(File.ReadAllText(categoriasPath));
            return categorias;
        }

        public struct ReturnToString
        {
            public List<string> CategoriasStringArray { get; private set; }
            public void GetCategoriasToString()
            {
                if (CategoriasStringArray == null)
                    CategoriasStringArray = new List<string>();
                int tree = 0;
                int index = 0;
                string space = string.Empty;
                for (int i = 0; i < tree * 3; i++)
                {
                    space += " ";
                }

                while (index != Categorias.Count)
                {
                    CategoriasStringArray.Add(space + Categorias[index].Text);
                    if (Categorias[index].Childrens != null)
                        if (Categorias[index].Childrens.Count > 0)
                            GetCategoriasToString(Categorias[index].Childrens, tree + 1);

                    index++;
                }
            }
            public void GetCategoriasToString(List<Categoria> childrens, int tree)
            {

                int index = 0;
                string space = string.Empty;
                for (int i = 0; i < tree * 3; i++)
                {
                    space += " ";
                }

                while (index != childrens.Count)
                {
                    CategoriasStringArray.Add(space + childrens[index].Text);
                    if (childrens[index].Childrens != null)
                        if (childrens[index].Childrens.Count > 0)
                            GetCategoriasToString(childrens[index].Childrens, tree + 1);

                    index++;
                }
            }
        }
        
        
        
    }
}
