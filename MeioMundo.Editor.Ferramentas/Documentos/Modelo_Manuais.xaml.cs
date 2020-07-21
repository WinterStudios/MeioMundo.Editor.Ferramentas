using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Modelo_Manuais.xaml
    /// </summary>
    public partial class Modelo_Manuais : UserControl
    {
        public List<DataBase.Componentes> Disciplinas { get; set; }
        public Modelo_Manuais()
        {
            
            Disciplinas = new List<DataBase.Componentes>();
            Disciplinas.Add(new DataBase.Componentes { Disciplina = "Portugues", ISBN = "9897671265", Nome = "Caminhos 11" });
            Disciplinas.Add(new DataBase.Componentes { Disciplina = "Inglês (cont.)", ISBN = "9780194010160", Nome = "Insight 11" });
            Disciplinas.Add(new DataBase.Componentes { Disciplina = "Alemaão (Ini./cont.)", ISBN = "9783126062961", Nome = "Geni@klick A2" });
            InitializeComponent();
            UC_DataGrid_ComponenteGeral.ItemsSource = Disciplinas;
            UC_DataGrid_ComponenteEspecifica.ItemsSource = Disciplinas;
            this.UpdateLayout();
        }
    }
}
