<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlSampleChart.ascx.cs" Inherits="WebApplication3.UserControls.CtrlSampleChart" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
 Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<link href="/usercontrol/reports/unilab.css" rel="Stylesheet" type="text/css" />

<table cellpadding="4">
    <tr>
        <td valign="top" align="center">
        Chart Type:
        <asp:DropDownList ID="ChartType" runat="server" AutoPostBack="True" CssClass="dropdown">
            <asp:ListItem Value="Area">Area</asp:ListItem>
            <asp:ListItem Value="Bar">Bar</asp:ListItem>
            <asp:ListItem Value="Column">Column</asp:ListItem>
            <asp:ListItem Value="Funnel">Funnel</asp:ListItem>
            <asp:ListItem Value="Line">Line</asp:ListItem>
            <asp:ListItem Value="Pie">Pie</asp:ListItem>
            <asp:ListItem Value="Pyramid">Pyramid</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Chart ID="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
            BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105"
            Height="256px" Width="400px">
                <%--Height="385px" Width="601px"--%>
                <BorderSkin SkinStyle="Emboss" />
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    IsTextAutoFit="False">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Alignment="TopCenter" BackColor="180, 165, 191, 228" BackGradientStyle="TopBottom"
                    BackHatchStyle="None" Font="Microsoft Sans Serif, 12pt, style=Bold" Name="NODs"
                    Text="NODs" ToolTip="NODs" ForeColor="26, 59, 105">
                    </asp:Title>
                    <asp:Title Alignment="TopCenter" BackColor="Transparent" Font="Microsoft Sans Serif, 10pt, style=Bold "
                    ToolTip="Chart Type">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series Name="Count" ChartArea="ChartArea1" Legend="Legend1" CustomProperties="DrawingStyle=Cylinder"
                    BorderColor="64, 0, 0, 0" Color="224, 64, 10" MarkerSize="5">
                    <EmptyPointStyle AxisLabel="0" />
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BackColor="64, 165, 191, 228" BackSecondaryColor="White"
                    BorderColor="64, 64, 64, 64" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                        <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Title="Total NODs" ArrowStyle="Triangle">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                        <AxisX IsLabelAutoFit="False" LineColor="64, 64, 64, 64" Title="Year" ArrowStyle="Triangle" Interval="1">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" Angle="0" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </td>
    </tr>
</table>