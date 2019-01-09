using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Course : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            
                List<Subject> subjectlist = new List<Subject>();
                
                string sql = "SELECT TOP 1000 [SubjectCode]  ,[SubjectName] FROM[ProJectCSharp].[dbo].[Subject]";
                DataTable tbl = dt.getDataByQuery(sql);
                foreach(DataRow dr in tbl.Rows)
                {
                    subjectlist.Add(new Subject(dr[0].ToString(), dr[1].ToString()));
                }
                DropDownList1.DataSource = subjectlist;
                DropDownList1.DataTextField = "name";
                DropDownList1.DataValueField = "code";
            if (Request.QueryString["name"] != null)
            {
                string name = Request.QueryString["name"];
                string code = Request.QueryString["code"];
                for(int i = 0; i < subjectlist.Count; i++)
                {
                    if (subjectlist[i].name.Equals(name))
                    {
                        DropDownList1.SelectedIndex = i;
                    }
                }
            }
            else
            {
                DropDownList1.SelectedIndex = 0;
            }
            DropDownList1.DataBind();
            string value = DropDownList1.SelectedValue.ToString().Replace(" ","");
            string query = "SELECT  distinct t1.*,(select count(*) from ClassAttendence as t3 where t3.SubjectCode=t2.SubjectCode ) FROM[ProJectCSharp].[dbo].[TimetableOfSubject] as t1 inner join classattendence as t2 on t1.subjectcode = t2.subjectcode where t1.subjectcode like '%"+value+"%';";
            DataTable datasource = dt.getDataByQuery(query);
            Label3.Text = "Total records: " + datasource.Rows.Count.ToString();
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Class");
            tbl1.Columns.Add("Time");
            tbl1.Columns.Add("Start date");
            tbl1.Columns.Add("End date");
            tbl1.Columns.Add("Teacher");
            tbl1.Columns.Add("Room");
            tbl1.Columns.Add("Number of student");
            foreach (DataRow dr in datasource.Rows)
            {
                DataRow row = tbl1.NewRow();
                row[0] = dr[0].ToString();
                string[] time = dr[1].ToString().Replace(" ","").Split(',');
                string slot1 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) - 1);
                slot1 = "Slot " + time[0].Substring(0, 1) + " - " + slot1;
                string slot2 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) - 1);
                slot2 = "Slot " + time[1].Substring(0, 1) + " - " + slot2;
                string slot3 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) - 1);
                slot3 = "Slot " + time[2].Substring(0, 1) + " - " + slot3;
                string finalTime = slot1 + ", " + slot2 + ", " + slot3;
                row[1] = finalTime;
                row[2] = dr[3].ToString();
                row[3] = dr[4].ToString();
                row[4] = dr[5].ToString();
                row[5] = dr[6].ToString();
                row[6] = dr[7].ToString();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        string value = TextBox1.Text;
        DataAccess dt = new DataAccess();
        string query = "SELECT  distinct t1.*,(select count(*) from ClassAttendence as t3 where t3.SubjectCode=t2.SubjectCode ) FROM[ProJectCSharp].[dbo].[TimetableOfSubject] as t1 inner join classattendence as t2 on t1.subjectcode = t2.subjectcode where t1.subjectcode like '%" + value + "%';";
        DataTable datasource = dt.getDataByQuery(query);
        Label3.Text = "Total records: " + datasource.Rows.Count.ToString();
        DataTable tbl1 = new DataTable();
        tbl1.Columns.Add("Class");
        tbl1.Columns.Add("Time");
        tbl1.Columns.Add("Start date");
        tbl1.Columns.Add("End date");
        tbl1.Columns.Add("Teacher");
        tbl1.Columns.Add("Room");
        tbl1.Columns.Add("Number of student");
        foreach (DataRow dr in datasource.Rows)
        {
            DataRow row = tbl1.NewRow();
            row[0] = dr[0].ToString().Replace(" ","");
            string[] time = dr[1].ToString().Replace(" ", "").Split(',');
            string slot1 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) - 1);
            slot1 = "Slot " + time[0].Substring(0, 1) + " - " + slot1;
            string slot2 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) - 1);
            slot2 = "Slot " + time[1].Substring(0, 1) + " - " + slot2;
            string slot3 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) - 1);
            slot3 = "Slot " + time[2].Substring(0, 1) + " - " + slot3;
            string finalTime = slot1 + ", " + slot2 + ", " + slot3;
            row[1] = finalTime;
            row[2] = dr[3].ToString();
            row[3] = dr[4].ToString();
            row[4] = dr[5].ToString();
            row[5] = dr[6].ToString();
            row[6] = dr[7].ToString();
            tbl1.Rows.Add(row);
        }
        GridView1.DataSource = tbl1;
        GridView1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        string value = DropDownList1.SelectedValue.ToString().Replace(" ", "");
        string query = "SELECT  distinct t1.*,(select count(*) from ClassAttendence as t3 where t3.SubjectCode=t2.SubjectCode ) FROM[ProJectCSharp].[dbo].[TimetableOfSubject] as t1 inner join classattendence as t2 on t1.subjectcode = t2.subjectcode where t1.subjectcode like '%" + value + "%';";
        DataTable datasource = dt.getDataByQuery(query);
        Label3.Text = "Total records: "+datasource.Rows.Count.ToString();
        DataTable tbl1 = new DataTable();
        tbl1.Columns.Add("Class");
        tbl1.Columns.Add("Time");
        tbl1.Columns.Add("Start date");
        tbl1.Columns.Add("End date");
        tbl1.Columns.Add("Teacher");
        tbl1.Columns.Add("Room");
        tbl1.Columns.Add("Number of student");
        foreach (DataRow dr in datasource.Rows)
        {
            DataRow row = tbl1.NewRow();
            row[0] = dr[0].ToString();
            string[] time = dr[1].ToString().Replace(" ", "").Split(',');
            string slot1 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) - 1);
            slot1 = "Slot " + time[0].Substring(0, 1) + " - " + slot1;
            string slot2 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) - 1);
            slot2 = "Slot " + time[1].Substring(0, 1) + " - " + slot2;
            string slot3 = Enum.GetName(typeof(DayOfWeek), Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) - 1);
            slot3 = "Slot " + time[2].Substring(0, 1) + " - " + slot3;
            string finalTime = slot1 + ", " + slot2 + ", " + slot3;
            row[1] = finalTime;
            row[2] = dr[3].ToString();
            row[3] = dr[4].ToString();
            row[4] = dr[5].ToString();
            row[5] = dr[6].ToString();
            row[6] = dr[7].ToString();
            tbl1.Rows.Add(row);
        }
        GridView1.DataSource = tbl1;
        GridView1.DataBind();
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
            e.Row.Cells[6].BackColor = col;
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
            e.Row.Cells[6].BackColor = col;
        }
    }
}