<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeObject.aspx.cs" Inherits="party.demo.EmployeeObject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        <asp:TextBox ID="txtEmpId" runat="server"></asp:TextBox>
    </p>
    <table class="nav-justified" border="1" style="height: 139px">
        <tr>
            <td class="modal-sm" style="width: 254px; height: 23px;">
        <asp:Button ID="btnGetEmployee" runat="server" OnClick="btnGetEmployee_Click" Text="Get Employee- value from cls" />
            </td>
            <td class="modal-sm" style="width: 332px; height: 23px;">
                <asp:Button ID="btnClear" runat="server" Text="Clear Text Boxes" OnClick="btnClear_Click" />
                <asp:Button ID="btnGetEmpFromDb" runat="server" OnClick="btnGetEmpFromDb_Click" Text="GetEmpFromDb" />
            </td>
            <td rowspan="6" style="height: 139px">This shows how&nbsp;&nbsp; you create an object of type employee, then initialized its properties in different ways:<br />
                1. Via class contructor<br />
                2. Via a method call<br />
                3. Via Employee Object to create a new variable</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 254px; height: 23px;">EmployeeID</td>
            <td class="modal-sm" style="width: 332px; height: 23px;">
                <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 254px; height: 21px;">Employee Name</td>
            <td class="modal-sm" style="width: 332px; height: 21px;">
                <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 254px; height: 23px;">Country</td>
            <td class="modal-sm" style="width: 332px; height: 23px;">
                <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 254px; height: 24px;">State</td>
            <td class="modal-sm" style="width: 332px; height: 24px;">
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            </td>
        </tr>
        </table>
    <BR>
    <table class="nav-justified" border="1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnContact" runat="server" OnClick="btnContact_Click" Text="get Contact" />
                <asp:Button ID="btnCountry" runat="server" OnClick="btnCountry_Click" Text="get Country" />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="gv1" runat="server">
    </asp:GridView>
    <br />

</asp:Content>
