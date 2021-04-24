<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="myHtml.aspx.cs" Inherits="party.demo.myHtml" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:CheckBox ID="cbxHobby" runat="server" />
    <asp:RadioButton ID="rdoMarried" runat="server" />

    <input id="Radio1" type="radio" />
    <input id="Checkbox1" type="checkbox" />
    <input id="Text1" type="text" />
    <select id="Select1">
        <option></option>

    </select>
</asp:Content>
