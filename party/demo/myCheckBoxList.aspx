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
            <td style="width: 44px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 240px">
                Employee</td>
            <td>
                Course</td>
            <td style="width: 44px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 240px; vertical-align: top;">
                <asp:CheckBoxList ID="cblEmployee" runat="server">
                </asp:CheckBoxList>
            </td>
            <td style="vertical-align: top">
                <asp:CheckBoxList ID="cblCourse" runat="server" Width="82px">
                </asp:CheckBoxList>
            </td>
            <td style="width: 44px">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 240px">
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
            </td>
            <td>&nbsp;</td>
            <td style="width: 44px">&nbsp;</td>
        </tr>
    </table>

    <asp:GridView ID="gvEmployeeCourse" runat="server"></asp:GridView>

</asp:Content>
