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
using LAB02.Tools.Navigation;
using LAB02.ViewModels;

namespace LAB02.Views
{
    /// <summary>
    /// Interaction logic for ShowInfoView.xaml
    /// </summary>
    public partial class ShowInfoView : UserControl, INavigatable
    {
        public ShowInfoView()
        {
            InitializeComponent();
            DataContext = new ShowInfoViewModel();
        }
    }
}
