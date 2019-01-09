using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HandleChangeclass : System.Web.UI.Page
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
                Label12.Visible = true;
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                DropDownList3.Visible = true;
                Button1.Visible = true;
                Button2.Visible = true;
                TextBox1.Visible = true;

                string s = DropDownList1.SelectedItem.ToString();
                sql = "select msg from RequestOfStudent where type='Changeclass' and studentcode='" + s + "';";
                tbl = dt.getDataByQuery(sql);
                string msg = "";
                foreach (DataRow dr in tbl.Rows)
                {
                    msg += dr[0].ToString();
                }
                TextBox1.Text = msg;
                sql = "select subjectcode from [ClassAttendence] where studentcode= '" + s + "'";
                tbl = dt.getDataByQuery(sql);
                foreach (DataRow dr in tbl.Rows)
                {
                    DropDownList2.Items.Add(dr[0].ToString());
                }
                if (DropDownList2.Items.Count > 0)
                {
                    DropDownList2.SelectedIndex = 0;
                    string class1 = DropDownList2.SelectedItem.ToString().Replace(" ","");
                    sql = "select distinct subjectcode from [ClassAttendence] where SubjectCode like '%"+class1.Substring(0,6)+"%'";
                    tbl = dt.getDataByQuery(sql);
                    foreach(DataRow dr in tbl.Rows)
                    {
                        if(!dr[0].ToString().Replace(" ", "").Equals(class1))
                        {
                            DropDownList3.Items.Add(dr[0].ToString().Replace(" ", ""));
                        }
                    }
                    if (DropDownList3.Items.Count > 0)
                    {
                        DropDownList3.SelectedIndex = 0;
                    }
                }
            }
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
            Response.Redirect("Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        int x = dt.deletetrequest(DropDownList1.SelectedItem.ToString());
        Response.Redirect("AdminHomepage.aspx?delete=123");
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Label7.Visible = false;
        Label11.Visible = false;
        DataAccess dt = new DataAccess();
        string user = DropDownList1.SelectedItem.ToString();
        string sub1 = DropDownList2.SelectedItem.ToString();
        string sub2 = DropDownList3.SelectedItem.ToString();
        string sql = "select teachercode from [ClassAttendence] where subjectcode ='" + sub2 + "'";
        string teacher = "";
        DataTable tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            teacher = dr[0].ToString();
        }
        List<string> tableofstudent = new List<string>();
        sql = "select slot from ClassAttendence as t1 inner join TimetableOfSubject as t2 on t1.SubjectCode=t2.SubjectCode where t1.studentcode ='" + user + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x2 = dr[0].ToString().Replace(" ", "");
            string[] x1 = x2.Split(',');
            for (int i = 0; i < x1.Length; i++)
            {
                tableofstudent.Add(x1[i].Replace(" ", ""));
            }
        }
        List<string> tableofclass1 = new List<string>();
        sql = "  select slot from TimetableOfSubject where SubjectCode='" + sub1 + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x2 = dr[0].ToString().Replace(" ", "");
            string[] x1 = x2.Split(',');
            for (int i = 0; i < x1.Length; i++)
            {
                tableofclass1.Add(x1[i].Replace(" ", ""));
            }
        }
        for (int i = 0; i < tableofstudent.Count; i++)
        {
            if (tableofstudent[i].Equals(tableofclass1[0])|| tableofstudent[i].Equals(tableofclass1[1])|| tableofstudent[i].Equals(tableofclass1[2]))
            {
                tableofstudent.RemoveAt(i);
            }
        }
        List<string> tableofclass2 = new List<string>();
        sql = "  select slot from TimetableOfSubject where SubjectCode='" + sub2 + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x2 = dr[0].ToString().Replace(" ", "");
            string[] x1 = x2.Split(',');
            for (int i = 0; i < x1.Length; i++)
            {
                tableofclass2.Add(x1[i].Replace(" ", ""));
            }
        }
        int boo = 1;
        for (int i = 0; i < tableofstudent.Count; i++)
        {
            if (tableofstudent[i].Equals(tableofclass2[0]) || tableofstudent[i].Equals(tableofclass2[1]) || tableofstudent[i].Equals(tableofclass2[2]))
            {
                boo = 0;
                break;
            }
        }
        if (boo == 1)
        {
            string s = DropDownList1.SelectedItem.ToString();
            dt.updateClassAttend(user, sub1, sub2, teacher);
            dt.inserttotresponse(user, "You have been from class " + sub1 + " to class " + sub2);
            Label7.Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label7" + "').style.display='none'\",4000)</script>");
            ///////
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            sql = "select subjectcode from [ClassAttendence] where studentcode= '" + s + "'";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                DropDownList2.Items.Add(dr[0].ToString());
            }
            if (DropDownList2.Items.Count > 0)
            {
                DropDownList2.SelectedIndex = 0;
                string class1 = DropDownList2.SelectedItem.ToString().Replace(" ", "");
                sql = "select distinct subjectcode from [ClassAttendence] where SubjectCode like '%" + class1.Substring(0, 6) + "%'";
                tbl = dt.getDataByQuery(sql);
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr[0].ToString().Replace(" ", "").Equals(class1))
                    {
                        DropDownList3.Items.Add(dr[0].ToString().Replace(" ", ""));
                    }
                }
                if (DropDownList3.Items.Count > 0)
                {
                    DropDownList3.SelectedIndex = 0;
                }
            }
        }
        else
        {
            Label11.Text = "Can not change your class because of conflict in timetable";
            Label11.Visible = true;
            ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label11" + "').style.display='none'\",4000)</script>");
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Items.Count > 0)
        {
            // DropDownList1.SelectedIndex = 0;
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            Label8.Visible = true;
            Label9.Visible = true;
            Label10.Visible = true;
            Label12.Visible = true;
            DropDownList1.Visible = true;
            DropDownList2.Visible = true;
            DropDownList3.Visible = true;
            Button1.Visible = true;
            Button2.Visible = true;
            TextBox1.Visible = true;
            DataAccess dt = new DataAccess();
            string s = DropDownList1.SelectedItem.ToString();
            string sql = "select msg from RequestOfStudent where type='Changeclass' and studentcode='" + s + "';";
            DataTable tbl = dt.getDataByQuery(sql);
            string msg = "";
            foreach (DataRow dr in tbl.Rows)
            {
                msg += dr[0].ToString();
            }
            TextBox1.Text = msg;
            sql = "select subjectcode from [ClassAttendence] where studentcode= '" + s + "'";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                DropDownList2.Items.Add(dr[0].ToString());
            }
            if (DropDownList2.Items.Count > 0)
            {
                DropDownList2.SelectedIndex = 0;
                string class1 = DropDownList2.SelectedItem.ToString().Replace(" ", "");
                sql = "select distinct subjectcode from [ClassAttendence] where SubjectCode like '%" + class1.Substring(0, 6) + "%'";
                tbl = dt.getDataByQuery(sql);
                foreach (DataRow dr in tbl.Rows)
                {
                    if (!dr[0].ToString().Replace(" ", "").Equals(class1))
                    {
                        DropDownList3.Items.Add(dr[0].ToString().Replace(" ", ""));
                    }
                }
                if (DropDownList3.Items.Count > 0)
                {
                    DropDownList3.SelectedIndex = 0;
                }
            }
        }
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList3.Items.Clear();
        if (DropDownList2.Items.Count > 0)
        {
            // DropDownList2.SelectedIndex = 0;
            DataAccess dt = new DataAccess();
            string class1 = DropDownList2.SelectedItem.ToString().Replace(" ", "");
           string sql = "select distinct subjectcode from [ClassAttendence] where SubjectCode like '%" + class1.Substring(0, 6) + "%'";
           DataTable tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                if (!dr[0].ToString().Replace(" ", "").Equals(class1))
                {
                    DropDownList3.Items.Add(dr[0].ToString().Replace(" ", ""));
                }
            }
            if (DropDownList3.Items.Count > 0)
            {
                DropDownList3.SelectedIndex = 0;
            }
        }
    }
}