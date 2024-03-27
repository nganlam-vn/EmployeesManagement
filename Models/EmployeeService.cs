﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2.Models
{
    public class EmployeeService
    {
        private static List<Employee> ObjEmployeesList = new List<Employee>();
        public EmployeeService() 
        {
            ObjEmployeesList.Add(new Employee { Name = "John Doe", Id = 2113, Age = 30 });
        
        }
        public List<Employee> GetAll() //return the list of employees
        {
            return ObjEmployeesList;
        }

        public bool Add(Employee objNewEmployee)
        {
            if(objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
            {
               throw new Exception("Age must be between 21 and 58");
            }

            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(Employee objEmployeeToUpdate)
        {
            bool isUpdated = false;
            for(int i = 0; i < ObjEmployeesList.Count; i++)
            {
                if (ObjEmployeesList[i].Id ==objEmployeeToUpdate.Id)
                {
                    ObjEmployeesList[i].Name = objEmployeeToUpdate.Name;
                    ObjEmployeesList[i].Age = objEmployeeToUpdate.Age;
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int i = 0; i < ObjEmployeesList.Count; i++)
            {
                if (ObjEmployeesList[i].Id == id)
                {
                    ObjEmployeesList.RemoveAt(i);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }

        public Employee Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e => e.Id == id);
        }
    }
}
