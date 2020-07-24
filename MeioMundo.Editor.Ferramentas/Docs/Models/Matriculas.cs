using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            RowDefinition row_Editors = new RowDefinition();
            row_Editors.Height = new GridLength(1, GridUnitType.Auto);
            RowDefinition RowMenu = new RowDefinition();
            RowMenu.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Auto);
            RowDefinition RowModelo = new RowDefinition();
            RowModelo.Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
            UC_Grid.RowDefinitions.Add(row_Editors);
            UC_Grid.RowDefinitions.Add(RowMenu);
            UC_Grid.RowDefinitions.Add(RowModelo);

            MenuItem menuItem_Editor = new MenuItem();
            menuItem_Editor.Header = "Editor";
            MenuItem menuItem_Editor_Livros = new MenuItem();
            menuItem_Editor_Livros.Header = "Livros";
            menuItem_Editor_Livros.Click += MenuItem_Editor_Livros_Click;
            menuItem_Editor.Items.Add(menuItem_Editor_Livros);
            Menu menu = new Menu();
            menu.Items.Add(menuItem_Editor);
            Grid.SetRow(menu, 0);
            UC_Grid.Children.Add(menu);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(UC_ComboBox_Ano);
            Grid.SetRow(stackPanel, 1);
            UC_Grid.Children.Add(stackPanel);


            Button save = new Button();
            stackPanel.Children.Add(save);
            save.Content = "Save to PDF";
            save.Click += (sender, e) =>
            {
                PrintDialog printDialog = new PrintDialog();
                //SaveFileDialog fileDialog = new SaveFileDialog();
                //fileDialog.Filter = "PDF File(*.pdf)| *.pdf";

                Window window = new Window();
                window.SizeToContent = SizeToContent.WidthAndHeight;
                Matricula m = new Matricula();
                m.SetVarieables(UC_ComboBox_Ano.SelectedItem.ToString());
                window.Content = m;
                if(window.ShowDialog() == true)
                {

                }
                if(printDialog.ShowDialog() == true)
                    printDialog.PrintVisual(m, "doc");


            };

            UC_ComboBox_Ano.Width = 130;
            UC_ComboBox_Ano.ItemsSource = Anos.GetValues();
            UC_ComboBox_Ano.SelectionChanged += UC_ComboBox_Ano_SelectionChanged;



            Grid.SetRow(UC_Matricula, 2);
            UC_Grid.Children.Add(UC_Matricula);


        }


        private void UC_ComboBox_Ano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UC_Matricula.UC_TextBlock_Ano.Text = UC_ComboBox_Ano.SelectedItem.ToString();
            FillBooks();
        }


        private void FillBooks()
        {
            List<Livros> livros = new List<Livros>
            {
                new Livros(){ Disciplina = 11, ISBN = 1234567890123, Nome = "Caminhos 11", Autor = "QUAL", Editora = "Porto", Ano = 11 }
            };

            UC_Matricula.UC_DataGrid_CG.ItemsSource = livros;
        }


        private void MenuItem_Editor_Livros_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();

        }
    }
    
}
