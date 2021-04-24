<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="party.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <%-- <h2><%: Title %>.</h2>--%>
    <h3>Contact Information</h3>
    <address>
        Web Db Consulting Services<br />
        Riyadh, Saudi Arabia<br />
        <abbr title="Phone">P:</abbr>
        +966 538692448
    </address>

    <address>
        <strong>Information:</strong>   <a href="mailto:info@wdbcs.com">info@wdbcs.com</a><br />
        <%--<strong>Marketing:</strong> <a href="mailto:Marketing@wdbcs.com">Marketing@wdbcs.com</a>--%>
    </address>
</asp:Content>
