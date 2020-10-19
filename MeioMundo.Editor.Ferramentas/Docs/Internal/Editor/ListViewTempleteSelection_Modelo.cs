using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Editor
{
    public class ListViewTempleteSelection_Modelo : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            
            return (DataTemplate)element.FindResource("DataTempate_Normal");
        }
    }
}
