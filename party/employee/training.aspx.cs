using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using party.App_Code;


namespace party.employee
{
    public partial class training : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // creat a method that populat the drop down list
            if (!IsPostBack)
            {
                PopulateGenderCombo();
                PopulateCountryCombo();
            }

        }
        protected void PopulateGenderCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select genderId, gender from gender";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlGender.DataValueField = "genderId";
            ddlGender.DataTextField = "gender";
            ddlGender.DataSource = dr;
            ddlGender.DataBind();
        }
        protected void PopulateCountryCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select countryId, country from country";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "country";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            getTrainerData();
            getTrainerDataDoc();
            //
        }
        protected void getTrainerData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select trainerId, name,nationalid,dob,gender, country
                from trainer t inner join gender g on t.genderId = g.genderId
                inner join country  c on t.countryId = c.countryId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvTrainer.DataSource = dr;
            gvTrainer.DataBind();
        }
        protected void getTrainerDataDoc()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"   select * from trainerDoc";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvTrainerDoc.DataSource = dr;
            gvTrainerDoc.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // capture the value inserted by the user

            CRUD myCrud = new CRUD();
            string mySql = @"insert into trainer (name, nationalId, dob, genderId, countryId)
                       values (@name, @nationalId, @dob, @genderId, @countryId)" +
                                "SELECT CAST(scope_identity() AS int)";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@name", txtName.Text);
            myPara.Add("@nationalId", txtNationalId.Text);
            myPara.Add("@dob", txtDob.Text);
            myPara.Add("@genderId", ddlGender.SelectedValue);
            myPara.Add("@countryId", ddlCountry.SelectedValue);
            int trainserId = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
            InsertDocuments(trainserId);
            // call insert doc
            getTrainerData();
            getTrainerDataDoc();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"delete trainer where trainerId = @trainerId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@trainerId", txtTrainerId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Sucess";
                getTrainerData();
            }

            else
            {
                lblOutput.Text = "Failed";
                getTrainerData();
                getTrainerDataDoc();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @" update trainer set  
            name = @name,nationalId= @nationalId,dob= @dob,genderId= @genderId,countryId= @countryId
            where trainerId = @trainerId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@trainerId", int.Parse(txtTrainerId.Text));
            myPara.Add("@name", txtName.Text);
            myPara.Add("@nationalId", txtNationalId.Text);
            myPara.Add("@dob", txtDob.Text);
            myPara.Add("@genderId", ddlGender.SelectedValue);
            myPara.Add("@countryId", ddlCountry.SelectedValue);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Sucess";
                getTrainerData();
                getTrainerDataDoc();
            }

            else
            { lblOutput.Text = "Failed"; }

        }
        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"    select trainerId, name,nationalid,dob,genderID, countryID
                from trainer where trainerId = @trainerId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@trainerId", PK);
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtTrainerId.Text = (dr["trainerId"].ToString());
                    txtName.Text = dr["name"].ToString();
                    txtNationalId.Text = dr["nationalId"].ToString();
                    txtDob.Text = dr["dob"].ToString();
                    ddlGender.SelectedValue = dr["genderId"].ToString();
                    ddlCountry.SelectedValue = dr["countryId"].ToString();

                    //lblOuput.Text = empId + employee+ depId;

                }
            }
        }
        protected void InsertDocuments(int myTrainerId)  // upload doc to db
        {
            foreach (HttpPostedFile postedFile in FileUpload.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        CRUD DocInsert = new CRUD(); /// added Nov 2017 
                        string mySql = @"insert into TrainerDoc(TrainerId,DocName,ContentType,DocData)
                                    values (@TrainerId,@DocName,@ContentType,@DocData)";
                        Dictionary<string, Object> p = new Dictionary<string, object>();
                        //p.Add("@TaskId", "get the value ");
                        p.Add("@TrainerId", myTrainerId);  // added Nov 2017
                        p.Add("@DocName", filename);
                        p.Add("@ContentType", contentType);
                        p.Add("@DocData", bytes);
                        DocInsert.InsertUpdateDelete(mySql, p);
                    }
                }
            }
        }
        protected void DownloadFile(object sender, EventArgs e)  // move it to common 
        {// move it to common
            int trainerDocId = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            string constr = CRUD.conStr; //WebConfigurationManager.ConnectionStrings["conStrtaskDb"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = @"  select  docName,ContentType,docData from trainerDoc
                                      where trainerDocId = @trainerDocId";
                    cmd.Parameters.AddWithValue("@trainerDocId", trainerDocId);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.HasRows)
                        {
                            sdr.Read();
                            bytes = (byte[])sdr["DocData"];
                            contentType = sdr["ContentType"].ToString();
                            fileName = sdr["docName"].ToString();   //fileName changed to docName
                        }
                        else
                        {
                            lblOutput.Text = "File not found!";
                            lblOutput.ForeColor = System.Drawing.Color.Red;
                            lblOutput.BackColor = System.Drawing.Color.Yellow;
                            return;
                        }
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}
