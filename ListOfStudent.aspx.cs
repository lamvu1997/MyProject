using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class ListOfStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string group = Request.QueryString["group"];
            DataAccess dt = new DataAccess();
            string query = "SELECT TOP 1000 t1.* FROM[ProJectCSharp].[dbo].[StudentInfo] as t1 inner join ClassAttendence as t2 on t1.StudentCode = t2.StudentCode where t2.SubjectCode = '" + group + "';";
            DataTable tbl = dt.getDataByQuery(query);
            DataTable table = new DataTable();
            table.Columns.Add("Index");
            table.Columns.Add("Code");
            table.Columns.Add("Full Name");
            table.Columns.Add("Email");
            int i = 1;
            foreach(DataRow dr in tbl.Rows)
            {
                DataRow row = table.NewRow();
                row[0] = i++;
                row[1] = dr[0].ToString();
                row[2] = dr[1].ToString();
                row[3] = dr[4].ToString();
                table.Rows.Add(row);
            }
            GridView1.DataSource = table;
           // GridView1.Rows[0].Cells[2].ForeColor = Color.Blue;
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
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {

            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");
            e.Row.Cells[0].BackColor = col;
            e.Row.Cells[1].BackColor = col;
            e.Row.Cells[2].BackColor = col;
            e.Row.Cells[3].BackColor = col;
        }
    }
}