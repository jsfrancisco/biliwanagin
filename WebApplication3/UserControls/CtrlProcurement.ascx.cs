using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3.UserControls
{
    public partial class CtrlProcurement : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_02.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_01.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = true;
            ImageButton2.Enabled = false;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_01.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_02.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_02.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_01.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_02.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_01.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_02.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_01.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = true;
            ImageButton3.Enabled = true;
            ImageButton4.Enabled = true;
            ImageButton5.Enabled = true;
            ImageButton6.Enabled = true;
            ImageButton7.Enabled = true;

            ImageButton1.ImageUrl = "~/Images/tab01_02.jpg";
            ImageButton2.ImageUrl = "~/Images/tab02_01.jpg";
            ImageButton3.ImageUrl = "~/Images/tab03_01.jpg";
            ImageButton4.ImageUrl = "~/Images/tab04_01.jpg";
            ImageButton5.ImageUrl = "~/Images/tab05_01.jpg";
            ImageButton6.ImageUrl = "~/Images/tab06_01.jpg";
            ImageButton7.ImageUrl = "~/Images/tab07_01.jpg";
        }
    }
}