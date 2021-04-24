<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ClientUploadDoc.aspx.cs" Inherits="party.demo.ClientUploadDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        This demo shows how to upload&nbsp; and save a document to the Database&nbsp; (important)</p>
    <table class="nav-justified">
        <tr>
            <td class="modal-sm" style="width: 134px">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 134px">Client Name</td>
            <td>
        <asp:TextBox ID="txtClient" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 134px">Group Type </td>
            <td>
        <asp:DropDownList ID="ddlgroupType" runat="server">
        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 134px">Upload docs </td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" AllowMultiple="true"
                    ToolTip="Please upload your documents" />
            </td>
            </tr>
        <tr>
            <td class="modal-sm" style="width: 134px">&nbsp;</td>
            <td>
                &nbsp;</td>
            </tr>
        <tr>
            <td colspan="2">
        <asp:Button ID="btnSubmit" runat="server" Text="SubmitSingleFileToFolder" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnSubmitMultiFiles" runat="server" Text="SubmitMultiFilesToFolder" OnClick="btnSubmitMultiFiles_Click" />
                <asp:Button ID="btnSubmitWithUpload" runat="server" OnClick="btnSubmitWithUpload_Click" Text="SubmitWithUploadToDb" />
            </td>
        </tr>
    </table>


</asp:Content>
