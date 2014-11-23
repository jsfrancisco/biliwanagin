<%@ Page Title="Procurement Process" Language="C#" MasterPageFile="~/Masterpages/BiliwanaginMaster.Master" AutoEventWireup="true" CodeBehind="ProcurementProcess.aspx.cs" Inherits="WebApplication3.ProcurementProcess" %>

<%@ Register Src="~/UserControls/CtrlProcurement.ascx" TagPrefix="uc1" TagName="CtrlProcurement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProcurement runat="server" id="CtrlProcurement" />
</asp:Content>

