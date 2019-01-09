using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class AnnouncementofTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            string user = Session["CUser"].ToString();
            string sql = "select message from response where Code ='" + user + "';";
            string msg = "";
            DataTable tbl = dt.getDataByQuery(sql);
            if (tbl.Rows.Count > 0)
            {

                foreach (DataRow dr in tbl.Rows)
                {
                    msg += "- "+dr[0].ToString() + "\n";
                }
                TextBox1.Text = msg;
                TextBox1.Visible = true;
                Button1.Visible = true;
                Label2.Visible = false;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        string user = Session["CUser"].ToString();
        dt.deletetresponse(user);
        string sql = "select message from response where Code ='" + user + "';";
        string msg = "";
        DataTable tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            msg += dr[0].ToString() + "\n";
        }
        TextBox1.Text = msg;
        Label1.Visible = true;
        ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label1" + "').style.display='none'\",4000)</script>");
    }
}