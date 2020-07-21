using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MeioMundo.Editor.Ferramentas.Documentos
{
    public class DocManager
    {
        public static void PrintTest(Modelo_Manuais modelo)
        {
            modelo = new Modelo_Manuais();
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = modelo;
            window.ShowDialog();
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                Size size = new Size(printDialog.PrintableAreaWidth - 15, printDialog.PrintableAreaHeight - 15);
                printDialog.PrintVisual(modelo, "sda");
            }
        }
    }
}
