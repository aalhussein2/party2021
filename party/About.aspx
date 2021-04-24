<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="party.About" %>

<%@ Register src="ViewSwitcher.ascx" tagname="ViewSwitcher" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p>&nbsp;</p>
    <p></p>
    <uc1:ViewSwitcher ID="ViewSwitcher1" runat="server" />
</asp:Content>
