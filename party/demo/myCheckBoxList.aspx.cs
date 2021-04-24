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
    public partial class myCheckBoxList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateEmployeeCheckBoxList();
                populateCourseCheckBoxList();
                populateDepCombo();
            }
        }
        protected void populateDepCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select departmentId, department from department";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlDepartment.DataValueField = "departmentId";
            ddlDepartment.DataTextField = "department";
            ddlDepartment.DataSource = dr;
            ddlDepartment.DataBind();
        }
        protected void populateEmployeeCheckBoxList()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select employeeId, employee from employee";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            cblEmployee.DataValueField = "employeeId";
            cblEmployee.DataTextField = "employee";
            cblEmployee.DataSource = dr;
            cblEmployee.DataBind();
        }
        protected void populateCourseCheckBoxList()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select courseId, course from course";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            cblCourse.DataValueField = "courseId";
            cblCourse.DataTextField = "course";
            cblCourse.DataSource = dr;
            cblCourse.DataBind();
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string selectedCourses = "";
            int totalSelectedItems = 0;
            string employeeSelection = "";
            int counter = 0;

            foreach (ListItem item in cblEmployee.Items)
            {
                if (item.Selected)
                {
                    totalSelectedItems += 1;
                }
            }
            for (int i = 0; i < cblEmployee.Items.Count; i++)
            {
                if (cblEmployee.Items[i].Selected)
                {
                    int empId = 0;
                    counter += 1;
                    empId = int.Parse(cblEmployee.Items[i].Value);
                    for (int ii = 0; ii < cblCourse.Items.Count; ii++)
                    {
                        if (cblCourse.Items[ii].Selected)
                        {
                            int myActivityId = 0;
                            myActivityId = int.Parse(cblCourse.Items[ii].Value);
                            //call method to regiser
                            registerEmp(empId, myActivityId);
                        }
                    }
                }
            }
        }
        protected void registerEmp(int myEmployeeId, int myCourseId)
        {
            //selectedCourses += myEmployeeId + " " + myCourseName;
            //lblOutput.Text = selectedCourses;
            string mySql = @"INSERT INTO employeeCourse
                           (employeeId ,courseId )
                            VALUES(@employeeId,@courseId)";
            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", myEmployeeId);
            myPara.Add("@courseId", myCourseId);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            App_Code.common.PostMsg(lblOutput, rtn);
            //if (rtn >= 1)
            //{
            //    lblOutput.Text = "Sucess";
            //}
            //else
            //{
            //    lblOutput.Text = "Failed";
            //}

            GetemployeeCourse();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            GetemployeeCourse();
        }
        protected void GetemployeeCourse()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"  select employee, course
                      from employeeCourse ec inner
                      join employee e on ec.employeeId = e.employeeId
                    inner    join course c on ec.courseId = c.courseId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvEmployeeCourse.DataSource = dr;
            gvEmployeeCourse.DataBind();
        }
    } // cls
}// ns