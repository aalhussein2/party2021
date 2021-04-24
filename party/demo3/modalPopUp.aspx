<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modalPopUp.aspx.cs" 
    Inherits="party.demo.modalPopUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />
        <!-- ModalPopupExtender -->
    <cc1:modalpopupextender id="mp1" runat="server" 
        popupcontrolid="Panel1" 
        targetcontrolid="btnShow"
        cancelcontrolid="btnClose" 
        backgroundcssclass="modalBackground">
</cc1:modalpopupextender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
        This is an ASP.Net AJAX ModalPopupExtender Example<br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </asp:Panel>
    <!-- ModalPopupExtender -->


    <style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>
</asp:Content>
