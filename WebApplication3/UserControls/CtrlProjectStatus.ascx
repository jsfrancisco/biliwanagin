<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjectStatus.ascx.cs" Inherits="WebApplication3.UserControls.CtrlProjectStatus" %>

<asp:Chart ID="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
    Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
    BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105"
    Height="256px" Width="400px">
    <BorderSkin SkinStyle="Emboss" />
    <Legends>
        <asp:Legend Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
        IsTextAutoFit="False">
        </asp:Legend>
    </Legends>
    <Titles>
        <asp:Title Alignment="TopCenter" BackColor="180, 165, 191, 228" BackGradientStyle="TopBottom"
        BackHatchStyle="None" Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Projects"
        Text="Projects" ToolTip="Projects" ForeColor="26, 59, 105">
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