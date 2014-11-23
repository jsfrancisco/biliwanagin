<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtrlProjects.ascx.cs" Inherits="WebApplication3.UserControls.CtrlProjects" %>

<!-- Bootstrap core CSS -->
<link href="bootstrap-3.2.0-dist/css/bootstrap.min.css" rel="stylesheet"/>
<!-- Custom styles for this template -->
<link href="template.css" rel="stylesheet"/>

<table>
    <tr>
        <td colspan="5">Filter Results:</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnYear1" runat="server" Text="2003" CssClass="btn-year" OnClick="btnYear1_Click"/>
        </td>
        <td>
            <asp:Button ID="btnYear2" runat="server" Text="2004" CssClass="btn-year" OnClick="btnYear1_Click"/>
        </td>
        <td>
            <asp:Button ID="btnYear3" runat="server" Text="2005" CssClass="btn-year" OnClick="btnYear1_Click"/>
        </td>
        <td>
            <asp:Button ID="btnYear4" runat="server" Text="2006" CssClass="btn-year" OnClick="btnYear1_Click"/>
        </td>
        <td>
            <asp:Button ID="btnYear5" runat="server" Text="2007" CssClass="btn-year" OnClick="btnYear1_Click"/>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:DropDownList ID="ddlAgency" runat="server" CssClass="dropdown-filter-1"></asp:DropDownList>
        </td>
        <td colspan="2">
            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="dropdown-filter-2"></asp:DropDownList>
        </td>
    </tr>
</table>
<br />
<table>
    <tr>
        <td colspan="5">View Projects by:</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnTable" runat="server" Text="Table" OnClick="btnTable_Click" />
        </td>
        <td>
            <asp:Button ID="btnMap" runat="server" Text="Map" OnClick="btnMap_Click" />
        </td>
        <td>
            <asp:Button ID="btnStatus" runat="server" Text="Status" OnClick="btnStatus_Click" />
        </td>
        <td>
            <asp:Button ID="btnMode" runat="server" Text="Mode" OnClick="btnMode_Click" />
        </td>
        <td>
            <asp:Button ID="btnAmount" runat="server" Text="Amount" OnClick="btnAmount_Click" />
        </td>
    </tr>
</table>

<asp:Panel ID="pnlTable" runat="server" Height="500px">
    <div class="pull-right" style="margin-bottom: 5px; margin-right: -5px;">
        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" OnClick="btnExport_Click" /></div>

    <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="false" CssClass="gridview-list"
        GridLines="None" EmptyDataText="No Document Found." AllowPaging="true" PageSize="12" 
        OnPageIndexChanging="gvProjects_PageIndexChanging" OnRowCommand="gvProjects_RowCommand"
        >
        <PagerStyle CssClass="gridview-pager" HorizontalAlign="Center" Height="25px"/>
            <PagerSettings Position="Bottom"  PageButtonCount="5" Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last"/>
            <RowStyle CssClass="primary"/>
            <AlternatingRowStyle CssClass="alternate" />
        <Columns>
            <asp:BoundField DataField="ref_no" HeaderText="REF ID" ItemStyle-Width="5%"/>
            <asp:BoundField DataField="tender_title" HeaderText="BID TITLE" ItemStyle-Width="20%"/>
            <asp:BoundField DataField="procuring_entity_org" HeaderText="AGENCY" ItemStyle-Width="20%"/>
            <asp:BoundField DataField="LocationName" HeaderText="LOCATION" ItemStyle-Width="15%"/>
            <asp:BoundField DataField="approved_budget" HeaderText="ABC" SortExpression="approved_budget" ItemStyle-Width="10%"/>
            <asp:BoundField DataField="procurement_mode" HeaderText="MODE OF PROCUREMENT" SortExpression="procurement_mode" ItemStyle-Width="10%"/>
            <asp:BoundField DataField="tender_status" HeaderText="STATUS" SortExpression="tender_status" ItemStyle-Width="10%"/>
            <asp:BoundField DataField="awardee" HeaderText="VENDOR" SortExpression="awardee" ItemStyle-Width="5%"/>
            <asp:BoundField DataField="contract_amt" HeaderText="CONTRACT AMOUNT" SortExpression="contract_amt" ItemStyle-Width="5%"/>
        </Columns>
    </asp:GridView>
</asp:Panel>

<asp:Panel ID="pnlMap" runat="server" Visible="false">

</asp:Panel>

<asp:Panel ID="pnlStatus" runat="server" Visible="false" CssClass="tab-panel">
    <asp:Chart ID="Chart1" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
            BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105"
            Height="385px" Width="601px">
                <%--Height="385px" Width="601px"--%>
                <BorderSkin SkinStyle="Emboss" />
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    IsTextAutoFit="False">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Alignment="TopCenter" BackColor="180, 165, 191, 228" BackGradientStyle="TopBottom"
                    BackHatchStyle="None" Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Bid Status"
                    Text="Bid Status" ToolTip="Bid Status" ForeColor="26, 59, 105">
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
</asp:Panel>

<asp:Panel ID="pnlMode" runat="server" Visible="false" CssClass="tab-panel">
    <asp:Chart ID="Chart2" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
            BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105"
            Height="385px" Width="601px">
                <%--Height="385px" Width="601px"--%>
                <BorderSkin SkinStyle="Emboss" />
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    IsTextAutoFit="False">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Alignment="TopCenter" BackColor="180, 165, 191, 228" BackGradientStyle="TopBottom"
                    BackHatchStyle="None" Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Mode of Procurement"
                    Text="Mode of Procurement" ToolTip="Mode of Procurement" ForeColor="26, 59, 105">
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
</asp:Panel>

<asp:Panel ID="pnlAmount" runat="server" Visible="false" CssClass="tab-panel">
        <asp:Chart ID="Chart3" runat="server" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
            Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
            BackGradientStyle="TopBottom" BorderWidth="2" BackColor="#D3DFF0" BorderColor="26, 59, 105"
            Height="385px" Width="601px">
                <%--Height="385px" Width="601px"--%>
                <BorderSkin SkinStyle="Emboss" />
                <Legends>
                    <asp:Legend Name="Legend1" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold"
                    IsTextAutoFit="False">
                    </asp:Legend>
                </Legends>
                <Titles>
                    <asp:Title Alignment="TopCenter" BackColor="180, 165, 191, 228" BackGradientStyle="TopBottom"
                    BackHatchStyle="None" Font="Microsoft Sans Serif, 12pt, style=Bold" Name="Approved Budget"
                    Text="Approved Budget" ToolTip="Approved Budget" ForeColor="26, 59, 105">
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
</asp:Panel>
