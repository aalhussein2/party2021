<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="exportData.aspx.cs" 
    Inherits="party.demo.exportData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:GridView ID="grdStudent" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <%--<asp:ImageButton  AlternateText="Export" runat="server" OnClick="imgBtnPDF_Click" />--%>
    <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
</asp:Content>
