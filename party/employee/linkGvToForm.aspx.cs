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

namespace party.employee
{
    public partial class linkGvToForm : System.Web.UI.Page
    {
        // SqlConnection con = new SqlConnection(CRUD.conStr); //  new SqlConnection(@"Data Source=T450S\SQLEXPRESS;persist security info=True;Integrated Security=SSPI; Initial Catalog=party;");
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFname.Focus();
            if (!IsPostBack)
            {
                //FillGrid();
                populateGvContact();
                populateDdlGrouptype();
            }
        }
        protected void Page_UnLoad(object sender, EventArgs e)        {
            // code to be executed on user leaves the page
            // to avoid max connection pool exceeded
            CRUD.clearAllPools();        }


        protected void populateDdlGrouptype()
        {
            // ddlAdministration.ClearSelection();
            CRUD myCrud = new CRUD();
            string mySql = @" select groupTypeId, groupType 
                                from groupType  
                                order by groupTypeId";
            myCrud.populateCombo(ddlGrouptype, mySql, "groupTypeId", "groupType");
        }
        protected void populateGvContact()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"Select trainingRegistrationId,fname,mName,lName, tr.groupTypeId, groupType , cell,email ,Active ,Note
                            from trainingRegistration tr  inner join groupType ct on tr.groupTypeId = ct.groupTypeId
                            order by fname ";
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql))
            {
                gvCustomer.DataSource = dr;
                gvCustomer.DataBind();
            }
        }

        #region CRUD ops
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {  // sample of long code to insert data into db
            int rtn = 0;
            // validation is working but there is duplicate for last one
            //if (common.IsNullOrEmpty(txtContact, lblOutput)) return;
            //if (common.IsNullOrEmpty(txtPhoneNumber, lblOutput)) return;
            //if (common.IsNullOrEmpty(txtEmail, lblOutput)) return;
            if (String.IsNullOrEmpty(txtFname.Text))
            {
                lblOutput.Text = "Please fill First Name !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                txtFname.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtMName.Text))
            {
                lblOutput.Text = "Please fill Mi !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                txtMName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtLname.Text))
            {
                lblOutput.Text = "Please fill Last Name !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                txtLname.Focus();
                return;
            }
            //if (String.IsNullOrEmpty(txtCell.Text))
            //{
            //    lblOutput.Text = "Please fill Cell number !";
            //    lblOutput.ForeColor = System.Drawing.Color.Red;
            //    txtCell.Focus();
            //    return;
            //}
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                lblOutput.Text = "Please fill the Email !";
                lblOutput.ForeColor = System.Drawing.Color.Red;
                txtEmail.Focus();
                return;
            }
            int intActive = (cbActive.Checked ? 1 : 0);

            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"insert into trainingRegistration (fName,mName,Lname,cell,email, Active,  grouptypeId,note) 
                                    values (@fName,@mName,@lName,@cell, @email, @Active,@grouptypeId,@note)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@fName", txtFname.Text);
                myPara.Add("@mName", txtMName.Text);
                myPara.Add("@lName", txtLname.Text);
                myPara.Add("@cell", txtCell.Text);
                myPara.Add("@email", txtEmail.Text);
                myPara.Add("@Active", intActive);
                myPara.Add("@grouptypeId", ddlGrouptype.SelectedValue); // it is not selecttedItem.Value but SelectedValue
                myPara.Add("@note", txtNote.Text);
                rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                {
                       common.PostMsg(lblOutput,"Success ","green");
                }
                else
                {
                      common.PostMsg(lblOutput, "Failed ","red");
                }
                populateGvContact();
                           }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //  common.clearLblOutputContent(lblOutput);
            ClearControls();
            btnUpdate.Visible = true;  // show the update button
            // this is how you access the gv values through btn > grow > then to find the control 
            // gvDepartments.BackColor = System.Drawing.Color.White; //  
            try
            {
                gvChangeColor();
                ClearControls();
                Button btn = sender as Button;
                GridViewRow grow = btn.NamingContainer as GridViewRow;  // ref to the gv row 
                HdntrainingRegistrationId.Value = (grow.FindControl("lblTrainingRegistrationId") as Label).Text;
                ddlGrouptype.SelectedValue = (grow.FindControl("lblgroupTypeId") as Label).Text;  // new
                txtFname.Text = (grow.FindControl("lblFname") as Label).Text;
                txtMName.Text = (grow.FindControl("lblMName") as Label).Text;
                txtLname.Text = (grow.FindControl("lblLname") as Label).Text;
                txtCell.Text = (grow.FindControl("lblCell") as Label).Text;
                txtEmail.Text = (grow.FindControl("lblEmail") as Label).Text;
                txtNote.Text = (grow.FindControl("lblNote") as Label).Text;
                bool ActiveValue = (grow.FindControl("cbActive") as CheckBox).Checked;//this is how to capture checkbox from a gridview
                cbActive.Checked = ActiveValue; //(ActiveValue == false? false: true);

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                grow.BackColor = System.Drawing.Color.Yellow; //     
            }
            catch (Exception ex)
            {
                //throw ex;
                lblOutput.Text = ex.Message.ToString();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //  gvDepartments.BackColor = System.Drawing.Color.White; //  
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"update trainingRegistration set fname=@fName,mName=@MName,lName =@lName,groupTypeId =@groupTypeId ,cell=@cell,
                                    email=@email,Active=@Active, note=@note
                                    where trainingRegistrationId=@trainingRegistrationId";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@trainingRegistrationId", HdntrainingRegistrationId.Value);  // captured the id from edit button
                myPara.Add("@fName", txtFname.Text);
                myPara.Add("@MName", txtMName.Text);
                myPara.Add("@lName", txtLname.Text);
                myPara.Add("@groupTypeId", int.Parse(ddlGrouptype.SelectedValue));
                myPara.Add("@cell", txtCell.Text);
                myPara.Add("@email", txtEmail.Text);
                myPara.Add("@Active", cbActive.Checked == false ? 0 : 1);
                myPara.Add("@note", txtNote.Text);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                { App_Code.common.PostMsg(lblOutput, "Success", "green"); }
                else
                { App_Code.common.PostMsg(lblOutput, "Failed", "Red"); }

                btnUpdate.Visible = false; // hided  the update button
            }
            catch (Exception ex)
            {
                App_Code.common.PostMsg(lblOutput, ex.Message.ToString(),"red");
            }
            populateGvContact();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // shows how to access gvr when the sender is a button inside the gv
            try
            {
                //  common.clearLblOutputContent(lblOutput);
                ClearControls();
                Button btn = sender as Button;
                GridViewRow grow = btn.NamingContainer as GridViewRow;
                int inttrainingRegistrationId = int.Parse((grow.FindControl("lblTrainingRegistrationId") as Label).Text);
                CRUD myCrud = new CRUD();
                string mySql = @"delete  trainingRegistration  where trainingRegistrationId=@trainingRegistrationId";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@trainingRegistrationId", inttrainingRegistrationId);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                { App_Code.common.PostMsg(lblOutput, "Success", "green"); }
                else
                { App_Code.common.PostMsg(lblOutput, "Failed", "Red"); }
            }
            catch (Exception ex)
            {
                  App_Code.common.PostMsg(lblOutput, ex.Message.ToString(),"red");
            }

            populateGvContact();
        }
        protected void ClearControls()
        {
            try
            {
                //       common.clearLblOutputContent(lblOutput);
                lblOutput.Text = "";
                txtFname.Text = "";
                txtMName.Text = "";
                txtLname.Text = "";
                txtCell.Text = "";
                txtEmail.Text = "";
                cbActive.Checked = false;
                ddlGrouptype.SelectedIndex = 0;
                txtNote.Text = "";
                HdntrainingRegistrationId.Value = "";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            catch
            {
                throw;
            }
        }
        protected void ClearControls2()
        {
            try
            {
// iterate form collection to get controls name into a list of objects
// loop through the collection and clear the values
                txtFname.Text = "";
                txtMName.Text = "";
                txtLname.Text = "";
                txtCell.Text = "";
                txtEmail.Text = "";
                cbActive.Checked = false;
                ddlGrouptype.SelectedIndex = 0;
                txtNote.Text = "";
                HdntrainingRegistrationId.Value = "";
                btnSave.Visible = true;
                btnUpdate.Visible = false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
        protected void gvChangeColor()
        {
            foreach (GridViewRow row in gvCustomer.Rows)
            {
                if (row.RowIndex == gvCustomer.SelectedIndex)
                {
                    row.BackColor = System.Drawing.Color.Green;  // not applicable
                }
                else
                {
                    row.BackColor = System.Drawing.Color.White;//ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }
    }
}