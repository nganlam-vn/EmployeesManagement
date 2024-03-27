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
using test2.ViewModels; //import the EmployeesViewModel class from the ViewModels namespace

namespace test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            EmployessViewModel ViewModel; //create an instance of the EmployeesViewModel class
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new EmployessViewModel(); //initialize the ViewModel object
            this.DataContext = ViewModel; //set the DataContext of the window to the ViewModel object
        }
    }
}