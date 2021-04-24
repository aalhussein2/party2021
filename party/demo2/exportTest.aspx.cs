using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace party.demo2
{
    public partial class exportTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.GrdBind();
            }

        }
        private void GrdBind()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["partyConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand("select docTypeId, docType from docType"))
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
            GrdBind();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void imgBtnPDF_Click(object sender, ImageClickEventArgs e)
        {
            ExportGridToExcel(grdStudent);
          //  grdStudent.AllowPaging = true;
         //   GrdBind();
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStudent.PageIndex = e.NewPageIndex;
            this.GrdBind();
        }
    }
}