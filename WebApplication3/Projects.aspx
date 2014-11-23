<%@ Page Title="" Language="C#" MasterPageFile="~/Masterpages/BiliwanaginMaster.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="WebApplication3.Projects" EnableEventValidation = "false" %>

<%@ Register Src="~/UserControls/CtrlProjects.ascx" TagPrefix="uc1" TagName="CtrlProjects" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CtrlProjects runat="server" id="CtrlProjects" />
</asp:Content>
