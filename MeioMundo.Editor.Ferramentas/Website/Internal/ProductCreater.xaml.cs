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

namespace MeioMundo.Editor.Ferramentas.Website.Internal
{
    /// <summary>
    /// Interaction logic for ProductCreater.xaml
    /// </summary>
    public partial class ProductCreater : UserControl
    {
        List<string> Categories { get; set; } = new List<string>();
        public ProductCreater()
        {
            InitializeComponent();
            UC_ComboBox_Marcas.ItemsSource = ProductInternal.MARCAS;
            CategoriaEngine.ReturnToString _CatEngine = new CategoriaEngine.ReturnToString();
            _CatEngine.GetCategoriasToString();
            UC_ComboBox_Categories.ItemsSource = _CatEngine.CategoriasStringArray;
            
        }
        
        private void UC_ComboBox_Categories_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void UC_ComboBox_Categories_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void UC_ComboBox_Categories_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string s = ((ComboBox)sender).Text;
                API.NotificationSystem.Show(s);
                
            }
        }
    }
}
