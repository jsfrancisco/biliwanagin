using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication3.UserControls
{
    public partial class CtrlProjects : System.Web.UI.UserControl
    {
        private string filter
        {
            get {
                if (ViewState["filter"] != null)
                    return ViewState["filter"].ToString();
                else
                    return string.Empty;
            }
            set { ViewState["filter"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownLists();
                BindGridView(filter);
            }
        }

        private void BindDropdownLists()
        {
            ddlAgency.DataSource = Biliwanagin.ProcurementManager.GetAllAgencies();
            ddlAgency.DataTextField = "AgencyName";
            ddlAgency.DataValueField = "AgencyId";
            ddlAgency.DataBind();

            ddlLocation.DataSource = Biliwanagin.ProcurementManager.GetAllProjectLocations();
            ddlLocation.DataTextField = "LocationName";
            ddlLocation.DataValueField = "LocationId";
            ddlLocation.DataBind();
        }

        private void BindGridView(string filter)
        {
            gvProjects.DataSource = Biliwanagin.ProcurementManager.GetExistingProjects(filter);
            gvProjects.DataBind();
        }

        protected void btnTable_Click(object sender, EventArgs e)
        {
            pnlAmount.Visible = false;
            pnlMap.Visible = false;
            pnlMode.Visible = false;
            pnlStatus.Visible = false;
            pnlTable.Visible = true;
        }

        protected void btnMap_Click(object sender, EventArgs e)
        {
            pnlAmount.Visible = false;
            pnlMap.Visible = true;
            pnlMode.Visible = false;
            pnlStatus.Visible = false;
            pnlTable.Visible = false;
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            pnlAmount.Visible = false;
            pnlMap.Visible = false;
            pnlMode.Visible = false;
            pnlStatus.Visible = true;
            pnlTable.Visible = false;

            ChartStatus();
        }

        protected void btnMode_Click(object sender, EventArgs e)
        {
            pnlAmount.Visible = false;
            pnlMap.Visible = false;
            pnlMode.Visible = true;
            pnlStatus.Visible = false;
            pnlTable.Visible = false;

            ChartMode();
        }

        protected void btnAmount_Click(object sender, EventArgs e)
        {
            pnlAmount.Visible = true;
            pnlMap.Visible = false;
            pnlMode.Visible = false;
            pnlStatus.Visible = false;
            pnlTable.Visible = false;

            ChartAmount();
        }

        protected void gvProjects_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProjects.PageIndex = e.NewPageIndex;
            BindGridView(filter);
        }

        protected void gvProjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //display project stage when ref_id link button is clicked
        }

        protected void btnYear1_Click(object sender, EventArgs e)
        {
            Button btnYear = (Button)sender;
            //BindGridView(string.Format("YEAR(b.publish_date) = {0}", btnYear.Text));
            //if (!string.IsNullOrEmpty(filter))
            //    filter = string.Format("{0} and YEAR(b.publish_date) = {0}", filter, btnYear.Text);
            //else
                filter = string.Format("YEAR(b.publish_date) = {0}", btnYear.Text);

                BindGridView(filter);
        }

        protected void ChartStatus()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_Local"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();
            //StringBuilder query = new StringBuilder();
            //query.Append("SELECT p201_year, total_nods");
            //query.Append(" FROM dbo.p201c_summary");
            //SqlCommand cmd = new SqlCommand(query.ToString(), con);

            string query = @"select Count(*) as project_count,
                                    tender_status
                                from dbo.Bids b
                                left join dbo.ProjectLocations p
                                    on b.ref_no = p.refid
                                left join dbo.Awards a
                                    on b.ref_no = a.ref_id
                                where ref_no is not null
                                group by tender_status";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "PremiumData");

            if (ds.Tables["PremiumData"].Rows.Count > 0)
            {

                Chart1.DataSource = ds.Tables["PremiumData"];
                Chart1.Series["Count"].XValueMember = "tender_status";
                Chart1.Series["Count"].YValueMembers = "project_count";
                Chart1.Series["Count"].IsValueShownAsLabel = true;

                Chart1.Series["Count"]["3DLabelLineSize"] = "100";
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 15;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 10;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;
                Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;
                Chart1.Series[0]["PieDrawingStyle"] = "SoftEdge";
                Chart1.Series["Count"].ChartType = SeriesChartType.Pie;
                Chart1.Series["Count"]["PieLabelStyle"] = "OutsideInColumn";
                Chart1.Series["Count"]["PieOutsideLabelPlacement"] = "Right";
                Chart1.Titles[1].Text = "Pie Chart";

                Chart1.DataBind();
            }
        }

        protected void ChartMode()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_Local"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();

            string query = @"select Count(*) as project_count,
                                    procurement_mode
                                from dbo.Bids b
                                left join dbo.ProjectLocations p
                                    on b.ref_no = p.refid
                                left join dbo.Awards a
                                    on b.ref_no = a.ref_id
                                where ref_no is not null
                                group by procurement_mode";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "PremiumData");

            if (ds.Tables["PremiumData"].Rows.Count > 0)
            {

                Chart2.DataSource = ds.Tables["PremiumData"];
                Chart2.Series["Count"].XValueMember = "procurement_mode";
                Chart2.Series["Count"].YValueMembers = "project_count";
                Chart2.Series["Count"].IsValueShownAsLabel = true;

                Chart2.Series["Count"]["3DLabelLineSize"] = "100";
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 15;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 10;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;
                Chart2.Series[0]["PieDrawingStyle"] = "SoftEdge";
                Chart2.Series["Count"].ChartType = SeriesChartType.Pie;
                Chart2.Series["Count"]["PieLabelStyle"] = "OutsideInColumn";
                Chart2.Series["Count"]["PieOutsideLabelPlacement"] = "Right";
                Chart2.Titles[1].Text = "Pie Chart";

                Chart2.DataBind();
            }
        }

        protected void ChartAmount()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString_Local"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();

            string query = @"select Count(*) as project_count,
                                    approved_budget
                                from dbo.Bids b
                                left join dbo.ProjectLocations p
                                    on b.ref_no = p.refid
                                left join dbo.Awards a
                                    on b.ref_no = a.ref_id
                                where ref_no is not null
                                group by approved_budget";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "PremiumData");

            if (ds.Tables["PremiumData"].Rows.Count > 0)
            {

                Chart3.DataSource = ds.Tables["PremiumData"];
                Chart3.Series["Count"].XValueMember = "approved_budget";
                Chart3.Series["Count"].YValueMembers = "project_count";
                Chart3.Series["Count"].IsValueShownAsLabel = true;

                Chart3.Series["Count"]["3DLabelLineSize"] = "100";
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 15;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 10;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;
                Chart3.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;
                Chart3.Series[0]["PieDrawingStyle"] = "SoftEdge";
                Chart3.Series["Count"].ChartType = SeriesChartType.Pie;
                Chart3.Series["Count"]["PieLabelStyle"] = "OutsideInColumn";
                Chart3.Series["Count"]["PieOutsideLabelPlacement"] = "Right";
                Chart3.Titles[1].Text = "Pie Chart";

                Chart3.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(gvProjects);
        }

        private void ExportToExcel(GridView grid)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Projects.xls");
            Response.Charset = "";

            // If you want the option to open the Excel file without saving, comment out the line below
            // Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            grid.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
    }
}