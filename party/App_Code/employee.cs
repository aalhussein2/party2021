using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace party.App_Code
//{
    public class employee
    {
        // properties

        public int intEmployeeId { get; set; }  // initialized in constructor 
        public string StrEmployeeName { get; set; } // initialized in constructor 
        public string strCountry { get; set; } // initialized via calling a method from constructor 
        public string strState { get; set; } // initialized from instantiated object 
        public string dateDob { get; set; } // initialized from instantiated object 
        public double decSalary { get; set; } // initialized from instantiated object 
        public bool boolActive { get; set; } // initialized from instantiated object 

        public double dblBaseSalary { get; set; }
        public double dblHousing { get; set; }
        public double dblTransportation { get; set; }
        public double dblInflation { get; set; }
        public double dblPositionAllowence { get; set; }
        public double dblGosiDeduction { get; set; }
        public int intDepartmentId { get; set; }
        public string strNote { get; set; }

        // methods
        public employee()
        {
            // set up a default values for the properties for every instance of the employee object 
            intEmployeeId = 111;
            StrEmployeeName = "Ali ";
            setEmployeeCountry(); // calling a method to populate the property
        }
        public void setEmployeeCountry()
        {
            this.strCountry = "Saudi Arabia";
            dateDob = "03/13/1963";
            decSalary = 1000;
            boolActive = false;
        }
    }
//}