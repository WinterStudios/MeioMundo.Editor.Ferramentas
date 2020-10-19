using MeioMundo.Editor.Ferramentas.Website.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MeioMundo.Editor.Ferramentas.Website
{
    /// <summary>
    /// Interaction logic for WebSiteManager.xaml
    /// </summary>
    public partial class WebSiteManager : UserControl
    {
        public WebSiteManager()
        {
            InitializeComponent();
        }
        private void OpenCreateProduct()
        {
            Window window = new Window();
            ProductCreater product = new ProductCreater();
            ScrollViewer viewer = new ScrollViewer();
            viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            window.Content = viewer;
            window.SizeToContent = SizeToContent.Manual;
            viewer.Content = product;
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenCreateProduct();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(new Categoria { Text = "Papelaria", Childrens = new List<Categoria>() { new Categoria { Text = "Mochilas" } } });
            CategoriaEngine.Save(categorias);
        }
    }
}
