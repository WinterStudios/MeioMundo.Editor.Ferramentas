using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Models.Modelo_Modern_Matricula Modelo_Modern { get; set; }
        public DadosMatricula DadosMatricula { get; set; }

        private int ID_Ano { get; set; }

        

        public MatriculaEditor()
        {
            InitializeComponent();
            LOAD();
            LivrosEngine.Load();
            
        }
        private void LOAD()
        {
            UC_ComboBox_Escola.ItemsSource = Escola.GetEscolasNomes();
            UC_TabPage_TI_Disciplinas.ItemsSource = Disciplinas.Disciplina;
        }


        private void UC_ComboBox_Escola_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (!this.IsLoaded)
                return;


            DadosMatricula_Engine.Load(Escola.GetKey(UC_ComboBox_Escola.SelectedItem.ToString()));

            DadosMatricula = new DadosMatricula();
            DadosMatricula = DadosMatricula_Engine.DadosMatricula;

            if (UC_ComboBox_Ano.Items.Count > 0 && UC_ComboBox_Ano.SelectedItem != null && Anos.GetValue(UC_ComboBox_Ano.SelectedItem.ToString()).GetValueOrDefault() > DadosMatricula.Componetes.Keys.Max())
                UC_ComboBox_Ano.SelectedIndex = DadosMatricula.Componetes.Keys.Count - 1;

            UC_ComboBox_Ano.ItemsSource = Escola.GetAnos(Escola.GetKey(UC_ComboBox_Escola.SelectedItem.ToString()));
            if (UC_ComboBox_Ano.SelectedItem != null)
            {
                UpdateModelo();
                UpdateModeloModern();
            }

        }
        private void UpdateModelo() 
        {
            ID_Ano = Anos.GetValue(UC_ComboBox_Ano.SelectedValue.ToString()).Value;
            UC_TabPage_TI_DG_Livros.ItemsSource = LivrosEngine.GetLivrosWithCiclo(ID_Ano).OrderBy(x => x.Ano).ThenBy(x => Disciplinas.GetValue(x.Disciplina));
            if (Modelo == null && Modelo_Modern == null)
            {
                Modelo = new Models.Modelo_Matricula();
                Modelo.EditorMode();
                Modelo.Editor = this;

                Modelo_Modern = new Models.Modelo_Modern_Matricula();
                Modelo_Modern.EditorMode();
                Modelo_Modern.Editor = this;

                UC_DockPanel_Modelo.Children.Add(Modelo);
            }
            string ano = UC_ComboBox_Ano.SelectedValue.ToString();
            
            if (ano.Contains('-'))
            {
                string[] split = ano.Split('-');
                Modelo.AnoLectivo = split[0];
                Modelo.Escola = split[1];
                Modelo.EnsinoSuperior = true;
            }
            else
            {
                Modelo.EnsinoSuperior = false;
                Modelo.AnoLectivo = UC_ComboBox_Ano.SelectedValue.ToString();
                Modelo.Escola = UC_ComboBox_Escola.SelectedValue.ToString();
            }
            if (Anos.GetCiclo(ID_Ano) == 10)
            {
                Modelo.Primeiro_Ciclo = true;
                Modelo_Modern.Primeiro_Ciclo = true;
            }
            else
            {
                Modelo.Primeiro_Ciclo = false;
                Modelo_Modern.Primeiro_Ciclo = false;
            }
            if (Escola.GetKey(UC_ComboBox_Escola.SelectedItem.ToString()) == 999)
                Modelo.Escola = "";
            Modelo._Ano = ID_Ano;

            Modelo.disciplinasGeral = new List<_Disciplina>();
            Modelo.disciplinasEspecifica = new List<_Disciplina>();

            if (DadosMatricula.Componetes.ContainsKey(ID_Ano))
            {
                Modelo.disciplinasGeral = DadosMatricula.Componetes[ID_Ano].Where(x => x.Superior == false).ToList();
                Modelo.disciplinasEspecifica = DadosMatricula.Componetes[ID_Ano].Where(x => x.Superior == true).ToList();
            }
            if (UC_ComboBox_ModelVersion.SelectedItem == null)
                UC_ComboBox_ModelVersion.SelectedIndex = 0;
            Modelo.FillTablesEmpty();
        }
        private void UC_ComboBox_Ano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;

            UpdateModelo();
            UpdateModeloModern();
        }

        private void UC_Button_SaveDados_Click(object sender, RoutedEventArgs e)
        {
            // DadosMatricula = new DadosMatricula();
            // DadosMatricula.Escola = this.UC_ComboBox_Escola.SelectedIndex;
            // DadosMatricula.Componetes = new Dictionary<int, _Disciplina[]>();
            // 
            // for (int i = 0; i < Modelo.Disciplinas.Count; i++)
            // {
            //     DadosMatricula.Componetes.Add(Anos.GetValue(UC_ComboBox_Ano.Items[i].ToString()).GetValueOrDefault(), DadosMatricula.Componetes);
            // }

            // DadosMatricula dados = new DadosMatricula();
            // dados.Escola = DadosMatricula.Escola;
            // dados.Componetes = DadosMatricula.Componetes;
            // int[] anos = DadosMatricula.Componetes.Keys.ToArray();
            // 
            // for (int i = 0; i < anos.Length; i++)
            // {
            //     List<_Disciplina> disciplinas = new List<_Disciplina>();
            //     disciplinas.AddRange(Modelo.disciplinasGeral.ToList());
            //     disciplinas.AddRange(Modelo.disciplinasEspecifica.ToList());
            //     dados.Componetes.Add(anos[i], disciplinas.Where(x => x.Disciplina != 0).ToArray());
            // }
            
            DadosMatricula_Engine.Save();
        }

        private void UC_CheckBox_Editor_Click(object sender, RoutedEventArgs e)
        {
            Modelo.EditMode = UC_CheckBox_Editor.IsChecked.Value;
            Modelo_Modern.EditMode = UC_CheckBox_Editor.IsChecked.Value;
        }

        private void UC_Button_Print_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            Viewbox viewbox = new Viewbox();
            window.Content = viewbox;
            if (UC_ComboBox_ModelVersion.SelectedIndex == 0)
            {
                Models.Modelo_Matricula matricula = new Models.Modelo_Matricula();
                matricula.disciplinasGeral = Modelo.disciplinasGeral;
                matricula.DisciplinasEspecificasNomes = Modelo.DisciplinasEspecificasNomes;
                matricula.EnsinoSuperior = Modelo.EnsinoSuperior;
                matricula.UC_TextBlock_Ano.Text = Modelo.UC_TextBlock_Ano.Text;
                matricula.UC_TextBlock_Escola.Text = Modelo.UC_TextBlock_Escola.Text;
                matricula.disciplinasEspecifica = Modelo.disciplinasEspecifica;
                matricula.Primeiro_Ciclo = Modelo.Primeiro_Ciclo;
                matricula.FillTablesEmpty();

                viewbox.Child = matricula;

                window.SizeToContent = SizeToContent.Width;
                window.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.8f);
                //window.Width = (double)new LengthConverter().ConvertFrom("21cm");
                //window.Height = (double)new LengthConverter().ConvertFrom("29.7cm");
                window.Show();
                PrintDialog print = new PrintDialog();
                if (print.ShowDialog() == true)
                {
                    print.PrintVisual(matricula, string.Format("{0} - {1}", matricula.AnoLectivo, matricula.Escola));
                    window.Close();
                }
            }

            if(UC_ComboBox_ModelVersion.SelectedIndex == 1)
            {
                Models.Modelo_Modern_Matricula matricula = new Models.Modelo_Modern_Matricula();
                matricula.disciplinasGeral = Modelo_Modern.disciplinasGeral;
                matricula.DisciplinasEspecificasNomes = Modelo_Modern.DisciplinasEspecificasNomes;
                matricula.EnsinoSuperior = Modelo_Modern.EnsinoSuperior;
                matricula.UC_TextBlock_Ano.Text = Modelo_Modern.UC_TextBlock_Ano.Text;
                matricula.UC_TextBlock_Escola.Text = Modelo_Modern.UC_TextBlock_Escola.Text;
                matricula.disciplinasEspecifica = Modelo_Modern.disciplinasEspecifica;
                matricula.Primeiro_Ciclo = Modelo_Modern.Primeiro_Ciclo;
                matricula.FillTablesEmpty();
                
                matricula.Escola = Modelo_Modern.UC_TextBlock_Escola.Text;
                RenderOptions.SetBitmapScalingMode(matricula, BitmapScalingMode.HighQuality);
                RenderOptions.SetEdgeMode(matricula, EdgeMode.Unspecified);
                matricula.SnapsToDevicePixels = true;
                viewbox.Child = matricula;

                window.SizeToContent = SizeToContent.Width;
                window.Height = (System.Windows.SystemParameters.PrimaryScreenHeight * 0.8f);
                //window.Width = (double)new LengthConverter().ConvertFrom("21cm");
                //window.Height = (double)new LengthConverter().ConvertFrom("29.7cm");
                window.Show();
                PrintDialog print = new PrintDialog();
                if (print.ShowDialog() == true)
                {
                    print.PrintVisual(matricula, string.Format("{0} - {1}", matricula.AnoLectivo, matricula.Escola));
                    window.Close();
                }
            }
            

        }

        private void UC_Button_LivrosEditor_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            Livros livros = new Livros();
            livros.UpdateLayout();
            window.Content = livros;
            window.SizeToContent = SizeToContent.Manual;
            window.Show();
        }

        private void UC_TabPage_TI_DG_Livros_MouseMove(object sender, MouseEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if(grid != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Matriculas.Livros livro = (Matriculas.Livros)grid.SelectedItem;
                DragDrop.DoDragDrop(grid, livro, DragDropEffects.Copy);
            }

        }
        private void UC_TabPage_TI_Disciplinas_MouseMove(object sender, MouseEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            if (grid != null && e.LeftButton == MouseButtonState.Pressed && UC_TabPage_TI_Disciplinas.SelectedItem != null)
            {
                int id = ((KeyValuePair<int, string>)grid.SelectedItem).Key;
                DragDrop.DoDragDrop(grid, id, DragDropEffects.Copy);
            }

        }

        private void UC_ComboBox_ModelVersion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            UC_DockPanel_Modelo.Children.Clear();
            if (UC_ComboBox_ModelVersion.SelectedIndex == 0)
            {
                UC_DockPanel_Modelo.Children.Add(Modelo);
                UpdateModelo();
            }
            if (UC_ComboBox_ModelVersion.SelectedIndex == 1)
            {
                if (Modelo_Modern == null)
                    Modelo_Modern = new Models.Modelo_Modern_Matricula();
                UC_DockPanel_Modelo.Children.Add(Modelo_Modern);
                Modelo_Modern.EditorMode();
                UpdateModeloModern();
            }

        }


        private void UpdateModeloModern()
        {
            ID_Ano = Anos.GetValue(UC_ComboBox_Ano.SelectedValue.ToString()).Value;
            UC_TabPage_TI_DG_Livros.ItemsSource = LivrosEngine.GetLivrosWithCiclo(ID_Ano).OrderBy(x => x.Ano).ThenBy(x => Disciplinas.GetValue(x.Disciplina));
            if (Modelo_Modern == null)
            {
                Modelo_Modern = new Models.Modelo_Modern_Matricula();
                Modelo_Modern.EditorMode();
                Modelo_Modern.Editor = this;
                UC_DockPanel_Modelo.Children.Add(Modelo_Modern);
            }
            string ano = UC_ComboBox_Ano.SelectedValue.ToString();

            if (ano.Contains('-'))
            {
                string[] split = ano.Split('-');
                Modelo_Modern.AnoLectivo = split[0];
                Modelo_Modern.Escola = split[1];
                Modelo_Modern.EnsinoSuperior = true;
            }
            else
            {
                Modelo_Modern.EnsinoSuperior = false;
                Modelo_Modern.AnoLectivo = UC_ComboBox_Ano.SelectedValue.ToString();
                Modelo_Modern.Escola = UC_ComboBox_Escola.SelectedValue.ToString();
            }
            if (Escola.GetKey(UC_ComboBox_Escola.SelectedItem.ToString()) == 999)
                Modelo_Modern.Escola = "";
            Modelo_Modern._Ano = ID_Ano;

            Modelo_Modern.disciplinasGeral = new List<_Disciplina>();
            Modelo_Modern.disciplinasEspecifica = new List<_Disciplina>();

            if (DadosMatricula.Componetes.ContainsKey(ID_Ano))
            {
                Modelo_Modern.disciplinasGeral = DadosMatricula.Componetes[ID_Ano].Where(x => x.Superior == false).ToList();
                Modelo_Modern.disciplinasEspecifica = DadosMatricula.Componetes[ID_Ano].Where(x => x.Superior == true).ToList();
            }

            Modelo_Modern.FillTablesEmpty();
        }

    }
}
