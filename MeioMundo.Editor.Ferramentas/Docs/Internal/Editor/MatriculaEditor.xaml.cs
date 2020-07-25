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
    /// Interaction logic for Matricula.xaml
    /// </summary>
    public partial class MatriculaEditor : UserControl
    {
        public Models.Modelo_Matricula Modelo { get; set; }
        public DadosMatricula DadosMatricula { get; set; }

        private int ID_Ano { get; set; }

        public MatriculaEditor()
        {
            InitializeComponent();
            LOAD();
        }
        private void LOAD()
        {
            UC_ComboBox_Escola.ItemsSource = Escola.Escolas.Values;
        }
        private void FillTable()
        {
            if (!File.Exists(DocsInternal.DataBaseDirectory + string.Format("{0}.json", UC_ComboBox_Escola.SelectedItem.ToString())))
                return;

            DadosMatricula = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosMatricula>(File.ReadAllText(DocsInternal.DataBaseDirectory + string.Format("{0}.json", UC_ComboBox_Escola.SelectedItem.ToString())));
            Modelo.FillDataTable(DadosMatricula.Componetes[ID_Ano].ToList());
        }


        private void UC_ComboBox_Escola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;
            UC_ComboBox_Ano.ItemsSource = Escola.GetAnos(UC_ComboBox_Escola.SelectedIndex);
        }

        private void UC_ComboBox_Ano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;

            ID_Ano = Anos.GetValue(UC_ComboBox_Ano.SelectedValue.ToString()).Value;

            if (Modelo == null)
            {
                Modelo = new Models.Modelo_Matricula();
                UC_DockPanel_Modelo.Children.Add(Modelo);
            }

            string ano = UC_ComboBox_Ano.SelectedValue.ToString();
            if (ano.Contains('-'))
            {
                string[] split = ano.Split('-');
                Modelo.AnoLectivo = split[0];
                Modelo.Escola = split[1];
            }
            else
            {
                Modelo.AnoLectivo = UC_ComboBox_Ano.SelectedValue.ToString();
                Modelo.Escola = UC_ComboBox_Escola.SelectedValue.ToString();
            }

            FillTable();
        }

        private void UC_Button_SaveDados_Click(object sender, RoutedEventArgs e)
        {
            DadosMatricula = new DadosMatricula();
            DadosMatricula.Escola = this.UC_ComboBox_Escola.SelectedIndex;
            DadosMatricula.Componetes = new Dictionary<int, _Disciplina[]>();
            List<_Disciplina> _Disciplinas = new List<_Disciplina>();
            _Disciplinas.Add(new _Disciplina
            {
                Disciplina = 10,
                ISNB = "9789896479886",
                Nome = "Eureka! - Português - 1.º Ano",
                Autor = "António Marcelino",
                Editora = "Areal Editores"
            });
            _Disciplinas.Add(new _Disciplina
            {
                Disciplina = 30,
                ISNB = "9789896479909",
                Nome = "Eureka! - Matematica - 1.º Ano",
                Autor = "Angelina Rodrigues",
                Editora = "Areal Editores"
            });
            _Disciplinas.Add(new _Disciplina
            {
                Disciplina = 40,
                ISNB = "9789897670978",
                Nome = "Eureka! - Estudo do Meio - 1.º Ano",
                Autor = "Angelina Rodrigues",
                Editora = "Areal Editores"
            });
            DadosMatricula.Componetes.Add(11, _Disciplinas.ToArray());
            DadosMatricula_Engine.Save(DadosMatricula);
        }

        private void UC_CheckBox_Editor_Click(object sender, RoutedEventArgs e)
        {
            Modelo.EditMode = UC_CheckBox_Editor.IsChecked.Value;
        }
    }
}
