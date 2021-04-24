<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="employeeCrud.aspx.cs" 
    Inherits="party.demo.employeeCrud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table class="nav-justified">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblOuput" runat="server"></asp:Label>
                </td>
                <td rowspan="4" style="width: 100%" >&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 100px">Employee Id</td>
                <td style="width: 200px">
                    <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Employee Name</td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Department</td>
                <td>
                    <asp:DropDownList ID="ddlDepartment" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
                    <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
                    <asp:DropDownList ID="ddlDep" runat="server">
                    </asp:DropDownList>
                  </td>
                <td style="width: 268435488px">&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False"
            DataKeyNames="employeeId">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center"
                    HeaderText="Employee ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkupdate" runat="server"
                            CommandArgument='<%# Bind("employeeId") %>'
                            OnClick="populateForm_Click"
                            Text='<%# Eval("employeeId")  %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center"
                    HeaderText="Employee ID">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkupdate2" runat="server"
                            CommandArgument='<%# Bind("employeeId") %>'
                            OnClick="populateForm2_Click"
                            Text='<%# Eval("employeeId")  %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="employeeId" HeaderText="employeeId" InsertVisible="False" ReadOnly="True"
                    SortExpression="employeeId" />
                <asp:BoundField DataField="employee" HeaderText="employee" SortExpression="employee" />
                <asp:BoundField DataField="housing" HeaderText="housing" SortExpression="housing" />
                <asp:BoundField DataField="department" HeaderText="department" SortExpression="department" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
