using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class InfoOfClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            string group = Request.QueryString["class"];
            LinkButton1.Text = group;
            string teacher = Request.QueryString["teacher"];
            LinkButton2.Text = teacher;
            Session["teacherlist"] = null;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListOfStudent.aspx?group=" + LinkButton1.Text);
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("InfoOfTeacher.aspx?teacher=" + LinkButton2.Text);
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