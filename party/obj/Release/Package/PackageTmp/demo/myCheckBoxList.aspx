<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="myCheckBoxList.aspx.cs" Inherits="party.demo.myCheckBoxList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />

    <table class="nav-justified">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:DropDownList ID="ddlDepartment" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:CheckBoxList ID="cblEmployee" runat="server">
                </asp:CheckBoxList>
            </td>
            <td>
                <asp:CheckBoxList ID="cblCourse" runat="server">
                </asp:CheckBoxList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>


</asp:Content>
