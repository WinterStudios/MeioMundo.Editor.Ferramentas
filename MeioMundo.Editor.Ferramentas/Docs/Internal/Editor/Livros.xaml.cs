using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
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

namespace MeioMundo.Editor.Ferramentas.Docs.Internal.Editor
{
    /// <summary>
    /// Interaction logic for Livros.xaml
    /// </summary>
    public partial class Livros : UserControl
    {

        public Livros()
        {
            InitializeComponent();
            LoadDataBase();
        }

        private void LoadDataBase()
        {
           
            UC_DataGrid_Livros.ItemsSource = LivrosEngine.Livros;
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            LivrosEngine.Save();
        }

        private void UC_DataGrid_Livros_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridColumn column = e.Column;
            if (column.Header.ToString() == "ISBN")
            {
                string s = ((TextBox)e.EditingElement).Text;
                if (string.IsNullOrEmpty(s))
                    return;
                s = s.Replace("-", "");
                Matriculas.Livros row = (Matriculas.Livros)UC_DataGrid_Livros.SelectedItem;
                row.ISBN = long.Parse(s);

                ((TextBox)e.EditingElement).Text = s;

            }
        }
    }
}
