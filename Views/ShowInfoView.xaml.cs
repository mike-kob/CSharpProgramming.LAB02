using System.Windows.Controls;
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
