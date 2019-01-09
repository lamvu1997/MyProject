using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        DataAccess dt = new DataAccess();
        List<Account> arr = new List<Account>();
        if (DropDownList1.SelectedIndex == 0)
        {
            DataTable tbl = dt.getAccountForStudent();
            foreach (DataRow dr in tbl.Rows)
            {
                arr.Add(new Account(dr[0].ToString(), dr[1].ToString()));
            }
            string username = TextBox1.Text;
            string pass = TextBox2.Text;
            int x = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (username.Equals(arr[i].code.Replace(" ",""))&&pass.Equals(arr[i].pass.Replace(" ", "")))
                {
                    Session["CUser"] = arr[i].code.Replace(" ", "");
                    Response.Redirect("AnnouncementForStudent.aspx");                 
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {
                
                Label6.Visible = true;
            }
        }
        else if (DropDownList1.SelectedIndex == 1)
        {
            string sql = "select teachercode from [Teacher]";
            DataTable tbl = dt.getDataByQuery(sql);
            List<string> list = new List<string>();
            foreach(DataRow dr in tbl.Rows)
            {
                list.Add(dr[0].ToString());
            }
            
            string username = TextBox1.Text;
            string pass = TextBox2.Text;
            int x = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (username.Equals(list[i].Replace(" ", "")) && pass.Equals(list[i].Replace(" ", "")))
                {
                    Session["CUser"] = list[i].Replace(" ", "");
                    Response.Redirect("TeacherSchedule.aspx");
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {

                Label6.Visible = true;
            }
        }
        else
        {
            string username = TextBox1.Text;
            string pass = TextBox2.Text;
            int x = 0;
           
                if (username.Equals(pass)&&username.Equals("Admin"))
                {
                    Session["CUser"] = "Admin";
                    Response.Redirect("AdminHomepage.aspx");
                    x = 1;
                }
            
            if (x == 0)
            {

                Label6.Visible = true;
            }
        }

    }
}