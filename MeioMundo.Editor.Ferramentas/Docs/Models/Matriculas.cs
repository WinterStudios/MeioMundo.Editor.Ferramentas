using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MeioMundo.Editor.Ferramentas.Docs.Models
{
    public class Matriculas : UserControl
    {   
        ComboBox UC_ComboBox_Ano { get; set; }
        Grid UC_Grid { get; set; }
        Matricula UC_Matricula { get; set; }
        public Matriculas()
        {
            UC_ComboBox_Ano = new ComboBox();
            UC_Grid = new Grid();
            UC_Matricula = new Matricula();


            UC_ComboBox_Ano.Background = new SolidColorBrush(Colors.Black);
            this.AddChild(UC_Grid);
            RowDefinition RowMenu = new RowDefinition();
            RowMenu.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto);
            RowDefinition RowModelo = new RowDefinition();
            RowModelo.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
            UC_Grid.RowDefinitions.Add(RowMenu);
            UC_Grid.RowDefinitions.Add(RowModelo);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(UC_ComboBox_Ano);
            Grid.SetRow(stackPanel, 0);
            UC_Grid.Children.Add(stackPanel);


            Button save = new Button();
            stackPanel.Children.Add(save);
            save.Content = "Save to PDF";
            save.Click += (sender, e) =>
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.
            }

            UC_ComboBox_Ano.Width = 130;
            UC_ComboBox_Ano.ItemsSource = Anos.GetValues();
            UC_ComboBox_Ano.SelectionChanged += UC_ComboBox_Ano_SelectionChanged;



            Grid.SetRow(UC_Matricula, 1);
            UC_Grid.Children.Add(UC_Matricula);
        }

        private void UC_ComboBox_Ano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UC_Matricula.UC_TextBlock_Ano.Text = UC_ComboBox_Ano.SelectedItem.ToString();
        }
    }
    
}
