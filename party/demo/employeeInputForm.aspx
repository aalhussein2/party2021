<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="employeeInputForm.aspx.cs" Inherits="party.demo.employeeInputForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <table class="nav-justified">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblOuput" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">employee Name</td>
                <td>
                    <asp:TextBox ID="txtEmployee" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">base Salary</td>
                <td>
                    <asp:TextBox ID="txtBaseSalary" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Housing</td>
                <td>
                    <asp:TextBox ID="txtHousing" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Transportation</td>
                <td>
                    <asp:TextBox ID="txtTransportation" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Inflation</td>
                <td>
                    <asp:TextBox ID="txtInflation" runat="server" style="margin-right: 0"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Position Allowence</td>
                <td>
                    <asp:TextBox ID="txtPositionAllowence" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Gosi Deduction</td>
                <td>
                    <asp:TextBox ID="txtGosiDeduction" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Department</td>
                <td>
                    <asp:DropDownList ID="ddlDep" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 126px">Note</td>
                <td>
                    <asp:TextBox ID="txtNote" runat="server" Height="99px" TextMode="MultiLine" Width="171px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" 
                       OnClientClick="return confirm('Are you sure? want to delete the employee.')" />
                    <asp:Button ID="btnShowEmployeeInfo" runat="server" OnClick="btnShowEmployeeInfo_Click" Text="ShowEmployeeInfo" />
                    <asp:Button ID="btnGetEmployee" runat="server" OnClick="btnGetEmployee_Click" Text="Get Employee" />
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="30px"></asp:TextBox>
                    <asp:Button ID="btnClearForm" runat="server" OnClick="btnClearForm_Click" Text="Clear Form" />
                    <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="Send Email" />
                    <asp:Button ID="btnCheckControlNotEmpty" runat="server" OnClick="btnCheckControlNotEmpty_Click" Text="CheckControlNotEmpty" />
                </td>
            </tr>
        </table>
    </p>
    <p>
        <asp:GridView ID="gvEmployee" runat="server">
        </asp:GridView>
    </p>
    <p>
    </p>
</asp:Content>
