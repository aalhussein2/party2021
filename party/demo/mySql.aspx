<%@ Page Title="Sql" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="mySql.aspx.cs" 
    Inherits="party.demo.mySql" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="myContent">
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label><br />
        <asp:TextBox ID="txtSql" runat="server" Height="68px" Width="601px"></asp:TextBox>
        <br />
        <asp:Button ID="btnRun" runat="server" Text="Run as Action Query(Insert Update Delete)" OnClick="btnRun_Click" />
        <asp:Button ID="btnGetData" runat="server" OnClick="btnGetData_Click" Text="Get Data  ( Select )" />
        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export" />
        <br />
    </div>
    <asp:GridView ID="grdStudent" runat="server">
    </asp:GridView>
</asp:Content>
