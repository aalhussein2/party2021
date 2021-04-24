using party.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace party.demo
{
    public partial class customer : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=T450S\SQLEXP2017;persist security info=True; 
                                        Integrated Security=SSPI; Initial Catalog=party;");
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txtCustomerName.Focus();
                if (!IsPostBack)
                {
                    FillGrid();
                }
            }
            catch
            {
            }
        }
        void FillGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select CustomerID,CustomerName,PhoneNumber,Address ,IsActive from tblCustomers ";
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvDepartments.DataSource = ds;
                gvDepartments.DataBind();
            }
            catch
            {
            }
        }
        void ClearControls()
        {
            try
            {
                txtCustomerName.Text = "";
                txtPhoneNumber.Text = "";
                txtAddress.Text = "";
                cbActive.Checked = false;
                hidCustomerID.Value = "";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            catch
            {
                throw;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"insert into tblCustomers (CustomerName,PhoneNumber,Address,IsActive) 
                                    values (@CustomerName,@PhoneNumber,@Address,1)";
                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                FillGrid();
                ClearControls();
                lblMessage.Text = "Saved Successfully.";
            }
            catch
            {
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            FillGrid();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
            }
            catch
            {
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // this is how you access the gv values through btn > grow > then to find the control 
           // gvDepartments.BackColor = System.Drawing.Color.White; //  
            try
            {
                gvChangeColor();
                ClearControls();
                Button btn = sender as Button;
                GridViewRow grow = btn.NamingContainer as GridViewRow;
                hidCustomerID.Value = (grow.FindControl("lblCustomerID") as Label).Text;
                txtCustomerName.Text = (grow.FindControl("lblCustomerName") as Label).Text;
                txtPhoneNumber.Text = (grow.FindControl("lblPhoneNumber") as Label).Text;
                txtAddress.Text = (grow.FindControl("lblAddress") as Label).Text;
                bool ActiveValue  = (grow.FindControl("cbActive") as CheckBox).Checked ;//this is how to capture checkbox from a gridview
                cbActive.Checked = ActiveValue; //(ActiveValue == false? false: true);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                grow.BackColor = System.Drawing.Color.Yellow; //     
            }
            catch
            {
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          //  gvDepartments.BackColor = System.Drawing.Color.White; //  
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"update tblCustomers set CustomerName=@CustomerName,PhoneNumber=@PhoneNumber,
                    Address=@Address,IsActive=@isActive
                    where CustomerID=@CustomerID";
                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@isActive", cbActive.Checked == false ? 0 : 1);
                cmd.Parameters.AddWithValue("@CustomerID", hidCustomerID.Value);   //rtn
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                FillGrid();
                ClearControls();
                lblMessage.Text = "Updated Successfully.";
            }
            catch
            {
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // shows how to access gvr when the sender is a button inside the gv
            try
            {
                ClearControls();
                Button btn = sender as Button;
                GridViewRow grow = btn.NamingContainer as GridViewRow;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update tblCustomers set IsActive=0 where CustomerID=@CustomerID";
                cmd.Parameters.AddWithValue("@CustomerID", (grow.FindControl("lblCustomerID") as Label).Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                FillGrid();
                lblMessage.Text = "Deleted Successfully.";
            }
            catch
            {
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            FillGrid();
        }
        protected void btnSave2_Click(object sender, EventArgs e)
        {
            string strCustName= txtCustomerName.Text;
           string strPhoneNum =  txtPhoneNumber.Text;
            string strAddress = txtAddress.Text;
            int intActive = (cbActive.Checked ? 1 : 0);
                    CRUD myCrud = new CRUD();
            string mySql = @"insert into tblCustomers (CustomerName,PhoneNumber,Address,IsActive) 
                                    values (@CustomerName,@PhoneNumber,@Address,@isActive)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerName", strCustName);
            myPara.Add("@phoneNumber",strPhoneNum);
            myPara.Add("@Address", strAddress);
            myPara.Add("@isActive", intActive);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            confirmCrudOutput(rtn);
        }
        protected void confirmCrudOutput (int rtn)
        {
            if (rtn >= 1)
            {
                lblMessage.Text = "Success";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMessage.Text = "Failed";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void gvChangeColor()
        {
            foreach (GridViewRow row in gvDepartments.Rows)
            {
                if (row.RowIndex == gvDepartments.SelectedIndex)
               {
                   row.BackColor = System.Drawing.Color.Green;  // not applicable
                }
                else
                {
                    row.BackColor = System.Drawing.Color.White;//ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }
        protected void btnUpdate2_Click(object sender, EventArgs e)
        {
            string strCustName = txtCustomerName.Text;
            string strPhoneNum = txtPhoneNumber.Text;
            string strAddress = txtAddress.Text;
            int intActive = (cbActive.Checked ? 1 : 0);
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE dbo.tblcustomers
                            SET customerName = @customerName,PhoneNumber =@PhoneNumber,Address = @Address,isActive =@isActive
                            where customerId = @customerId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@customerName", strCustName);
            myPara.Add("@phoneNumber", strPhoneNum);
            myPara.Add("@Address", strAddress);
            myPara.Add("@isActive", intActive);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            confirmCrudOutput(rtn);
        }
        protected void showCheckBox()
        {
           // cbActive.Checked
        }
        protected void btnModal_Click(object sender, EventArgs e)
        {

        }
    } // cls
} // NS