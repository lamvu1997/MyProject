using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string user = Session["CUser"].ToString();
            //string user = "SE5000";
            DropDownList1.Items.Add("04/09-10/09");
            DropDownList1.Items.Add("11/09-17/09");
            DropDownList1.Items.Add("18/09-24/09");
            DropDownList1.Items.Add("25/09-01/10");
            DropDownList1.Items.Add("02/10-08/10");
            DropDownList1.Items.Add("09/10-15/10");
            DropDownList1.Items.Add("16/10-22/10");
            DropDownList1.Items.Add("23/10-29/10");
            DropDownList1.Items.Add("30/10-05/11");
            DropDownList1.Items.Add("06/11-12/11");
            DataTable dt = new DataTable();
            dt.Columns.Add("Slot");
            dt.Columns.Add("Mon");
            dt.Columns.Add("TUE");
            dt.Columns.Add("WED");
            dt.Columns.Add("THU");
            dt.Columns.Add("FRI");
            dt.Columns.Add("SAT");
            dt.Columns.Add("SUN");
            DataAccess data = new DataAccess();
            DataTable tbl = data.getTimetableofOneStudent(user);
            List<TimeTableOfStudent> listTime = new List<TimeTableOfStudent>();
            List<string> listofSlot = new List<string>();
            foreach(DataRow dr in tbl.Rows)
            {
                TimeTableOfStudent t= (new TimeTableOfStudent(dr[0].ToString(), dr[2].ToString(), dr[3].ToString()));
                listTime.Add(t);
            }
            for (int i = 1; i < 7; i++)
            {
                DataRow row = dt.NewRow();
                row["Slot"] = i;
                row[1] = "";
                row[2] = "";
                row[3] = "";
                row[4] = "";
                row[5] = "";
                row[6] = "";
                row[7] = "";
                dt.Rows.Add(row);

            }
            for(int i = 0; i < listTime.Count; i++)
            {
                string time = listTime[i].slot;
                string[] slot = time.Split(',');
                for(int j = 0; j < slot.Length; j++)
                {
                    string day = slot[j].Substring(slot[j].Length - 1, 1);
                    string  s = slot[j].Substring(0, 1);
                    int day1 = Convert.ToInt16(day);
                    int s1 = Convert.ToInt16(s);
                    dt.Rows[s1 - 1][day1 - 1] = listTime[i].subject + " at " + listTime[i].room;
                }
            }
            GridView1.DataSource = dt;
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
            e.Row.Cells[6].BackColor = col;
            e.Row.Cells[7].BackColor = col;
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
            e.Row.Cells[7].BackColor = col;
        }
    }
}