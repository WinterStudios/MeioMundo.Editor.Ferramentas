using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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

namespace MeioMundo.Editor.Ferramentas.Docs.Models
{
    /// <summary>
    /// Interaction logic for Matricula.xaml
    /// </summary>
    public partial class Modelo_Modern_Matricula : UserControl
    {
        public string AnoLectivo { get => UC_TextBlock_Ano.Text; set => UC_TextBlock_Ano.Text = value; }
        public int _Ano;
        public string Escola { get => UC_TextBlock_Escola.Text; set => UC_TextBlock_Escola.Text = value.ToUpper(); }
        public List<_Disciplina> Disciplinas { get => Editor.DadosMatricula.Componetes[_Ano].ToList(); set => Editor.DadosMatricula.Componetes[_Ano] = value.ToArray(); }
        public Internal.Editor.MatriculaEditor Editor { get; set; }
        private bool _EnsinoSuperior;
        public bool EnsinoSuperior
        {
            get => _EnsinoSuperior;
            set
            {
                bool b = value;
                _EnsinoSuperior = b;
                if (b)
                {
                    CompGeral = 9;
                    CompEspecifica = 6;
                    UC_Border_ComponeteEspecifica.Visibility = Visibility.Visible;
                    UC_DataGrid_CE.Visibility = Visibility.Visible;

                    Grid.SetColumnSpan(UC_ListView_CG_1, 1);
                    Grid.SetColumnSpan(UC_Border_List_CG_1, 1);
                    UC_ListView_CE_1.Visibility = Visibility.Visible;
                    UC_Border_List_CE_1.Visibility = Visibility.Visible;

                    Grid.SetColumnSpan(UC_ListView_CG_2, 1);
                    Grid.SetColumnSpan(UC_Border_List_CG_2, 1);
                    UC_ListView_CE_2.Visibility = Visibility.Visible;
                    UC_Border_List_CE_2.Visibility = Visibility.Visible;

                    Grid.SetColumnSpan(UC_ListView_CG_3, 1);
                    Grid.SetColumnSpan(UC_Border_List_CG_3, 1);
                    UC_ListView_CE_3.Visibility = Visibility.Visible;
                    UC_Border_List_CE_3.Visibility = Visibility.Visible;
                }
                else
                {
                    CompGeral = 15;
                    CompEspecifica = 0;
                    UC_Border_ComponeteEspecifica.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CE.Visibility = Visibility.Collapsed;
                    Grid.SetColumnSpan(UC_ListView_CG_1, 3);
                    Grid.SetColumnSpan(UC_Border_List_CG_1, 3);
                    UC_ListView_CE_1.Visibility = Visibility.Collapsed;
                    UC_Border_List_CE_1.Visibility = Visibility.Collapsed;

                    Grid.SetColumnSpan(UC_ListView_CG_2, 3);
                    Grid.SetColumnSpan(UC_Border_List_CG_2, 3);
                    UC_ListView_CE_2.Visibility = Visibility.Collapsed;
                    UC_Border_List_CE_2.Visibility = Visibility.Collapsed;

                    Grid.SetColumnSpan(UC_ListView_CG_3, 3);
                    Grid.SetColumnSpan(UC_Border_List_CG_3, 3);
                    UC_ListView_CE_3.Visibility = Visibility.Collapsed;
                    UC_Border_List_CE_3.Visibility = Visibility.Collapsed;
                }
            }
        }
        public bool Primeiro_Ciclo { get; set; }
        public int CompGeral { get; private set; }
        public int CompEspecifica { get; private set; }
        public const int MaxDataGridLines = 15;

