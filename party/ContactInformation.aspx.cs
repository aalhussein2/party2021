using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using party.App_Code;

namespace party
{
    public partial class ContactInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Hello , how are you doing today ..... target to page");
             populateContactGv();

            if (!IsPostBack)
            {
                populateCountryCombo();
            }
        }
        protected void populateCountryCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = "select countryId, country from country ";
           SqlDataReader dr =  myCrud.getDrPassSql(mySql);
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "country";
            ddlCountry.DataSource = dr;
            ddlCountry.DataBind();
        }
        protected void populateContactGv()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT  contact.contactId, contact.contact, country.country             
            FROM contact INNER JOIN
            country ON contact.countryId = country.countryId ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
        protected void populateContactGvWithFilter () // you need to make some changes to capture the passed parameter 
        {
           int myValue = int.Parse(ddlCountry.SelectedItem.Value);
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT   c.contactId, c.contact, co.country
                    FROM     contact c INNER JOIN
                    country co ON c.countryId = co.countryId
                    where c.countryid = @countryId";
            Dictionary<string, object> myPara  = new Dictionary<string, object>();
            myPara.Add("@countryId", myValue);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
        protected void btnGetMeComboData_Click(object sender, EventArgs e)
        {
            int myValue = 0;
        //    string myText = "";
            myValue = int.Parse(ddlCountry.SelectedItem.Value);
          //  myText = ddlCountry.SelectedItem.Text;
            lblOutput.Text =  myValue.ToString();
            populateContactGvWithFilter(); // you need to pass the selected value from the combo to the method
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call populate combo with right info
            int mySelectedEmployeeId = int.Parse(ddlCountry.SelectedValue);
            CRUD myCrud = new CRUD();
            string mySql = @"Select employeeId , employee 
                    from employee where employeeid =@employeeid";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@employeeid", mySelectedEmployeeId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvContact.DataSource = dr;
            gvContact.DataBind();
        }
    }
}