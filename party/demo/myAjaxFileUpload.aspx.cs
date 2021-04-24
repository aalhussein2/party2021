using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace party.demo
{
    public partial class myAjaxFileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void AjaxFileUpload1_UploadStart(object sender, AjaxControlToolkit.AjaxFileUploadStartEventArgs e)
        {

        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
            string fileNametoupload = Server.MapPath("~/AjaxUpload/") + e.FileName.ToString();
            AjaxFileUpload1.SaveAs(fileNametoupload);
        }


        protected void AjaxFileUpload1_UploadCompleteAll(object sender, AjaxControlToolkit.AjaxFileUploadCompleteAllEventArgs e)
        {

        }
    }
}