        bool canEdit = false;
        public bool EditMode
        {
            get => canEdit;
            set
            {
                canEdit = value;
                UC_DataGrid_CG.IsReadOnly = !value;
                UC_DataGrid_CE.IsReadOnly = !value;
                UC_TextBlock_Escola.Focusable = value;
                if (canEdit)
                {
                    UC_DataGrid_CG.HeadersVisibility = DataGridHeadersVisibility.Column;
                    UC_DataGrid_CG_OP_1.Visibility = Visibility.Visible;
                    UC_DataGrid_CG_OP_2.Visibility = Visibility.Visible;
                    UC_DataGrid_CG_OP_3.Visibility = Visibility.Visible;
                    UC_DataGrid_CG_N.Visibility = Visibility.Visible;
                    UC_DataGrid_CE_OP_1.Visibility = Visibility.Visible;
                    UC_DataGrid_CE_OP_2.Visibility = Visibility.Visible;
                    UC_DataGrid_CE_OP_3.Visibility = Visibility.Visible;
                    UC_DataGrid_CE_N.Visibility = Visibility.Visible;
                }
                else
                {
                    UC_DataGrid_CG.HeadersVisibility = DataGridHeadersVisibility.None;
                    UC_DataGrid_CG_OP_1.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CG_OP_2.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CG_OP_3.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CG_N.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CE_OP_1.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CE_OP_2.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CE_OP_3.Visibility = Visibility.Collapsed;
                    UC_DataGrid_CE_N.Visibility = Visibility.Collapsed;
                }
            }
        }

        public List<_Disciplina> disciplinasGeral { get; set; }
        public List<_Disciplina> disciplinasEspecifica { get; set; }
        public List<string> DisciplinasGeralNomes { get; set; }
        public List<string> DisciplinasEspecificasNomes { get; set; }

        public Modelo_Modern_Matricula()
        {
            InitializeComponent();
            // Disciplinas = new List<_Disciplina>();
            // UC_DataGrid_CG.ItemsSource = Disciplinas;
            // FillDataTable();
        }

        public void EditorMode()
        {
            RenderOptions.SetEdgeMode(this, EdgeMode.Unspecified);
            RenderOptions.SetBitmapScalingMode(this, BitmapScalingMode.Linear);
        }

