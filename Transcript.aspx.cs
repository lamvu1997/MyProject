using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Transcript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            List<string> subjectcodelist = new List<string>();
            subjectcodelist = dt.listofsubjectcode();
              string studentcode = Session["CUser"].ToString();
            //string studentcode = "SE5000";
              string sql = "select * from [StudentRecord] where studentcode = '" + studentcode + "';";
            DataTable tbl = dt.getDataByQuery(sql);
            DataTable datasource = new DataTable();
            datasource.Columns.Add("#");
            datasource.Columns.Add("Subject");
            datasource.Columns.Add("Subject code");
            datasource.Columns.Add("Number of credit");
            datasource.Columns.Add("Grade");
            datasource.Columns.Add("Status");
            double sum = 0;
            int countsub = 0;
            int bis = 0;
            int ongoing = 0;
            int passlab = 0;
            for (int i=0;i<25;i++ )
            {
                DataRow row = datasource.NewRow();
                row[0] = i+1;
                row[1] = dt.getSubjectByCode(subjectcodelist[i+1].ToString());
                row[2] = subjectcodelist[i+1].ToString();
                row[3] = "3";
                string grade = tbl.Rows[0][i + 1].ToString();
                if(grade.Contains("Not start"))
                {
                    row[4] = "--";
                    row[5] = "Not start";
                }
                else if(grade.Contains("Learning"))
                {
                    row[4] = "--";
                    row[5] = "Learning";
                    ongoing++;
                }
                else if (grade.Contains("Passed"))
                {
                    row[4] = "0.0";
                    row[5] = "Passed";
                    passlab++;
                }
                else 
                {
                    Double d = Convert.ToDouble(grade.Replace(".",","));
                    grade = String.Format("{0:0.0}",d);
                    row[4] = grade;
                    
                    if (d >= 5.0)
                    {
                        row[5] = "Passed";
                        sum += d;
                        countsub++;
                    }
                    else
                    {
                        row[5] = "Bis";
                        bis++;
                    }
                }
                
                datasource.Rows.Add(row);
                
            }
            if (countsub != 0)
            {
                Label2.Text = "Average: "+String.Format("{0:0.00}", sum / countsub)+"   Passed/Total: "+(countsub*3+passlab*3)+"/75(Credit)";
            }
            else
            {
                Label2.Text = "Average: " + "0" + "   Passed/Total: " + countsub * 3 + "/75(Credit)";
            }
            GridView1.DataSource = datasource;
            GridView1.DataBind();
            DataTable datasource2 = new DataTable();
            datasource2.Columns.Add("Total not-started subjects");
            datasource2.Columns.Add("Total passed subjects	");
            datasource2.Columns.Add("Total bis-subjects	");
            datasource2.Columns.Add("Total ongoing subjects");
            DataRow r = datasource2.NewRow();
            r[0] = 25 - ongoing - countsub-passlab;
            r[1] = countsub+passlab;
            r[2] = bis;
            r[3] = ongoing;
            datasource2.Rows.Add(r);
            GridView2.DataSource = datasource2;
            GridView2.DataBind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataAccess dt = new DataAccess();
        List<string> subjectcodelist = new List<string>();
        subjectcodelist = dt.listofsubjectcode();
         string studentcode = Session["CUser"].ToString();
       // string studentcode = "SE5000";
        string sql = "select * from [StudentRecord] where studentcode = '" + studentcode + "';";
        DataTable tbl = dt.getDataByQuery(sql);
        DataTable datasource = new DataTable();
        datasource.Columns.Add("#");
        datasource.Columns.Add("Subject");
        datasource.Columns.Add("Subject code");
        datasource.Columns.Add("Number of credit");
        datasource.Columns.Add("Grade");
        datasource.Columns.Add("Status");
        double sum = 0;
        int countsub = 0;
        int bis = 0;
        int ongoing = 0;
        int passlab = 0;
        for (int i = 0; i < 25; i++)
        {
            DataRow row = datasource.NewRow();
            row[0] = i + 1;
            row[1] = dt.getSubjectByCode(subjectcodelist[i + 1].ToString());
            row[2] = subjectcodelist[i + 1].ToString();
            row[3] = "3";
            string grade = tbl.Rows[0][i + 1].ToString();
            if (grade.Contains("Not start"))
            {
                row[4] = "--";
                row[5] = "Not start";
            }
            else if (grade.Contains("Learning"))
            {
                row[4] = "--";
                row[5] = "Learning";
                ongoing++;
            }
            else if (grade.Contains("Passed"))
            {
                row[4] = "0.0";
                row[5] = "Passed";
                passlab++;
            }
            else
            {
                Double d = Convert.ToDouble(grade.Replace(".", ","));
                
                grade = String.Format("{0:0.00}", d);
                row[4] = grade;

                if (d >= 5.0)
                {
                    row[5] = "Passed";
                    sum += d;
                    countsub++;
                }
                else
                {
                    row[5] = "Bis";
                    bis++;
                }
            }

            datasource.Rows.Add(row);

        }
        GridView1.DataSource = datasource;
        GridView1.DataBind();
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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