using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class SemesterTranscript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string user = Session["CUser"].ToString();
           // string user = "SE5000";
            DataAccess dt = new DataAccess();
            List<string> teacherList = new List<string>();
            //subject class
            List<string> subjectlist = new List<string>();
            // subject name
            List<string> subjectNamelist = new List<string>();
            //subject code
            List<string> subjectlistCode = new List<string>();
            DataTable tbl = dt.getLearningSubject(user);
            foreach (DataRow dr in tbl.Rows)
            {
                string s = dr[0].ToString();
                subjectlist.Add(s);
                s = s.Substring(0, 6);
                subjectlistCode.Add(s);
                DataTable subtbl = dt.getSubject(s);
                foreach (DataRow dr1 in subtbl.Rows)
                {
                    subjectNamelist.Add(dr1[0].ToString());
                }
            }
            List<GridView> gridviewlist = new List<GridView>();
            gridviewlist.Add(GridView1);
            gridviewlist.Add(GridView2);
            gridviewlist.Add(GridView3);
            gridviewlist.Add(GridView4);
            gridviewlist.Add(GridView5);
            gridviewlist.Add(GridView6);
            List<Label> labellist = new List<Label>();
            labellist.Add(Label5);
            labellist.Add(Label6);
            labellist.Add(Label11);
            labellist.Add(Label1);
            labellist.Add(Label7);
            labellist.Add(Label12);
            labellist.Add(Label2);
            labellist.Add(Label8);
            labellist.Add(Label13);
            labellist.Add(Label3);
            labellist.Add(Label9);
            labellist.Add(Label14);
            labellist.Add(Label4);
            labellist.Add(Label10);
            labellist.Add(Label15);
            labellist.Add(Label16);
            labellist.Add(Label17);
            labellist.Add(Label18);
            for (int i = 0; i < subjectlist.Count; i++)
            {
                labellist[i * 3].Text = subjectNamelist[i];
                labellist[i * 3].Visible = true;
                labellist[i * 3+1].Visible = true;
                labellist[i * 3 + 2].Visible = true;
                gridviewlist[i].Visible = true;
            }
            List<string> typeofgrade = dt.getTypeOfGrade();
            for(int j = 0; j < subjectlist.Count; j++)
            {
                string sql = "select [progresstest1],[progresstest2],lab1,lab2,[Project/PracticeExam],final from ClassAttendence where StudentCode =' " + user + "' and subjectcode" +
     " ='" + subjectlist[j] + "'";
                DataTable table = dt.getDataByQuery(sql);

                DataTable datasource = new DataTable();
                datasource.Columns.Add("#");
                datasource.Columns.Add("Name of grade");
                datasource.Columns.Add("Weight");
                datasource.Columns.Add("Grade");
                double sum = 0;
                double heso = 0;
                double final = 0;
                for (int i = 0; i < typeofgrade.Count; i++)
                {
                    DataRow row = datasource.NewRow();
                    row[0] = i + 1;
                    row[1] = typeofgrade[i];
                    if (typeofgrade[i].Contains("progres"))
                    {
                        row[2] = "10%";
                    }
                    else if (typeofgrade[i].Contains("Lab"))
                    {
                        row[2] = "10%";
                    }
                    else
                    {
                        row[2] = "30%";
                    }
                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr[0].ToString() != null && !dr[0].ToString().Replace(" ", "").Equals(""))
                        {
                            try
                            {
                                double score = Convert.ToDouble(dr[0].ToString());
                                sum += score * heso;
                                if (row[2].Equals("30%"))
                                {
                                    final = Convert.ToDouble(dr[0].ToString());
                                }
                                row[3] = dr[0].ToString();
                            }
                            catch (Exception)
                            {
                                row[3] = "--";
                            }
                        }
                        else
                        {
                            row[3] = "--";
                        }
                    }
                    datasource.Rows.Add(row);
                }
                
                    gridviewlist[j].DataSource = datasource;
                    gridviewlist[j].DataBind();
                if (final > 4 && sum > 5)
                {
                    labellist[j * 3 + 1].Text = "Average: " + sum;
                    labellist[j * 3 + 2].Text = "Status: Passed";
                    labellist[j * 3 + 2].ForeColor = Color.Green;
                }
                else
                {
                    labellist[j * 3 + 1].Text = "Average: " + sum;
                    labellist[j * 3 + 2].Text = "Status: Not Passed";
                    labellist[j * 3 + 2].ForeColor = Color.Red;
                }
                
               
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

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GridView5_DataBound(object sender, EventArgs e)
    {
        
    }

    protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
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