﻿using MeioMundo.Editor.Ferramentas.API.FILE;
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

namespace MeioMundo.Editor.Ferramentas.Website
{
    /// <summary>
    /// Interaction logic for ManagerStocks.xaml
    /// </summary>
    public partial class ManagerStocks : UserControl
    {
        public ManagerStocks()
        {
            InitializeComponent();
        }

        private void openCSV_Click(object sender, RoutedEventArgs e)
        {

            table.DataContext = CSV.GetTable().DefaultView;
        }
    }
}
