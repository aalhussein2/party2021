<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="exportTest.aspx.cs" Inherits="party.demo.exportTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--    <asp:GridView ID="grdStudent" runat="server" AutoGenerateColumns="false" AllowPaging="true"
        OnPageIndexChanging="OnPageIndexChanging">
        <Columns>
            <asp:BoundField DataField="docTypeId" HeaderText="docTypeId" />
            <asp:BoundField DataField="docType" HeaderText="docType" />
        </Columns>
    </asp:GridView>--%>

<%--        <asp:GridView ID="grdStudent" runat="server" AutoGenerateColumns="false"  >
        <Columns>
            <asp:BoundField DataField="docTypeId" HeaderText="docTypeId" />
            <asp:BoundField DataField="docType" HeaderText="docType" />
        </Columns>
    </asp:GridView>--%>
    <asp:GridView ID="grdStudent" runat="server">
    </asp:GridView>
<br />
<asp:ImageButton  AlternateText="Export" runat="server" OnClick="imgBtnPDF_Click" />

</asp:Content>
