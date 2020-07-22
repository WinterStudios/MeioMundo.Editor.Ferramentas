using MeioMundo.Editor.Ferramentas.Documentos.DataBase.Internal;
using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
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

namespace MeioMundo.Editor.Ferramentas.Documentos.DataBase
{
    /// <summary>
    /// Interaction logic for MatriculasEditor.xaml
    /// </summary>
    public partial class MatriculasEditor : UserControl
    {
        private string DataBasePath { get => System.IO.Directory.GetCurrentDirectory() + "\\DataBase"; }
        private List<int> Anos { get; set; }
        private List<Livro> Livros { get; set; }

        public MatriculasEditor()
        {

            if (!Directory.Exists(DataBasePath))
                Directory.CreateDirectory(DataBasePath);
            
            InitializeComponent();
            LoadUI();
        }
        private void LoadUI()
        {
            UC_ComboBox_Area.Visibility = Visibility.Hidden;
            Anos = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                Anos.Add(i);
            }
            UC_ComboBox_AnoLectivo.ItemsSource = Anos;
            UC_ComboBox_Area.ItemsSource = Enum.GetValues(typeof(Matriculas.Area));
            UC_ComboBox_SelectData.SelectedIndex = 0;
            UC_DataDrid_Livros_Disciplina.ItemsSource = Enum.GetValues(typeof(Disciplina.Disciplinas));

            UC_ComboBox_SelectData_Change();
        }

        private void UC_ComboBox_AnoLectivo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = UC_ComboBox_AnoLectivo.SelectedIndex;
            if (index >= 9)
                UC_ComboBox_Area.Visibility = Visibility.Visible;
            else
                UC_ComboBox_Area.Visibility = Visibility.Hidden;
        }

        private void UC_ComboBox_SelectData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;
            UC_ComboBox_SelectData_Change();
        }

        private void UC_MenuItem_SaveLivros_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(DataBasePath + "\\Livros.json", Newtonsoft.Json.JsonConvert.SerializeObject(Livros, Newtonsoft.Json.Formatting.Indented));
        }

        private void UC_ComboBox_SelectData_Change()
        {
            if (UC_ComboBox_SelectData.SelectedIndex == 0)
            {
                Livros = new List<Livro>();
                if (File.Exists(DataBasePath + "\\Livros.json"))
                {
                    Livros = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Livro>>(File.ReadAllText(DataBasePath + "\\Livros.json"));
                    //= new List<Livro>((IEnumerable<Livro>)livros);
                }

                UC_DataGrid_Livro.ItemsSource = Livros;
                UC_DataGrid_Livro.Visibility = Visibility.Visible;
            }
        }
    }
}
