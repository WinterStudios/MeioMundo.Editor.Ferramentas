﻿using MeioMundo.Editor.Ferramentas.Docs.Internal.Matriculas;
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
    /// Interaction logic for Livros.xaml
    /// </summary>
    public partial class Livros : UserControl
    {
        public List<Matriculas.Livros> Books { get; set; }
        public Livros()
        {
            InitializeComponent();
            LoadDataBase();
        }







        private void LoadDataBase()
        {
            if(File.Exists(DocsInternal.PluginStorageDataPath))
                Books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Matriculas.Livros>>(File.ReadAllText(DocsInternal.PluginStorageDataPath));
            else
                Books = new List<Matriculas.Livros>();
            UC_DataGrid_Livros.ItemsSource = Books;
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(Docs.DocsInternal.PluginStorageDataPath, Newtonsoft.Json.JsonConvert.SerializeObject(Books.GetSerialize(), Newtonsoft.Json.Formatting.Indented));
        }
    }
}
