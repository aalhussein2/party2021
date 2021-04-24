<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="training.aspx.cs" Inherits="party.employee.training" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <p>
    <br />
</p>
<table class="nav-justified">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">Trainer Id</td>
        <td>
            <asp:TextBox ID="txtTrainerId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">Name</td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">National Id</td>
        <td>
            <asp:TextBox ID="txtNationalId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">DOB</td>
        <td>
            <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">Gender</td>
        <td>
            <asp:DropDownList ID="ddlGender" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">Country</td>
        <td>
            <asp:DropDownList ID="ddlCountry" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px; height: 20px">Trainer Document:<br />
            *AR-Academic Record<br />
            *AS-Attendance Sheet<br />
            *TR-Training Request<br />
            *UL-University Letter<br />
        </td>
        <td style="height: 20px">
            <asp:FileUpload ID="FileUpload" runat="server" AllowMultiple ="true" />
    </tr>
    <tr>
        <td class="modal-sm" style="width: 282px; height: 20px">&nbsp;</td>
        <td style="height: 20px">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
        </td>
    </tr>
</table>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>

    <asp:GridView ID="gvTrainer" runat="server" AutoGenerateColumns="False" DataKeyNames="trainerId">
        <Columns>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="trainerId">
            <ItemTemplate>

                <asp:LinkButton ID="lnkupdate" runat="server"  
                    CommandArgument='<%# Bind("trainerId") %>' 
                    OnClick="populateForm_Click"
                    Text='<%# Eval("trainerId")  %>'></asp:LinkButton>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="left"></ItemStyle>
        </asp:TemplateField>
 
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="nationalId" HeaderText="nationalId" SortExpression="nationalId" />
            <asp:BoundField DataField="dob" HeaderText="dob" SortExpression="dob" />
            <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender" />
            <asp:BoundField DataField="country" HeaderText="country" SortExpression="country" />
        </Columns>
    </asp:GridView>
    
    <br />
    <asp:GridView ID="gvTrainerDoc" runat="server" AutoGenerateColumns="False" DataKeyNames="trainerDocId"
       >
        <Columns>
            <asp:BoundField DataField="trainerId" HeaderText="trainerId" SortExpression="trainerId" />
            <asp:BoundField DataField="trainerDocId" HeaderText="trainerDocId" InsertVisible="False" ReadOnly="True" SortExpression="trainerDocId" />
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="DocName">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDownload" runat="server" OnClick="DownloadFile"
                            CommandArgument='<%# Bind("trainerDocId") %>' Text='<%# Eval("docName")  %>'></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"></ItemStyle>
                </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <br />
    
</asp:Content>


