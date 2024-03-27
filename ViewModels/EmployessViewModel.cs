using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using test2.Models; //import the Employee class from the Models namespace

namespace test2.ViewModels
{
    public class EmployessViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //implement the PropertyChangedEventHandler event
        private void OnPropertyChanged(string propertyName) //implement the OnPropertyChanged method
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        EmployeeService employeeService; //create an instance of the EmployeeService class
        public EmployessViewModel()
        {
            employeeService = new EmployeeService(); //initialize the employeeService object
            LoadData(); //call the LoadData method
        }
        

        private List<Employee> employeesList;
        public List<Employee> EmployeesList //implement the EmployeesList property
        {
            get { return employeesList; }
            set
            {
                employeesList = value;
                OnPropertyChanged("EmployeesList");
            }
        }
        private void LoadData()
        {
            EmployeesList = employeeService.GetAll(); //call the GetAll method of the employeeService object
        }

    }
}