        public void LoadCoponentes()
        {

        }
        public void FillTablesEmpty()
        {
            UC_Border_Select_1.Visibility = Visibility.Collapsed;
            UC_Border_Select_2.Visibility = Visibility.Collapsed;
            UC_Border_Select_3.Visibility = Visibility.Collapsed;
            UC_Border_Select_4.Visibility = Visibility.Collapsed;

            UC_StackPanel_Op1.Visibility = Visibility.Collapsed;


            if (EnsinoSuperior)
            {
                int totalDis = disciplinasGeral.Count + disciplinasEspecifica.Count;
                int remeiningDisFills = MaxDataGridLines - totalDis;

                int remainingCG = CompGeral - disciplinasGeral.Count;
                int remainingCE = CompEspecifica - disciplinasEspecifica.Count;

                if (remainingCG < 1 && remainingCE > 0)
                    remainingCE--;
                if (remainingCG > 0 && (remainingCE <= 0 || remainingCE > 0))
                    remainingCG--;

                for (int i = 0; i < remainingCG; i++)
                {
                    disciplinasGeral.Add(new _Disciplina());
                }
                UC_DataGrid_CG.ItemsSource = disciplinasGeral;
                List<SelectListManuais> requeriments = new List<SelectListManuais>();
                List<SelectListManuais> req_DG = new List<SelectListManuais>();
                List<SelectListManuais> req_DE = new List<SelectListManuais>();

                UC_Border_Select_1.Visibility = Visibility.Visible;
                UC_Border_Select_2.Visibility = Visibility.Visible;
                UC_Border_Select_3.Visibility = Visibility.Visible;
                UC_Border_Select_4.Visibility = Visibility.Visible;
                // Tabela dos livros

                for (int i = 0; i < remainingCE; i++)
                {
                    if (disciplinasEspecifica == null)
                        disciplinasEspecifica = new List<_Disciplina>();
                    disciplinasEspecifica.Add(new _Disciplina());
                }
                UC_DataGrid_CE.ItemsSource = disciplinasEspecifica;

                // List View






                List<_Disciplina> _dg = new List<_Disciplina>(disciplinasGeral.Where(x => x.OP1 != true && x.Disciplina != 0));
                int r_CG = CompGeral - _dg.Count;
                for (int i = 0; i < r_CG; i++)
                {
                    _dg.Add(new _Disciplina());
                }

                string[] nomesDis = _dg.Select(x => x.Disciplina).GetNames().ToArray();
                for (int i = 0; i < _dg.Count; i++)
                {
                    SelectListManuais s = new SelectListManuais();
                    if (!string.IsNullOrEmpty(_dg[i].Nome))
                        s.Nome = string.Format("{0} {1}", Internal.Matriculas.Disciplinas.GetName(_dg[i].Disciplina), _dg[i].Nivel);
                    else
                        s.Nome = string.Format("{0}", Internal.Matriculas.Disciplinas.GetName(_dg[i].Disciplina));
                    if (_dg[i].OP2)
                        s.OP2 = new SolidColorBrush(Color.FromRgb(191, 191, 191));
                    if (_dg[i].Disciplina == 0)
                        s.EmptyRow = Visibility.Visible;
                    req_DG.Add(s);
                }
                List<_Disciplina> _de = new List<_Disciplina>(disciplinasEspecifica.Where(x => x.OP1 != true && x.Disciplina != 0));
                int r_CE = CompEspecifica - _de.Count;
                for (int i = 0; i < r_CE; i++)
                {
                    _de.Add(new _Disciplina());
                }
                for (int i = 0; i < _de.Count; i++)
                {
                    SelectListManuais s = new SelectListManuais();
                    s.Nome = Internal.Matriculas.Disciplinas.GetName(_de[i].Disciplina);
                    if (_de[i].OP2)
                        s.OP2 = new SolidColorBrush(Color.FromRgb(191, 191, 191));
                    req_DE.Add(s);
                    if (_de[i].Disciplina == 0)
                        s.EmptyRow = Visibility.Visible;

                }
                //DisciplinasGeralNomes = _dsa.Select(x => x.Disciplina).GetNames().ToList();
                //DisciplinasEspecificasNomes = disciplinasEspecifica.Select(x => x.Disciplina).GetNames().ToList();


                UC_ListView_CG_1.ItemsSource = req_DG;
                UC_ListView_CG_2.ItemsSource = req_DG;
                UC_ListView_CG_3.ItemsSource = req_DG;


                UC_ListView_CE_1.ItemsSource = req_DE;
                UC_ListView_CE_2.ItemsSource = req_DE;
                UC_ListView_CE_3.ItemsSource = req_DE;

            }
            else
            {
                if (Primeiro_Ciclo)
                    CompGeral = 5;
                int totalDis = disciplinasGeral.Count + disciplinasEspecifica.Count;
                int remeiningDisFills = MaxDataGridLines - totalDis;
                int remainingCG = CompGeral - disciplinasGeral.Count;

                for (int i = 0; i < remainingCG; i++)
                {
                    disciplinasGeral.Add(new _Disciplina());
                }
                UC_DataGrid_CG.ItemsSource = disciplinasGeral;
                List<SelectListManuais> requeriments = new List<SelectListManuais>();
                List<SelectListManuais> req_DG = new List<SelectListManuais>();
                List<SelectListManuais> req_DE = new List<SelectListManuais>();


                List<_Disciplina> _dg = new List<_Disciplina>(disciplinasGeral.Where(x => x.OP1 != true && x.Disciplina != 0));
                int r_CG = CompGeral - _dg.Count;
                for (int i = 0; i <= r_CG; i++)
                {
                    _dg.Add(new _Disciplina());
                }
                int fill = _dg.Count;
                if (Primeiro_Ciclo)
                {
                    fill--;
                    UC_StackPanel_Op1.Visibility = Visibility.Visible;
                }
                for (int i = 0; i < fill; i++)
                {
                    SelectListManuais s = new SelectListManuais();
                    if (!string.IsNullOrEmpty(_dg[i].Nome))
                        s.Nome = string.Format("{0} {1}", Internal.Matriculas.Disciplinas.GetName(_dg[i].Disciplina), _dg[i].Nivel);
                    else
                        s.Nome = string.Format("{0}", Internal.Matriculas.Disciplinas.GetName(_dg[i].Disciplina));
                    if (_dg[i].OP2)
                        s.OP2 = new SolidColorBrush(Color.FromRgb(191, 191, 191));
                    if (Primeiro_Ciclo)
                    {
                        s.GridWidth = (double)new LengthConverter().ConvertFrom("3cm");
                        s.Primaria = true;
                    }
                    if (_dg[i].OP3)
                    {
                        s.Nome = string.Format("{0}\n{1}", Internal.Matriculas.Disciplinas.GetName(_dg[i].Disciplina), "(Fichas Obrigatorias)");
                        s.FichasObrigatoriasBox = Visibility.Visible;
                    }
                    if (_dg[i].Disciplina == 0)
                        s.EmptyRow = Visibility.Visible;
                    req_DG.Add(s);
                }


                UC_ListView_CG_1.ItemsSource = req_DG;
                UC_ListView_CG_2.ItemsSource = req_DG;
                UC_ListView_CG_3.ItemsSource = req_DG;
                UC_ListView_CG_4.ItemsSource = req_DG;


                UC_ListView_CE_1.ItemsSource = req_DE;
                UC_ListView_CE_2.ItemsSource = req_DE;
                UC_ListView_CE_3.ItemsSource = req_DE;

            }



        }
        public void FillDataTable(List<_Disciplina> CompGeral, List<_Disciplina> CompEsp)
        {

        }

