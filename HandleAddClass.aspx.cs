using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HandleAddClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            string sql = "select studentcode,msg from [RequestOfStudent] where type='Signinclass'";
            DataTable tbl = dt.getDataByQuery(sql);
            List<string> student = new List<string>();
            foreach (DataRow dr in tbl.Rows)
            {
                int x = 0;
                for (int i = 0; i < student.Count; i++)
                {
                    if (student[i].Equals(dr[0].ToString()))
                    {
                        x = 1;
                        break;
                    }
                }
                if (x == 0)
                {
                    student.Add(dr[0].ToString());
                }
            }
            for (int i = 0; i < student.Count; i++)
            {
                DropDownList1.Items.Add(student[i]);
            }
            if (DropDownList1.Items.Count > 0)
            {
                DropDownList1.SelectedIndex = 0;
                Label8.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                Button1.Visible = true;
                Button2.Visible = true;
                TextBox1.Visible = true;
                string s = DropDownList1.SelectedItem.ToString();
                sql = "select msg from RequestOfStudent where type='Signinclass' and studentcode='" + s + "';";
                tbl = dt.getDataByQuery(sql);
                string msg = "";
                foreach (DataRow dr in tbl.Rows)
                {
                    msg += dr[0].ToString();
                }
                TextBox1.Text = msg;
                sql = "select [SubjectCode] from [TimetableOfSubject] ;";
                tbl = dt.getDataByQuery(sql);
                foreach (DataRow dr in tbl.Rows)
                {
                    DropDownList2.Items.Add(dr[0].ToString());
                }
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        string s = DropDownList1.SelectedItem.ToString();
       string sql = "select msg from RequestOfStudent where type='Signinclass' and studentcode='" + s + "';";
       DataTable tbl = dt.getDataByQuery(sql);
        string msg = "";
        foreach (DataRow dr in tbl.Rows)
        {
            msg += dr[0].ToString();
        }
        TextBox1.Text = msg;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label7.Visible = false;
        Label11.Visible = false;
        string user = DropDownList1.SelectedItem.ToString();
        string Class = DropDownList2.SelectedItem.ToString();
        // check thoi gian hoc
        DataAccess dt = new DataAccess();
        string sql = "select slot from ClassAttendence inner join TimetableOfSubject on ClassAttendence.SubjectCode=TimetableOfSubject.SubjectCode where ClassAttendence.StudentCode = '" + user + "'";
        DataTable tbl = dt.getDataByQuery(sql);
        List<string> slotofstudent = new List<string>();
        foreach(DataRow dr in tbl.Rows)
        {
            string x = dr[0].ToString().Replace(" ", "");
            string[] x1 = x.Split(',');
            for(int i = 0; i < x1.Length; i++)
            {
                slotofstudent.Add(x1[i]);
            }
        }
        sql = "select distinct timetableofsubject.slot from ClassAttendence inner join TimetableOfSubject on ClassAttendence.SubjectCode=TimetableOfSubject.SubjectCode where ClassAttendence.SubjectCode = '" + Class + "'";
        tbl = dt.getDataByQuery(sql);
        List<string> slotofClass = new List<string>();
        foreach (DataRow dr in tbl.Rows)
        {
            string x = dr[0].ToString().Replace(" ", "");
            string[] x1 = x.Split(',');
            for (int i = 0; i < x1.Length; i++)
            {
                slotofClass.Add(x1[i]);
            }
        }
        int check1 = 1;
        for(int i = 0; i < slotofstudent.Count; i++)
        {
            if(slotofstudent[i].Equals(slotofClass[0])|| slotofstudent[i].Equals(slotofClass[1])|| slotofstudent[i].Equals(slotofClass[2]))
            {
                check1 = 0;
                break;
            }
        }
        if (check1 == 1)
        {
            // kiem tra mon dieu kien neu co
            string subject = Class.Replace(" ","").Substring(0, 6);
            sql = "select [ConditionSubject] from [SubCondition] where subject like '%" + subject + "%'";
            tbl = dt.getDataByQuery(sql);
            List<string> subjectlist = new List<string>();
            foreach(DataRow dr in tbl.Rows)
            {
                string x = dr[0].ToString().Replace(" ", "");
                string[] x1 = x.Split(',');
                for(int i = 0; i < x1.Length; i++)
                {
                    subjectlist.Add(x1[i]);
                }
            }
            int check2 = 1;
            for (int i = 0; i < subjectlist.Count; i++)
            {
                string sub = subjectlist[i];
                sql = "select " + sub + " from [StudentRecord] where studentcode ='" + user + "';";
                tbl = dt.getDataByQuery(sql);
                Double d = 0;
                string num = "";
                foreach (DataRow dr in tbl.Rows)
                {
                    num = dr[0].ToString();

                }
                if (num.Contains("Not start")|| num.Contains("Learning"))
                {
                    check2 = 0;
                    break;
                }
                else 
                {
                    d = Convert.ToDouble(num.Replace(".", ","));
                    if (d < 5)
                    {
                        check2 = 0;
                        break;
                    }
                }
               
            }
            if (check2 == 1)
            {
                // kiem tra xem mon nay da bat dau chua
                int check3 = 1;
                sql = "select " + subject + " from [StudentRecord] where studentcode ='" + user + "';";
                tbl = dt.getDataByQuery(sql);
                foreach(DataRow dr in tbl.Rows)
                {
                    if(!dr[0].ToString().Contains("Not start"))
                    {
                        check3 = 0;
                        break;
                    }
                }
                // kiem tra so mon dang hoc
                if (check3 == 1)
                {
                    int check4 = 1;
                    sql = "  select count(*) from ClassAttendence where StudentCode ='" + user + "';";
                    tbl = dt.getDataByQuery(sql);
                    foreach (DataRow dr in tbl.Rows)
                    {
                        int s = Convert.ToInt32(dr[0].ToString().Replace(" ", ""));
                        if (s >= 6)
                        {
                            check4 = 0;
                            break;
                        }
                    }
                    if (check4 == 1)
                    {
                        sql = " select distinct teachercode from ClassAttendence where subjectcode ='" + Class + "';";
                        tbl = dt.getDataByQuery(sql);
                        string teacher = "";
                        foreach(DataRow dr in tbl.Rows)
                        {
                            teacher = dr[0].ToString().Replace(" ", "");
                        }
                        dt.inserttoclassattendence(Class, teacher, user);
                        dt.updaterecord(user, subject);
                        dt.inserttotresponse(user, "you have signed in class " + Class);
                        Label7.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label7" + "').style.display='none'\",3000)</script>");
                    }
                    else
                    {
                        Label11.Text = "You can only learn 6 subject per term";
                        Label11.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label11" + "').style.display='none'\",4000)</script>");
                    }
                }
                else
                {
                    Label11.Text = "You have learned this subject";
                    Label11.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label11" + "').style.display='none'\",4000)</script>");
                }
            }
            else
            {
                Label11.Text = "you have not learned enough condition subject of this subject";
                Label11.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label11" + "').style.display='none'\",4000)</script>");
            }
        }
        else
        {
            Label11.Text = "Conflict timetable";
            Label11.Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label11" + "').style.display='none'\",4000)</script>");
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string value = TreeView1.SelectedValue.ToString();
        if (value.Equals("r"))
        {
            Response.Redirect("ResponseTeacher.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.ToLower().Equals("c"))
        {
            Response.Redirect("HandleChangeclass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Course"))
        {
            Response.Redirect("HandleAddClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Cancel"))
        {
            Response.Redirect("HandleCancelClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else
        {
            Response.Redirect("Default.aspx" , false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        int x = dt.deletetrequest(DropDownList1.SelectedItem.ToString());
        Response.Redirect("AdminHomepage.aspx?delete=123");
    }
}