using System.Windows;
using System.Windows.Controls;
using UI.ViewModels;

namespace UI.Views
{
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();

            this.DataContext = new DashboardViewModel();
        }

        
    }
}
