using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using party.App_Code;

namespace party.demo
{
    public partial class EmployeeObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            //// shows how to get employee object that has static values via constructor. need to see how to get from db
            //employee myEmployee = new employee();
            //myEmployee.strState = "VA";

            //txtEmployeeId.Text = myEmployee.intEmployeeId.ToString();
            //txtEmployeeName.Text = myEmployee.StrEmployeeName;
            //txtCountry.Text = myEmployee.strCountry;
            //txtState.Text = myEmployee.strState;
            int intEmpId = 0;
            intEmpId = int.Parse(txtEmpId.Text);

            // get employee from db into a form
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT employeeId,employee,baseSalary,departmentId,note
                        FROM party.dbo.employee
                        where employeeid=@employeeId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", intEmpId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtEmployeeId.Text = dr["employeeId"].ToString();
                    txtEmployeeName.Text = dr["employee"].ToString();
                }
            }
        }

        protected void btnContact_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
                string mySql = @"SELECT   contact.contactId, contact.contact, country.country
                FROM contact INNER JOIN
                country ON contact.countryId = country.countryId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gv1.DataSource = dr;
            gv1.DataBind();
        }

        protected void btnCountry_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = "select * from country ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gv1.DataSource = dr;
            gv1.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeId.Text = "";
            txtEmployeeName.Text = "";
            txtCountry.Text = "";
            txtState.Text = "";
        }

        protected void btnGetEmpFromDb_Click(object sender, EventArgs e)
        {
            int intEmpId = 0;
             intEmpId = int.Parse(txtEmpId.Text);

            // get employee from db into a form
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT employeeId,employee,baseSalary,departmentId,note
                        FROM party.dbo.employee
                        where employeeid=@employeeId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", intEmpId);
            SqlDataReader  dr = myCrud.getDrPassSql(mySql,myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtEmployeeId.Text = dr["employeeId"].ToString();
                    txtEmployeeName.Text = dr["employee"].ToString();
                }
            }
        }
    }
}