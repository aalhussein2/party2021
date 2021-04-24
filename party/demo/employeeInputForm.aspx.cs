
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using party.App_Code;


    public partial class employeeInputForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateDepCombo();
            }
        }
        protected void populateDepCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select departmentId, department from department ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlDep.DataValueField = "departmentId";
            ddlDep.DataTextField = "department";
            ddlDep.DataSource = dr;
            ddlDep.DataBind();
        }
        protected bool validateMyForm()
        {
            bool myValid = false;
            if (string.IsNullOrEmpty(txtEmployee.Text) || string.IsNullOrEmpty(txtBaseSalary.Text) || string.IsNullOrEmpty(txtHousing.Text)
            || string.IsNullOrEmpty(txtTransportation.Text) || string.IsNullOrEmpty(txtInflation.Text) || string.IsNullOrEmpty(txtPositionAllowence.Text)
            || string.IsNullOrEmpty(txtGosiDeduction.Text))
            {
                lblOuput.Text = "Please fill all the text boxes";
                return myValid;
            }
            else
            {
                lblOuput.Text = "";
                return myValid = true;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(txtEmployee.Text) || string.IsNullOrEmpty(txtBaseSalary.Text) || string.IsNullOrEmpty(txtHousing.Text)
            //    || string.IsNullOrEmpty(txtTransportation.Text) || string.IsNullOrEmpty(txtInflation.Text) || string.IsNullOrEmpty(txtPositionAllowence.Text)
            //    || string.IsNullOrEmpty(txtGosiDeduction.Text))
            //{
            //    lblOuput.Text = "Please fill all the text boxes";
            //    return;
            //}

            bool myValidate = validateMyForm();  // the code above was replace with this line of code
            if (myValidate == false)
                return;
            // capture the values from the form
            // it will show the values to the page
            string strEmployee = "";
            double decBaseSalary = 0.0;
            double decHousing = 0.0;
            double decTransportation = 0.0;
            double decInflation = 0.0;
            double decPositionAllowence = 0.0;
            double decGosiDeduction = 0.0;
            int intDepartmentId = 0;

            strEmployee = txtEmployee.Text;
            decBaseSalary = double.Parse(txtBaseSalary.Text);
            decHousing = double.Parse(txtHousing.Text);
            decTransportation = double.Parse(txtTransportation.Text);
            decInflation = double.Parse(txtInflation.Text);
            decPositionAllowence = double.Parse(txtPositionAllowence.Text);
            decGosiDeduction = double.Parse(txtGosiDeduction.Text);
            intDepartmentId = int.Parse(ddlDep.SelectedItem.Value);

            string mySql = @"INSERT INTO dbo.employee
            (employee ,baseSalary  ,housing ,transportation ,inflation,positionAllowence,gosiDeduction,departmentId)
            VALUES
            (@employee ,@baseSalary ,@housing ,@transportation ,@inflation,@positionAllowence ,@gosiDeduction,@departmentId)";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employee", strEmployee);
            myPara.Add("@baseSalary", decBaseSalary);
            myPara.Add("@housing", decHousing);
            myPara.Add("@transportation", decTransportation);
            myPara.Add("@inflation", decInflation);
            myPara.Add("@positionAllowence", decPositionAllowence);
            myPara.Add("@gosiDeduction", decGosiDeduction);
            myPara.Add("@departmentId", intDepartmentId);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOuput.Text = "Success"; }
            else
            { lblOuput.Text = "Failure"; }

            // make a call to show the employee data
            showEmployeeInformation();
        }
        protected void showEmployeeInformation()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT  employee.employeeId, employee.employee, employee.baseSalary, employee.housing,
                employee.transportation,  employee.inflation, employee.positionAllowence, 
                employee.gosiDeduction,  department.department, employee.note
                FROM        department INNER JOIN employee ON department.departmentId = employee.departmentId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvEmployee.DataSource = dr;
            gvEmployee.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // I evaluate if the text box is empty 
            bool myValidate = validateMyForm();  // the code above was replace with this line of code
            if (myValidate == false)
                return;

            // write code to update the data
            // same as insert to capture the values form the form into the employee object 
            employee myEmp = new employee();
            myEmp.intEmployeeId = int.Parse(txtEmployeeId.Text);
            myEmp.StrEmployeeName = txtEmployee.Text;
            myEmp.decSalary = double.Parse(txtBaseSalary.Text);
            myEmp.dblHousing = double.Parse(txtHousing.Text);
            myEmp.dblTransportation = double.Parse(txtTransportation.Text);
            myEmp.dblInflation = double.Parse(txtInflation.Text);
            myEmp.dblPositionAllowence = double.Parse(txtPositionAllowence.Text);
            myEmp.dblGosiDeduction = double.Parse(txtGosiDeduction.Text);
            myEmp.intDepartmentId = int.Parse(ddlDep.SelectedItem.Value);
            myEmp.strNote = txtNote.Text;

            // change the query from insert to update 
            string mySql = @"UPDATE dbo.employee
                SET employee = @employee ,baseSalary = @baseSalary,housing =@housing,transportation = @transportation,inflation = @inflation
                ,positionAllowence = @positionAllowence,gosiDeduction = @gosiDeduction,departmentId = @departmentId,note = @note
                WHERE employeeId = @employeeId";

            // same as insert
            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", myEmp.intEmployeeId);  // added to the update , not included in the insert 
            myPara.Add("@employee", myEmp.StrEmployeeName);
            myPara.Add("@baseSalary", myEmp.decSalary);
            myPara.Add("@housing", myEmp.dblHousing);
            myPara.Add("@transportation", myEmp.dblTransportation);
            myPara.Add("@inflation", myEmp.dblInflation);
            myPara.Add("@positionAllowence", myEmp.dblPositionAllowence);
            myPara.Add("@gosiDeduction", myEmp.dblGosiDeduction);
            myPara.Add("@departmentId", myEmp.intDepartmentId);
            myPara.Add("@note", myEmp.strNote);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOuput.Text = "Success"; }
            else
            { lblOuput.Text = "Failure"; }

            // make a call to show the employee data
            showEmployeeInformation();
        }

        protected void formatControl(int myFormat)
        {
            //  1 is yes, 0 is no 
            switch (myFormat)
            {
                case 0:
                    txtEmployeeId.ForeColor = System.Drawing.Color.Black;
                    txtEmployeeId.BackColor = System.Drawing.Color.White;
                    break;
                case 1:
                    txtEmployeeId.ForeColor = System.Drawing.Color.Green;
                    txtEmployeeId.BackColor = System.Drawing.Color.OrangeRed;
                    break;
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // write code to delete the data
            // verify if the employeeId text box is not empty
            if (string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                lblOuput.Text = "Please enter Employee Id";
                txtEmployeeId.Focus();
                formatControl(1);
                //txtEmployeeId.ForeColor = System.Drawing.Color.Green;
                //txtEmployeeId.BackColor = System.Drawing.Color.OrangeRed;
                return;
            }

            // capture the employeeId  from the text box
            int intEmployeeId = int.Parse(txtEmployeeId.Text);
            // same as insert but change the query 
            string mySql = @"delete employee where employeeId = @employeeId";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", intEmployeeId);

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOuput.Text = "Success"; }
            else
            { lblOuput.Text = "Failure"; }

            // make a call to show the employee data
            showEmployeeInformation();
            formatControl(0); // to make employeeId text box white background
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // another way to insert data via using employee class object 
            if (string.IsNullOrEmpty(txtEmployee.Text) || string.IsNullOrEmpty(txtBaseSalary.Text) || string.IsNullOrEmpty(txtHousing.Text)
                || string.IsNullOrEmpty(txtTransportation.Text) || string.IsNullOrEmpty(txtInflation.Text) || string.IsNullOrEmpty(txtPositionAllowence.Text)
                || string.IsNullOrEmpty(txtGosiDeduction.Text))
            {
                lblOuput.Text = "Please fill all the text boxes";
                return;
            }

            // capture the values from the form
            // it will show the values to the page ... 
            // I will remove this code and replace it with employee object, then use the employee object to fill it with data
            employee myEmp = new employee();
            myEmp.StrEmployeeName = txtEmployee.Text;
            myEmp.decSalary = double.Parse(txtBaseSalary.Text);
            myEmp.dblHousing = double.Parse(txtHousing.Text);
            myEmp.dblTransportation = double.Parse(txtTransportation.Text);
            myEmp.dblInflation = double.Parse(txtInflation.Text);
            myEmp.dblPositionAllowence = double.Parse(txtPositionAllowence.Text);
            myEmp.dblGosiDeduction = double.Parse(txtGosiDeduction.Text);
            myEmp.intDepartmentId = int.Parse(ddlDep.SelectedItem.Value);
            myEmp.strNote = txtNote.Text;


            string mySql = @"INSERT INTO dbo.employee
            (employee ,baseSalary  ,housing ,transportation ,inflation,positionAllowence,gosiDeduction,departmentId, note)
            VALUES
            (@employee ,@baseSalary ,@housing ,@transportation ,@inflation,@positionAllowence ,@gosiDeduction,@departmentId,@note)";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employee", myEmp.StrEmployeeName);
            myPara.Add("@baseSalary", myEmp.decSalary);
            myPara.Add("@housing", myEmp.dblHousing);
            myPara.Add("@transportation", myEmp.dblTransportation);
            myPara.Add("@inflation", myEmp.dblInflation);
            myPara.Add("@positionAllowence", myEmp.dblPositionAllowence);
            myPara.Add("@gosiDeduction", myEmp.dblGosiDeduction);
            myPara.Add("@departmentId", myEmp.intDepartmentId);
            myPara.Add("@note", myEmp.strNote);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOuput.Text = "Success"; }
            else
            { lblOuput.Text = "Failure"; }

            // make a call to show the employee data
            showEmployeeInformation();
        }

        protected void btnShowEmployeeInfo_Click(object sender, EventArgs e)
        {
            showEmployeeInformation();
        }
        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            // capture employeeId from the text box
            int intEmployeeId = (string.IsNullOrEmpty(txtEmployeeId.Text) ? 0 : int.Parse(txtEmployeeId.Text));

            // pull employee data from db
            CRUD myCrud = new CRUD();
            string mySql = @" SELECT  employeeId, employee, baseSalary, housing, transportation, inflation, 
                            positionAllowence, gosiDeduction, departmentId, note
                            FROM employee where employeeId =@employeeId ";
            // Create Parameter Object 
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeId", intEmployeeId);  //intEmployeeId
            //// // execute the query
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            // this is a must  to check if dr returned data 
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    // txtEmployeeId.Text = dr["employeeId"].ToString();
                    txtEmployee.Text = dr["employee"].ToString();
                    txtBaseSalary.Text = dr["baseSalary"].ToString();
                    txtHousing.Text = dr["housing"].ToString();
                    txtTransportation.Text = dr["transportation"].ToString();
                    txtInflation.Text = dr["inflation"].ToString();
                    txtPositionAllowence.Text = dr["positionAllowence"].ToString();
                    txtGosiDeduction.Text = dr["gosiDeduction"].ToString();
                    ddlDep.SelectedValue = dr["departmentId"].ToString();
                    txtNote.Text = dr["note"].ToString();
                }
            }
            else
            {
                lblOuput.Text = "No record found ";
            }

        }
        protected void ClearForm()
        {
            foreach (Control ctrl in Page.Controls)
            {
                if (ctrl.GetType().Name == "TextBox")
                {
                    TextBox txtBx = (TextBox)ctrl;
                    string s = txtBx.Text;
                    Response.Write(s + "<br>");
                    //TextBox txtBx = (TextBox)ctrl;
                    //txtBx.Text = "";

                }
            }
        }
        protected void btnClearForm_Click(object sender, EventArgs e)
        {
            //  ClearForm();  // not working
            txtEmployee.Text = "";
            txtBaseSalary.Text = "";
            txtHousing.Text = "";
            txtTransportation.Text = "";
            txtInflation.Text = "";
            txtPositionAllowence.Text = "";
            txtGosiDeduction.Text = "";
            ddlDep.SelectedIndex = 0;
            txtNote.Text = "";
        }
        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            mailMgr myMailMgr = new mailMgr();
            lblOuput.Text = myMailMgr.sendEmailViaGmail();
            lblOuput.BackColor = System.Drawing.Color.Yellow;
        }
        protected void btnCheckControlNotEmpty_Click(object sender, EventArgs e)
        {
            //  checkControlNotEmpty(txtEmployee); // pass control 
          //  checkControlNotEmpty(ddlDep);
        }
        //protected bool checkControlNotEmpty(object myObject) // new  to continue today
        //{
        //    // check what kind of  control later, but now  use text box
        //    string myControlType = myObject.GetType().Name;//(myObject.GetType().Name == "TextBox")? "TextBox": "comboBox";  //Object.getType(b)   ctrl.GetType().Name == "TextBox"
        //    lblOuput.Text = myControlType;
        //    bool rtn = false;
        //    return rtn;
        //}
   }
