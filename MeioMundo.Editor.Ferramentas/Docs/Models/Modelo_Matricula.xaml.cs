using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
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

namespace MeioMundo.Editor.Ferramentas.Docs.Models
{
    /// <summary>
    /// Interaction logic for Matricula.xaml
    /// </summary>
    public partial class Modelo_Matricula : UserControl
    {
        public string AnoLectivo { get => UC_TextBlock_Ano.Text; set => UC_TextBlock_Ano.Text = value; }
        public string Escola { get => UC_TextBlock_Escola.Text; set => UC_TextBlock_Escola.Text = value; }
        public List<_Disciplina> Disciplinas { get; set; }

        bool canEdit = false;
        public bool EditMode
        {
            get => canEdit;
            set
            {
                canEdit = !value;
                UC_DataGrid_CG.IsReadOnly = !value;
            }
        }

        public Modelo_Matricula()
        {
            InitializeComponent();
            Disciplinas = new List<_Disciplina>();
            UC_DataGrid_CG.ItemsSource = Disciplinas;
        }
        public void FillDataTable(List<_Disciplina> CompGeral)
        {
            UC_DataGrid_CG.ItemsSource = CompGeral;
        }
        public void FillDataTable(List<_Disciplina> CompGeral, List<_Disciplina> CompEsp)
        {

        }
    }
}
