using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MeioMundo.Editor.Ferramentas.Docs.Models
{
    public class Matriculas : UserControl
    {
        public Matriculas()
        {
            Grid grid = new Grid();
            RowDefinition RowMenu = new RowDefinition();
            RowMenu.Height = new System.Windows.GridLength(32);
            RowDefinition RowModelo = new RowDefinition();
            RowMenu.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
            grid.RowDefinitions.Add(RowMenu);
            grid.RowDefinitions.Add(RowModelo);
        }
    }
}
