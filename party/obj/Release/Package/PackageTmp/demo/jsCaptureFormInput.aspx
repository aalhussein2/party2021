<%@ Page Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="jsCaptureFormInput.aspx.cs" Inherits="party.demo.jsCaptureFormInput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function captureValues() {
            let strName = document.getElementById("txtName").value;  // when you assign vlaue to a tag
             strName += "\n" +document.getElementById("txtAge").value;
             strName += "\n" + document.getElementById("txtDep").value;
            showValues(strName);
            document.getElementById("myP").innerHTML = strName; // when you past a value
        }
        function showValues(myPassedValue) {
            alert(myPassedValue);
            // or to enter to the db
        }
    </script>

   <div id ="myDiv"></div>
    <p id="myP"></p>

       Name: <input id="txtName" type="text" /><br />
        Age:<input id="txtAge" type="text" /><br />
        Dep<input id="txtDep" type="text" /><br />
        <input id="btnSubmit" type="button" value="Submit" onclick ="captureValues();"  />
    </asp:Content>