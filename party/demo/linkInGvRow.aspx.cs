using party.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace party.demo
{
    public partial class linkInGvRow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateGv();
            if (!Page.IsPostBack)
            {
                populateDepCombo();
                populateDepCombo2();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
        protected void populateGv()
        {
            CRUD myCrud = new CRUD();
                string mySql = @"SELECT   employee.employeeId, employee.employee, employee.housing, 
                            department.department
                FROM      employee INNER JOIN
                department ON employee.departmentId = department.departmentId";
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql))
            {
                gvEmployee.DataSource = dr;
                gvEmployee.DataBind();
            }
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int mySelectedDep = int.Parse(ddlDep.SelectedValue);
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT   employee.employeeId, employee.employee, employee.housing, 
                            department.department
                FROM      employee INNER JOIN
                department ON employee.departmentId = department.departmentId
                where employee.departmentid =@departmentId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@departmentId", mySelectedDep);
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                gvEmployee.DataSource = dr;
                gvEmployee.DataBind();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int PK = int.Parse(txtEmployeeId.Text);
            string strEmpName = txtEmployeeName.Text;
            int depId = int.Parse(ddlDepartment.SelectedValue);
            //lblOuput.Text = PK.ToString();

            string mySql = @"  update employee set employee =@employee,departmentId = @depid
                        where employeeId=@employeeId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", PK);
            myPara.Add("@employee", strEmpName);
            myPara.Add("@depid", depId);
            CRUD myCrud = new CRUD();
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOuput.Text = "success"; }
            else
            { lblOuput.Text = "failed"; }
            populateGv();
        }
        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"  select employeeId,employee, departmentId from employee 
                    where employeeId=@employeeId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String empId = dr["employeeId"].ToString();
                        String employee = dr["employee"].ToString();
                        String depId = dr["departmentId"].ToString();
                        //lblOuput.Text = empId + employee+ depId;
                        txtEmployeeId.Text = empId;
                        txtEmployeeName.Text = employee;
                        ddlDepartment.SelectedValue = depId;
                    }
                }
            }
        }
        protected void populateDepCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select departmentid , department from department";
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql))
            {
                ddlDepartment.DataTextField = "department";
                ddlDepartment.DataValueField = "departmentid";
                ddlDepartment.DataSource = dr;
                ddlDepartment.DataBind();
            }
        }
        protected void populateDepCombo2()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select departmentid , department from department";
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql))
            {
                ddlDep.DataTextField = "department";
                ddlDep.DataValueField = "departmentid";
                ddlDep.DataSource = dr;
                ddlDep.DataBind();
            }
        }
        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "EditRow")
            //{
            //    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            //    gvEmployee.EditIndex = rowIndex;
            //    populateGv();
            //}
            //else if (e.CommandName == "DeleteRow")
            //{
            //    employeeDal.deleteEmployee(Convert.ToInt32(e.CommandArgument));
            //    populateGv();
            //}
            //else if (e.CommandName == "CancelUpdate")
            //{
            //    gvEmployee.EditIndex = -1;
            //    populateGv();
            //}
           if (e.CommandName == "update")
            {   // shows how to get column values from gv
                Response.Write("test");
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                int employeeId = Convert.ToInt32(e.CommandArgument);
                lblOuput.Text = employeeId.ToString();


                populateGv();
            }
            //else if (e.CommandName == "InsertRow")
            //{
            //    string strName = ((TextBox)GvEmployee.FooterRow.FindControl("txtName")).Text;
            //    int intGenderId = int.Parse(((DropDownList)GvEmployee.FooterRow.FindControl("ddlGender")).SelectedValue);
            //    string strCity = ((TextBox)GvEmployee.FooterRow.FindControl("txtCity")).Text;
            //    string strDoc = ((TextBox)GvEmployee.FooterRow.FindControl("txtDoc")).Text;
            //    string strDocPath = Path.Combine(Server.MapPath("~/Uploads"), FileUploadForm.FileName);
            //    employeeDal.insertEmployee(strName, intGenderId, strCity, strDoc, strDocPath);
            //    //... replace with values employeeDal.insertEmployee(name, genderId, city);
                populateGv();
            }
        }
    }