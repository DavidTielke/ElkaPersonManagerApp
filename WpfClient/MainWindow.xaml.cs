using System.Collections.Generic;
using System.Windows;
using PersonManagerApp.ConsoleClient;

namespace WpfClient;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var manager = new PersonManager();

        Adults = manager.GetAllAdults();
        Children = manager.GetAllChildren();

        DataContext = this;

        InitializeComponent();
    }

    public List<Person> Adults { get; set; }
    public List<Person> Children { get; set; }
}