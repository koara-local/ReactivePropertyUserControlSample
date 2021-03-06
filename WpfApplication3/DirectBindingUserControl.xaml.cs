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

namespace WpfApplication3
{
    /// <summary>
    /// DirectBindingUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class DirectBindingUserControl : UserControl
    {
        #region Text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(DirectBindingUserControl),
                new PropertyMetadata(
                    null,
                    (d, e) => Console.WriteLine("{0}: {1}", nameof(DirectBindingUserControl), e.NewValue)));

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }
        #endregion

        public DirectBindingUserControl()
        {
            InitializeComponent();

            this.DirectBindingUserControlGrid.DataContext = this;
        }
    }
}
