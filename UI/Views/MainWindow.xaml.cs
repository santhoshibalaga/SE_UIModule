using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.ViewModels;

namespace UI.Views;


/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private bool _isChatPanelOpen = false;
    public MainWindow()
    {
        InitializeComponent();

    }

    private void ChatTab_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        e.Handled = true;
        if (_isChatPanelOpen)
        {
            // Hide the chat panel and make the main content take full width
            ChatPanel.Visibility = Visibility.Collapsed;
            MainGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star); // Full width for TabControl
            MainGrid.ColumnDefinitions[1].Width = new GridLength(0); // Collapse chat panel
            _isChatPanelOpen = false;
        }
        else
        {
            // Show the chat panel and make the TabControl take 70% of the width
            ChatPanel.Visibility = Visibility.Visible;
            MainGrid.ColumnDefinitions[0].Width = new GridLength(8, GridUnitType.Star); // 70% width for TabControl
            MainGrid.ColumnDefinitions[1].Width = new GridLength(2, GridUnitType.Star); // 30% width for ChatPanel
            _isChatPanelOpen = true;
        }

    }
    private void SwitchTheme(string theme)
    {
        Application.Current.Resources.MergedDictionaries.Clear();
        Uri themeUri;

        if (theme == "dark")
        {
            // Load Dark theme
            themeUri = new Uri("C:\\Users\\11210\\source\\repos\\UI\\UI\\Themes\\DarkTheme.xaml", UriKind.Relative);
        }
        else
        {
            // Load Light theme
            themeUri = new Uri("C:\\Users\\11210\\source\\repos\\UI\\UI\\Themes\\LightTheme.xaml", UriKind.Relative);
        }

        ResourceDictionary themeDict = new ResourceDictionary() { Source = themeUri };
        Application.Current.Resources.MergedDictionaries.Add(themeDict);
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Toggle between light and dark theme
        if (((Button)sender).Content.ToString().Contains("Dark"))
        {
            SwitchTheme("dark");
            ((Button)sender).Content = "Switch to Light Theme";
        }
        else
        {
            SwitchTheme("light");
            ((Button)sender).Content = "Switch to Dark Theme";
        }

    }
}