        private void UC_DataGrid_CG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridColumn column = e.Column;
            if (column.Header.ToString() == "ISBN")
            {

                string isbn = ((TextBox)e.EditingElement).Text;
                long code = 0;
                long.TryParse(isbn.Replace("-", "").Replace(" ", ""), out code);
                _Disciplina row = new _Disciplina();
                if (isbn == "0" || code == 0)
                {
                    row = (_Disciplina)UC_DataGrid_CG.SelectedItem;
                    row.Autor = "";
                    row.Disciplina = 0;
                    row.Editora = "";
                    row.ISNB = "";
                    row.Nome = "";
                }
                else
                {
                    Livros livro = LivrosEngine.Livros.First(x => x.ISBN == code);
                    if (livro == null)
                        return;

                    row = (_Disciplina)UC_DataGrid_CG.SelectedItem;

                    row.Disciplina = Internal.Matriculas.Disciplinas.GetValue(livro.Disciplina).Value;
                    row.Autor = livro.Autor;
                    row.Editora = livro.Editora;
                    row.Nome = livro.Nome;
                    row.ISNB = code.ToString();
                    if (EnsinoSuperior)
                        row.Superior = true;
                    disciplinasGeral.First(x => x.ISNB.Replace("-", "").Replace(" ", "") == code.ToString()).Superior = false;
                }
                //Disciplinas[UC_DataGrid_CG.SelectedIndex] = row;
                //UC_DataGrid_CG.ItemsSource = Disciplinas;

                DadosMatricula_Engine.Update(_Ano, row);

                UC_DataGrid_CG.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CG.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }
            if (column.Header.ToString() == "Disciplina")
            {
                _Disciplina row = (_Disciplina)UC_DataGrid_CG.SelectedItem;
                int Id_dis = 0;
                int.TryParse(((TextBox)e.EditingElement).Text, out Id_dis);
                row.Disciplina = Id_dis;

                DadosMatricula_Engine.Update(_Ano, row);

                UC_DataGrid_CG.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CG.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }
        }

