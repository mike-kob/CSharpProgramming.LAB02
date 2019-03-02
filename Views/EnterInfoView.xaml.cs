using System.Windows.Controls;
using LAB02.Tools.Navigation;
using LAB02.ViewModels;

namespace LAB02
{
    /// <summary>
    /// Interaction logic for EnterInfoControl.xaml
    /// </summary>
    public partial class EnterInfoView : UserControl, INavigatable
    {
        public EnterInfoView()
        {
            InitializeComponent();
            DataContext = new EnterInfoViewModel();
        }
    }
}
