using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using test2.Models; //import the Employee class from the Models namespace
using test2.Commands; //import the RelayCommand class from the Commands namespace
using System.Collections.ObjectModel;

namespace test2.ViewModels
{
    public class EmployessViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged; //implement the PropertyChangedEventHandler event
        private void OnPropertyChanged(string propertyName) //implement the OnPropertyChanged method
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        EmployeeService ObjEmployeeService; //create an instance of the EmployeeService class
        public EmployessViewModel()
        {
            ObjEmployeeService = new EmployeeService(); //initialize the employeeService object
            LoadData(); //call the LoadData method
            CurrentEmployee = new Employee(); 
            addCommand = new RelayCommand(Add); //initialize the addCommand object
            searchCommand = new RelayCommand(Search);
            deleteCommand = new RelayCommand(Delete);
            updateCommand = new RelayCommand(Update);
        }

        #region DisplayOperation
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList //implement the EmployeesList property
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
            //ObservableCollection list is used to update the UI automatically
            EmployeesList = new ObservableCollection<Employee>(ObjEmployeeService.GetAll()); //call the GetAll method of the employeeService object
        }
        #endregion

        private Employee currentEmployee;
        public Employee CurrentEmployee //implement the CurrentEmployee property
        {
            get { return currentEmployee; }
            set
            {
                currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");
            }
        }
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region AddOperation
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get { return addCommand; }
        }

        public void Add()
        {
            try
            {
                var IsAdded = ObjEmployeeService.Add(currentEmployee);
                LoadData();
                if (IsAdded)
                {
                    Message = "Employee added successfully";
                }
                else
                {
                    Message = "Add operation failed";
                }
            }
            catch (Exception ex)
            {
               Message = ex.Message;
            }
        }
        #endregion

        #region SearchOperation

        RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }
        public void Search()
        {
            try
            {
                var ObjEmployee = ObjEmployeeService.Search(currentEmployee.Id);
                if (ObjEmployee != null)
                {
                    CurrentEmployee.Name = ObjEmployee.Name;
                    CurrentEmployee.Age = ObjEmployee.Age;
                    Message = "Employee found";
                }
                else
                {
                    Message = "Employee not found";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region DeleteOperation

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDeleted = ObjEmployeeService.Delete(currentEmployee.Id);
                
                if (IsDeleted)
                {
                    Message = "Employee deleted successfully";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UpdateOperation
        RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjEmployeeService.Update(currentEmployee);
                if (IsUpdated)
                {
                    Message = "Employee updated successfully";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion


    }
}
