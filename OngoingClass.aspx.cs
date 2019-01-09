using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class OngoingClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string user = Session["CUser"].ToString();
            //string user = "SE5000";
            DataAccess dt = new DataAccess();
            //subject class
            List<string> subjectlist = new List<string>();
            // subject name
            List<string> subjectNamelist = new List<string>();
            //subject code
            List<string> subjectlistCode = new List<string>();
            DataTable tbl = dt.getLearningSubject(user);
            foreach(DataRow dr in tbl.Rows)
            {
                string s = dr[0].ToString();
                subjectlist.Add(s);
                s = s.Substring(0, 6);
                subjectlistCode.Add(s);
                DataTable subtbl = dt.getSubject(s);
                foreach(DataRow dr1 in subtbl.Rows)
                {
                    subjectNamelist.Add(dr1[0].ToString());
                }
            }
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Subject");
            tbl1.Columns.Add("Subject Code");
            tbl1.Columns.Add("Number of credit");
            tbl1.Columns.Add("Class name");
            tbl1.Columns.Add("Start date");
            tbl1.Columns.Add("End date");
            for(int i = 0; i < subjectlist.Count; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = subjectNamelist[i];
                row[1] = subjectlistCode[i];
                row[2] = "3";
                row[3] = subjectlist[i];
                row[4] = "04/09/2017";
                row[5] = "12/11/2017";
                tbl1.Rows.Add(row);
            }
            GridView1.DataSource = tbl1;
            GridView1.DataBind();
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#B0E0E6");
            e.Row.Cells[0].BackColor = col;
            e.Row.Cells[1].BackColor = col;
            e.Row.Cells[2].BackColor = col;
            e.Row.Cells[3].BackColor = col;
            e.Row.Cells[4].BackColor = col;
            e.Row.Cells[5].BackColor = col;
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {

            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");
            e.Row.Cells[0].BackColor = col;
            e.Row.Cells[1].BackColor = col;
            e.Row.Cells[2].BackColor = col;
            e.Row.Cells[3].BackColor = col;
            e.Row.Cells[4].BackColor = col;
            e.Row.Cells[5].BackColor = col;
        }
    }
}