using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HandleCancelClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            string sql = "select studentcode,msg from [RequestOfStudent] where type='Cancelclass'";
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
            if (DropDownList1.Items.Count > 0) {
                DropDownList1.Visible = true;
                DropDownList2.Visible = true;
                Label8.Visible = true;
                Label9.Visible = true;
                Label10.Visible = true;
                Button1.Visible = true;
                Button2.Visible = true;
                TextBox1.Visible = true;
                string s = DropDownList1.SelectedItem.ToString();
            sql = "select msg from RequestOfStudent where type='Cancelclass' and studentcode='" + s + "';";
            tbl = dt.getDataByQuery(sql);
            string msg = "";
            foreach (DataRow dr in tbl.Rows)
            {
                msg += dr[0].ToString();
            }
            TextBox1.Text = msg;
            sql = "select [SubjectCode] from [ClassAttendence] where [StudentCode] ='" + s + "';";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                DropDownList2.Items.Add(dr[0].ToString());
            }
        }
        
    }
}


    protected void Button1_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        string user = DropDownList1.SelectedItem.ToString();
        DropDownList2.Items.Clear();
        string sql = "select [SubjectCode] from [ClassAttendence] where [StudentCode] ='" + user + "';";
        DataTable tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            DropDownList2.Items.Add(dr[0].ToString());
        }
        
        string Class = DropDownList2.SelectedItem.ToString();
        
        dt.deletefromClassAttendence(user, Class);
        dt.inserttotresponse(user, "You have been removed from class " + Class);
        sql = "select [SubjectCode] from [ClassAttendence] where [StudentCode] ='" + user + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            DropDownList2.Items.Add(dr[0].ToString());
        }
        Label7.Visible = true;
        ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label7" + "').style.display='none'\",4000)</script>");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        int x = dt.deletetrequest(DropDownList1.SelectedItem.ToString());
        Response.Redirect("AdminHomepage.aspx?delete=123");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DataAccess dt = new DataAccess();
        string s = DropDownList1.SelectedItem.ToString();
        string sql = "select msg from RequestOfStudent where type='Cancelclass' and studentcode='" + s + "';";
        DataTable tbl = dt.getDataByQuery(sql);
        string msg = "";
        foreach (DataRow dr in tbl.Rows)
        {
            msg += dr[0].ToString();
        }
        TextBox1.Text = msg;
        sql = "select [SubjectCode] from [ClassAttendence] where [StudentCode] ='" + s + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            DropDownList2.Items.Add(dr[0].ToString());
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
}