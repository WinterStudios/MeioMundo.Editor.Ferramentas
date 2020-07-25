using MeioMundo.Editor.Ferramentas.Docs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MeioMundo.Editor.Ferramentas.Docs
{
    public class Modelos
    {
        public enum Model
        {
            Matricula = 0
        }

        public Type GetModelType(Model model)
        {
            switch (model)
            {
                case Model.Matricula:
                    //return typeof(Matricula);
                    break;
                default:
                    break;
            }
            return null;
        }
    }
}
