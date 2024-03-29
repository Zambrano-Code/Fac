﻿using Fac.src.Model;
using Fac.src.ViewModel;
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

namespace Fac.src.View
{
    /// <summary>
    /// Lógica de interacción para Bank.xaml
    /// </summary>
    public partial class Bank : Window
    {
        public Bank()
        {
            InitializeComponent();
            Closed += Bank_Closed;
        }

        private void Bank_Closed(object? sender, EventArgs e)
        {
            if (bancMain.DataContext is BackVM viewModel)
            {
                viewModel.GuardarDatos();
            }
        }
    }
}
