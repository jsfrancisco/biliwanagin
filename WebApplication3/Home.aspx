<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.Home" MasterPageFile="~/Masterpages/BiliwanaginMaster.Master"%>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap core CSS -->
    <link href="bootstrap-3.2.0-dist/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- Custom styles for this template -->
    <link href="styles/template.css" rel="stylesheet"/>
    <!-- For mobile -->
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <table class="home-table">
            <tr>
                <td colspan="2">
                    <p class="site-title">i-Procure</p>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img src="images/_app_logo.jpg" alt="i-Procure Logo"/>
                </td>
            </tr>
            <tr>
                <td class="home-row">
                    <img src="images/_procurement_process.jpg" alt="thumbnail"/>
                </td>
                <td class="home-row">
                    <img src="images/_projects.jpg" alt="thumbnail"/>
                </td>
            </tr>
            <tr>
                <td class="home-row">
                    <img src="images/_merchants.jpg" alt="thumbnail"/>
                </td>
                <td class="home-row">
                    <img src="images/_agencies.jpg" alt="thumbnail"/>
                </td>
            </tr>
        </table>
    </div>
    <footer>
        <div class="content-wrapper">
            <div class="float-left">
                <p>&copy; <%: DateTime.Now.Year %> - Team-Ang.</p>
            </div>
        </div>
    </footer>
    </form>
</body>
</html>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="home-table">
        <tr>
            <td class="home-td"><a href="../ProcurementProcess.aspx" class=""><img class="home-buttons" src="../images/banner01.jpg"></a></td>
            <td class="home-td"><a href="../Projects.aspx" class=""><img class="home-buttons" src="../images/banner02.jpg"></a></td>
            <td class="home-td"><a href="../Agencies.aspx" class=""><img class="home-buttons" src="../images/banner03.jpg"></a></td>
            <td class="home-td"><a href="../Vendors.aspx" class=""><img class="home-buttons" src="../images/banner04.jpg"></a></td>
        </tr>
    </table>
</asp:Content>
