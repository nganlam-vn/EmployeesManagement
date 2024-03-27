using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //to interact with the INotifyPropertyChanged interface

namespace EmployeeManagement.Models
{
    public class Employee : INotifyPropertyChanged //implement the INotifyPropertyChanged interface
    { 
        public event PropertyChangedEventHandler PropertyChanged;   //implement the PropertyChangedEventHandler event

        private void OnPropertyChanged(string propertyName) //implement the OnPropertyChanged method
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private string name;
        private int id;
        private int age;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        
        public int Age
        {
            get { return age; }
            set
            {
                age = Convert.ToInt32(value);
                OnPropertyChanged("Age");
            }
        }

       
    }
    
    
}
