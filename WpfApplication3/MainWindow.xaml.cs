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
using Reactive.Bindings;

namespace WpfApplication3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ReactiveProperty<string> Text { get; private set; } = new ReactiveProperty<string>();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Text.Subscribe(x => Console.WriteLine("{0}: {1}", nameof(MainWindow), x));
        }
    }
}
