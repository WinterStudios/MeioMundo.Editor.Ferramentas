using MeioMundo.Editor.API;
using MeioMundo.Editor.Ferramentas.Docs.Models;
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

namespace MeioMundo.Editor.Ferramentas.Docs
{
    /// <summary>
    /// Interaction logic for UC_DocumentosEngine.xaml
    /// </summary>
    public partial class UC_DocumentosEngine : UserControl
    {
        public static UserControl ContentControl { get; set; }

        public UC_DocumentosEngine()
        {
            InitializeComponent();
            UC_ComboBox_ModeleSelect.ItemsSource = Enum.GetValues(typeof(Modelos.Model));
        }

        private void UC_ComboBox_ModeleSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded)
                return;

            int index = UC_ComboBox_ModeleSelect.SelectedIndex;
            NotificationSystem.Show(new Notification { Message = index.ToString() });
            switch (index)
            {
                case 0:
                    ContentControl = new Internal.Editor.MatriculaEditor();
                    UC_DockPanel_Content.Children.Add((UserControl)ContentControl);
                    break;
            }
            
        }
    }
}
