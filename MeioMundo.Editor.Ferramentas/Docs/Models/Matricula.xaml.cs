﻿using System;
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
    public partial class Matricula : UserControl
    {
        public Matricula()
        {
            InitializeComponent();
        }
        public void SetVarieables(string ano)
        {
            UC_TextBlock_Ano.Text = ano;
        }
    }
}