        private void UC_DataGrid_CE_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridColumn column = e.Column;
            if (column.Header.ToString() == "ISBN")
            {

                string isbn = ((TextBox)e.EditingElement).Text;
                long code = 0;
                long.TryParse(isbn, out code);
                Livros livro = LivrosEngine.Livros.First(x => x.ISBN == code);
                if (livro == null)
                    return;

                _Disciplina row = (_Disciplina)UC_DataGrid_CE.SelectedItem;

                row.Disciplina = Internal.Matriculas.Disciplinas.GetValue(livro.Disciplina).Value;
                row.Autor = livro.Autor;
                row.Editora = livro.Editora;
                row.Nome = livro.Nome;
                row.ISNB = code.ToString();
                if (EnsinoSuperior)
                    row.Superior = true;
                disciplinasEspecifica.First(x => x.ISNB == code.ToString()).Superior = false;

                //Disciplinas[UC_DataGrid_CG.SelectedIndex] = row;
                //UC_DataGrid_CG.ItemsSource = Disciplinas;

                DadosMatricula_Engine.Update(_Ano, row);

                UC_DataGrid_CE.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CE.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }

            if (column.Header.ToString() == "Disciplina")
            {
                _Disciplina row = (_Disciplina)UC_DataGrid_CE.SelectedItem;
                row.Superior = true;
                DadosMatricula_Engine.Update(_Ano, row);

                UC_DataGrid_CE.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CE.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }
        }
        private void UC_DataGrid_CG_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (!Editor.DadosMatricula.Componetes.ContainsKey(_Ano))
            {
                List<_Disciplina> dis = new List<_Disciplina>();
                dis.AddRange(disciplinasGeral);
                dis.AddRange(disciplinasEspecifica);
                Editor.DadosMatricula.Componetes.Add(_Ano, dis.ToArray());
            }
        }

        private void UC_DataGrid_CG_Drop(object sender, DragEventArgs e)
        {
            if (canEdit)
            {
                if (e.Data.GetDataPresent(typeof(Livros)))
                {
                    Livros livro = (Livros)e.Data.GetData(typeof(Livros));

                    _Disciplina disciplina = disciplinasGeral.First(x => x.Disciplina == 0);

                    disciplina.ISNB = livro.ISBN.ToString();
                    disciplina.Autor = livro.Autor;
                    disciplina.Disciplina = Internal.Matriculas.Disciplinas.GetValue(livro.Disciplina).Value;
                    disciplina.Editora = livro.Editora;
                    disciplina.Nome = livro.Nome;
                    disciplina.Superior = false;

                    DadosMatricula_Engine.Update(_Ano, disciplina);
                }

                if (e.Data.GetDataPresent(typeof(int)))
                {
                    _Disciplina disciplina = disciplinasGeral.First(x => x.Disciplina == 0);
                    disciplina.Disciplina = (int)e.Data.GetData(typeof(int));

                    DadosMatricula_Engine.Update(_Ano, disciplina);
                }

                UC_DataGrid_CG.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CG.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }
        }

        private void UC_DataGrid_CE_Drop(object sender, DragEventArgs e)
        {
            if (canEdit)
            {
                Livros livro = (Livros)e.Data.GetData(typeof(Livros));

                _Disciplina disciplina = disciplinasEspecifica.First(x => x.Disciplina == 0);

                disciplina.ISNB = livro.ISBN.ToString();
                disciplina.Autor = livro.Autor;
                disciplina.Disciplina = Internal.Matriculas.Disciplinas.GetValue(livro.Disciplina).Value;
                disciplina.Editora = livro.Editora;
                disciplina.Nome = livro.Nome;
                disciplina.Superior = true;


                DadosMatricula_Engine.Update(_Ano, disciplina);

                UC_DataGrid_CE.Dispatcher.BeginInvoke(new Action(() => UC_DataGrid_CE.Items.Refresh()), System.Windows.Threading.DispatcherPriority.Background);

            }
        }
    }
}
