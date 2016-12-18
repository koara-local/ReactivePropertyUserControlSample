using Reactive.Bindings;
using Reactive.Bindings.Extensions;
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

namespace WpfApplication3
{
    public class RxpUserControlViewModel
    {
        public ReactiveProperty<string> TextRxp { get; set; }

        public void Init()
        {
            this.TextRxp.Subscribe(x => Console.WriteLine("{0}: {1}", nameof(RxpUserControlViewModel), x));
        }

        public RxpUserControlViewModel()
        {
        }
    }

    /// <summary>
    /// UserRxPUserControl.xaml の相互作用ロジック
    /// </summary>
    public partial class RxpUserControl : UserControl
    {
        private RxpUserControlViewModel _vm = new RxpUserControlViewModel();

        #region Text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(RxpUserControl));

        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }
        #endregion

        public RxpUserControl()
        {
            InitializeComponent();

            this._vm.TextRxp = this.ToReactiveProperty<string>(TextProperty);

            this._vm.Init();

            this.RxpUserControlGrid.DataContext = _vm;
        }
    }
}
