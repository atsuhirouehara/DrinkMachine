using System.Windows;
using DrinkMachine.ViewModels;

namespace DrinkMachine.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = new MainWindowViewModel();
        }
    }
}
