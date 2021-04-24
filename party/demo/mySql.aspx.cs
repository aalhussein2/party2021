using party.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace party.demo
{
    public partial class mySql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRun_Click(object sender, EventArgs e)
        {
            int rtn = 0;
            string mySql = txtSql.Text;
            CRUD myCrud = new CRUD();
            try
            {
                rtn = myCrud.InsertUpdateDelete(mySql);
                lblOutput.Text = rtn >= 1 ? "Sucess" : "Failed";
                lblOutput.ForeColor = rtn >= 1 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnGetData_Click(object sender, EventArgs e)
        {
            int rtn = 0;
            string mySql = txtSql.Text;
            CRUD myCrud = new CRUD();
            try
            {
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                grdStudent.DataSource = dr;
                grdStudent.DataBind();
                lblOutput.Text = dr != null ? "Sucess" : "Failed";
                lblOutput.ForeColor = rtn >= 1 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message;
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)

        {
            /* Verifies that the control is rendered */
        }
         protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            btnGetData_Click(null,null);
        }

       // the new code to be tested
        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(grdStudent);
            //  grdStudent.AllowPaging = true;
            //   GrdBind();
        }
        public void ExportGridToExcel(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
           // GrdBind();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        private void GrdBind()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["partyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand("select doctypeid, doctype from doctype"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grdStudent.DataSource = dt;
                            grdStudent.DataBind();
                        }
                    }
                }
            }
        }
    }
}