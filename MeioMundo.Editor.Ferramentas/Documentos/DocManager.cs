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
        public static void PrintTest()
        {
            Modelo_Manuais modelo = new Modelo_Manuais();
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                Size size = new Size(printDialog.PrintableAreaWidth - 15, printDialog.PrintableAreaHeight - 15);
                printDialog.PrintVisual(modelo, "sda");
            }
        }
    }
}
