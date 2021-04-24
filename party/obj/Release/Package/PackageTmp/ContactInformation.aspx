<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactInformation.aspx.cs" Inherits="party.ContactInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <table class="nav-justified" border="1">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
    </table>


    <p>
        <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:GridView ID="gvContact" runat="server">
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnGetMeComboData" runat="server" OnClick="btnGetMeComboData_Click" Text="Combo Data" />
    </p>
</asp:Content>
