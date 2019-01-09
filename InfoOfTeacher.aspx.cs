using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class InfoOfTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string teacher = Request.QueryString["teacher"];
            DataAccess dt = new DataAccess();
            string query = "select * from teacher where teachercode='" + teacher + "'";
            DataTable tbl = dt.getDataByQuery(query);
            foreach (DataRow dr in tbl.Rows)
            {
                Label4.Text = dr[0].ToString();
                Label5.Text = dr[1].ToString();
                Label6.Text = dr[2].ToString();
                Label9.Text = dr[3].ToString();
                Label10.Text = dr[4].ToString();
            }
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

        string value = TreeView1.SelectedValue.ToString();
        if (value.Equals("Timetable"))
        {
            Response.Redirect("HomePage.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("On going class"))
        {
            Response.Redirect("OngoingClass.aspx?id=1", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Take attendace"))
        {
            Response.Redirect("Attendance.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Course"))
        {
            Response.Redirect("Course.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Transcript"))
        {
            Response.Redirect("Transcript.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Semester transcript"))
        {
            Response.Redirect("SemesterTranscript.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Sign in new class"))
        {
            Response.Redirect("SigninNewCourse.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Change class"))
        {
            Response.Redirect("ChangeClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Cancel class"))
        {
            Response.Redirect("CancelClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else
        {
            Response.Redirect("Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}