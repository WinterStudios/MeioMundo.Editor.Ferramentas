using MeioMundo.Editor.Ferramentas.Documentos.DataBase;
using Microsoft.Win32;
using Newtonsoft.Json;
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

namespace MeioMundo.Editor.Ferramentas.Documentos
{
    /// <summary>
    /// Interaction logic for UC_Documentos.xaml
    /// </summary>
    public partial class UC_Documentos : UserControl
    {
        public UC_Documentos()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DocManager.PrintTest(modelo);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            MatriculasEditor editor = new MatriculasEditor();
            window.SizeToContent = SizeToContent.Height;
            window.Content = editor;
            window.Show();
        }
    }
}
