<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/BiliwanaginMaster.Master" AutoEventWireup="true" CodeBehind="Merchants.aspx.cs" Inherits="WebApplication3.Merchants" %>

<%@ Register Src="~/UserControls/CtrlVendors.ascx" TagPrefix="uc1" TagName="CtrlVendors" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlVendors runat="server" id="CtrlVendors" />
</asp:Content>
