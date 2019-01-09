using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TeacherRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string msg = TextBox1.Text;
        if (msg.Length < 200)
        {
            DataAccess dt = new DataAccess();
            string user = Session["CUser"].ToString();
            string sql = "select * from [RequestOfTeacher] where teachercode='" + user + "';";
            DataTable dataTable = dt.getDataByQuery(sql);
            if (dataTable.Rows.Count == 0)
            {
                int x = dt.insertToTeacherRequest(user, msg);
                if (x > 0)
                {
                    Label2.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label2" + "').style.display='none'\",1000)</script>");
                }
            }
            else
            {
                Label3.Visible = true;

            }
        }
    }
}