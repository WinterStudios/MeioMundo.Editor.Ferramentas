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
using System.Windows.Shapes;

namespace MeioMundo.Editor.Ferramentas.Website
{
    /// <summary>
    /// Interaction logic for WindowPopUp.xaml
    /// </summary>
    public partial class WindowPopUp : Window
    {
        public object Output { get; private set; }
        public WindowPopUp()
        {
            InitializeComponent();
        }

        public WindowPopUp(object type, object args)
        {
            InitializeComponent();
            var objType = type.GetType();
            var obj = (Control)Activator.CreateInstance(type.GetType());
            grid_content.Children.Add(obj);
        }

        internal void SetOutput(object obj)
        {
            Output = obj;
        }

        private void OK_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
