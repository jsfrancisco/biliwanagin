using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication3.UserControls
{
    public partial class CtrlSampleChart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Chart();
        }
        protected void Chart()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TargetSubConnectionString_Local"].ConnectionString);
            con.Open();
            DataSet ds = new DataSet();
            StringBuilder query = new StringBuilder();
            query.Append("SELECT p201_year, total_nods");
            query.Append(" FROM dbo.p201c_summary");
            SqlCommand cmd = new SqlCommand(query.ToString(), con);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds, "PremiumData");

            if (ds.Tables["PremiumData"].Rows.Count > 0)
            {

                Chart1.DataSource = ds.Tables["PremiumData"];
                Chart1.Series["Count"].XValueMember = "p201_year";
                Chart1.Series["Count"].YValueMembers = "total_nods";
                Chart1.Series["Count"].IsValueShownAsLabel = true;

                if (ChartType.SelectedItem.ToString() == "Bar")
                {
                    Chart1.Series["Count"].ChartType = SeriesChartType.Bar;
                    Chart1.Titles[1].Text = "Bar Chart";
                }
                else if (ChartType.SelectedItem.ToString() == "Pie")
                {
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
                }
                else if (ChartType.SelectedItem.ToString() == "Line")
                {
                    Chart1.Series["Count"].ChartType = SeriesChartType.Line;
                    Chart1.Titles[1].Text = "Line Chart";
                }
                else if (ChartType.SelectedItem.ToString() == "Funnel")
                {
                    Chart1.Series["Count"]["FunnelStyle"] = "YIsHeight";
                    Chart1.Series["Count"]["FunnelLabelStyle"] = "OutsideInColumn";
                    Chart1.Series["Count"]["FunnelOutsideLabelPlacement"] = "Right";
                    Chart1.Series["Count"]["FunnelPointGap"] = "1";
                    Chart1.Series["Count"]["Funnel3DDrawingStyle"] = "SoftEdge";
                    Chart1.Series["Count"].ChartType = SeriesChartType.Funnel;
                    Chart1.Series["Count"]["Funnel3DRotationAngle"] = "5";
                    Chart1.Series["Count"]["Funnel3DDrawingStyle"] = "CircularBase";
                    Chart1.Series["Count"]["FunnelMinPointHeight"] = "0";
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 15;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 10;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 10;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsRightAngleAxes = false;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.WallWidth = 0;
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.IsClustered = false;
                    Chart1.Titles[1].Text = "Funnel Chart";
                }
                else if (ChartType.SelectedItem.ToString() == "Area")
                {
                    Chart1.Series["Count"].ChartType = SeriesChartType.Area;
                    Chart1.Titles[1].Text = "Area Chart";
                }
                else if (ChartType.SelectedItem.ToString() == "Pyramid")
                {
                    Chart1.Series["Count"]["PyramidLabelStyle"] = "OutsideInColumn";
                    Chart1.Series["Count"]["PyramidPointGap"] = "1";
                    Chart1.Series["Count"]["PyramidMinPointHeight"] = "0";
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.Series["Count"]["Pyramid3DRotationAngle"] = "5";
                    Chart1.Series["Count"]["Pyramid3DDrawingStyle"] = "SquareBase";
                    Chart1.Series["Count"]["PyramidValueType"] = "Linear";
                    Chart1.Series["Count"].ChartType = SeriesChartType.Pyramid;
                    Chart1.Titles[1].Text = "Pyramid Chart";
                }
                else
                {
                    Chart1.Series["Count"].ChartType = SeriesChartType.Column;
                    Chart1.Titles[1].Text = "Column Chart";
                }

                Chart1.DataBind();
            }
        }
    }
}