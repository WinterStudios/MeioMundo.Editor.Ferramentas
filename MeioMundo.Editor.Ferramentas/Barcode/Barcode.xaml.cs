using MeioMundo.Editor.Ferramentas.Barcode.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeioMundo.Editor.Ferramentas.Barcode
{
    /// <summary>
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : UserControl
    {
        public Barcode()
        {
            InitializeComponent(); 

        }

        private void box_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(box.Text.Length > 0)
                image.Source = CODE_39.Draw(new Internal.Internal.Code { Content = "*" +  box.Text + "*" }, new Internal.Internal.Size { Height = 80, Width = CODE_39.Chars._0.Length });
        }
    }
}
