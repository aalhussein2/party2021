<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="myAjaxFileUpload.aspx.cs" Inherits="party.demo.myAjaxFileUpload" %>
<%   @ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server"   
        OnUploadComplete="AjaxFileUpload1_UploadComplete"  Mode="Auto"  />
</asp:Content>
