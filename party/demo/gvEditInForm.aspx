<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gvEditInForm.aspx.cs" 
    Inherits="party.demo.gvEditInForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <title>Gridview Basics example.</title>
    <style type="text/css">
        .gv {
            font-family: Arial;
            margin-top: 30px;
            font-size: 14px;
        }

            .gv th {
                background-color: #5D7B9D;
                font-weight: bold;
                color: #fff;
                padding: 2px 10px;
            }

            .gv td {
                padding: 2px 10px;
            }

        input[type="submit"] {
            margin: 2px 10px;
            padding: 2px 20px;
            background-color: #5D7B9D;
            border-radius: 10px;
            border: solid 1px #000;
            cursor: pointer;
            color: #fff;
        }

            input[type="submit"]:hover {
                background-color: orange;
            }

        .auto-style1 {
            text-align: left;
            margin-left: 40px;
        }

        .auto-style2 {
            width: 367px;
        }

        .auto-style5 {
            width: 183px;
        }

        .auto-style6 {
            width: 184px;
        }
    </style>
    <br /><br />
    <br /><br />
    <div style="text-align: center; color: #FF0000;"> Excellent Demo to show how CRUD operations works from Web application side</div>
     <div>
        <table align="center" style="position: relative; top: 20px;">
            <tr>
                <td>
                    <table align="center" class="auto-style2">
                        <tr>
                            <td class="auto-style5">
                                Customer Name :
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="txtCustomerName" runat="server" MaxLength="50" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                Phone Number :
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="txtPhoneNumber" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">
                                Address :
                            </td>
                            <td class="auto-style6">
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="200" Width="250px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Active</td>
                                <td><asp:CheckBox ID="cbActive" runat="server"   />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                                    Visible="false" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <br />
                    <asp:Label ID="lblMessage" runat="server" EnableViewState="false" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvDepartments" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No Records Found" GridLines="both" CssClass="gv" EmptyDataRowStyle-ForeColor="Red" 
                       >
                        <Columns>
                            <asp:TemplateField HeaderText="Customer Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address">
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                   <%-- <asp:Label ID="lblActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>--%>
                                    <asp:CheckBox ID="cbActive" runat="server" checked='<%#Eval("IsActive") %>' Enabled="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                        OnClientClick="return confirm('Are you sure? want to delete the department.');"
                                        OnClick="btnDelete2_Click" />
                                    <asp:Label ID="lblCustomerID" runat="server" Text='<%#Eval("CustomerID") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <input type="hidden" runat="server" id="hidCustomerID" />
    </div>
    </asp:Content>
