using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ResponseTeacher : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataAccess dt = new DataAccess();
            string sql = "select * from [RequestOfTeacher]";
            DataTable tbl = dt.getDataByQuery(sql);
            List<RequestOfTeacher> arr = new List<RequestOfTeacher>();
            foreach (DataRow dr in tbl.Rows)
            {
                arr.Add(new RequestOfTeacher(dr[0].ToString(), dr[1].ToString()));
            }
            for (int i = 0; i < arr.Count; i++)
                DropDownList1.Items.Add(arr[i].sender);
            if (arr.Count != 0)
            {
                DropDownList1.SelectedIndex = 0;
            }
            //load data
            if (DropDownList1.Items.Count > 0) { 
                string teacher = DropDownList1.SelectedItem.ToString();
            sql = "select message from RequestOfTeacher where teachercode ='" + teacher + "';";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                TextBox1.Text = dr[0].ToString();
            }
            sql = "select subjectcode from [TimetableOfSubject] where teacher ='" + teacher + "';";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                DropDownList2.Items.Add(dr[0].ToString());
            }
            DropDownList3.Items.Add("Monday");
            DropDownList3.Items.Add("Tuesday");
            DropDownList3.Items.Add("Wednesday");
            DropDownList3.Items.Add("Thursday");
            DropDownList3.Items.Add("Friday");
            DropDownList3.Items.Add("Saturday");

            DropDownList3.SelectedIndex = 0;
            int day = 0;

            day = DropDownList3.SelectedIndex + 2;

            string subclass = DropDownList2.SelectedItem.ToString();
            //lich hoc mac dinh cua lop 
            sql = "select slot from timetableofsubject where subjectcode ='" + subclass + "';";
            tbl = dt.getDataByQuery(sql);
            string[] slot = null;
            foreach (DataRow dr in tbl.Rows)
            {
                slot = dr[0].ToString().Replace(" ", "").Split(',');
            }
            List<int> intarr = new List<int>();
            for (int i = 1; i <= 6; i++)
            {
                intarr.Add(i);
            }

            for (int i = 0; i < slot.Length; i++)
            {
                string x = "-" + day;
                if (slot[i].Contains(x))
                {
                    int busyslot = Convert.ToInt32(slot[i].Replace(" ", "").Substring(0, 1));
                    for (int j = 0; j < intarr.Count; j++)
                    {
                        if (intarr[j] == busyslot)
                        {
                            intarr.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            List<string> lichhoc = new List<string>();
            sql = "select slot from timetableofsubject where teacher ='" + DropDownList1.SelectedItem.ToString() + "';";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                string x = dr[0].ToString().Replace(" ", "");
                string[] x2 = x.Split(',');
                for (int i = 0; i < x2.Length; i++)
                {
                    if (!lichhoc.Contains(x2[i]))
                    {
                        lichhoc.Add(x2[i]);
                    }
                }
            }
            for (int i = 0; i < lichhoc.Count; i++)
            {
                string x = "-" + day;
                if (lichhoc[i].Contains(x))
                {
                    int busyslot = Convert.ToInt32(lichhoc[i].Replace(" ", "").Substring(0, 1));
                    for (int j = 0; j < intarr.Count; j++)
                    {
                        if (intarr[j] == busyslot)
                        {
                            intarr.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < intarr.Count; i++)
            {
                DropDownList4.Items.Add(intarr[i].ToString());
            }
            day = DropDownList3.SelectedIndex + 2;
            string slottime = DropDownList4.SelectedItem.ToString();
            List<string> liststring = new List<string>();
            sql = "SELECT  *  FROM [ProJectCSharp].[dbo].[TimetableOfSubject] where Slot not like '%" + slottime + "-" + day + "%';";
            tbl = dt.getDataByQuery(sql);
            foreach (DataRow dr in tbl.Rows)
            {
                int x = 0;
                for (int i = 0; i < liststring.Count; i++)
                {
                    if (liststring[i].ToLower().Contains(dr[6].ToString().Replace(" ", "").ToLower()) ||
                        dr[6].ToString().Replace(" ", "").ToLower().Contains(liststring[i].ToLower()))
                    {
                        x = 1;
                        break;
                    }
                }
                if (x == 0)
                {
                    liststring.Add(dr[6].ToString().Replace(" ", ""));
                    DropDownList5.Items.Add("'" + dr[6].ToString().Replace(" ", "") + "'");
                }

            }
            if (DropDownList5.Items.Count > 0)
            {
                DropDownList5.SelectedIndex = 0;
            }
        }
    }
}
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
       // DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();
        DropDownList5.Items.Clear();
        DataAccess dt = new DataAccess();
        string teacher = DropDownList1.SelectedItem.ToString();
       string sql = "select message from RequestOfTeacher where teachercode ='" + teacher + "';";
       DataTable tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            TextBox1.Text = dr[0].ToString();
        }
        sql = "select subjectcode from [TimetableOfSubject] where teacher ='" + teacher + "';";
        tbl = dt.getDataByQuery(sql);
        
        foreach (DataRow dr in tbl.Rows)
        {
            DropDownList2.Items.Add(dr[0].ToString());
        }
       
       

        DropDownList3.SelectedIndex = 0;
        int day = 0;

        day = DropDownList3.SelectedIndex + 2;

        string subclass = DropDownList2.SelectedItem.ToString();
        //lich hoc mac dinh cua lop 
        sql = "select slot from timetableofsubject where subjectcode ='" + subclass + "';";
        tbl = dt.getDataByQuery(sql);
        string[] slot = null;
        foreach (DataRow dr in tbl.Rows)
        {
            slot = dr[0].ToString().Replace(" ", "").Split(',');
        }
        List<int> intarr = new List<int>();
        for (int i = 1; i <= 6; i++)
        {
            intarr.Add(i);
        }

        for (int i = 0; i < slot.Length; i++)
        {
            string x = "-" + day;
            if (slot[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(slot[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        List<string> lichhoc = new List<string>();
        sql = "select slot from timetableofsubject where teacher ='" + DropDownList1.SelectedItem.ToString() + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x = dr[0].ToString().Replace(" ", "");
            string[] x2 = x.Split(',');
            for (int i = 0; i < x2.Length; i++)
            {
                if (!lichhoc.Contains(x2[i]))
                {
                    lichhoc.Add(x2[i]);
                }
            }
        }
        for (int i = 0; i < lichhoc.Count; i++)
        {
            string x = "-" + day;
            if (lichhoc[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(lichhoc[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < intarr.Count; i++)
        {
            DropDownList4.Items.Add(intarr[i].ToString());
        }
        day = DropDownList3.SelectedIndex + 2;
        string slottime = DropDownList4.SelectedItem.ToString();
        List<string> liststring = new List<string>();
        sql = "SELECT  *  FROM [ProJectCSharp].[dbo].[TimetableOfSubject] where Slot not like '%" + slottime + "-" + day + "%';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            int x = 0;
            for (int i = 0; i < liststring.Count; i++)
            {
                if (liststring[i].ToLower().Contains(dr[6].ToString().Replace(" ", "").ToLower()) ||
                    dr[6].ToString().Replace(" ", "").ToLower().Contains(liststring[i].ToLower()))
                {
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {
                liststring.Add(dr[6].ToString().Replace(" ", ""));
                DropDownList5.Items.Add("'" + dr[6].ToString().Replace(" ", "") + "'");
            }

        }
        if (DropDownList5.Items.Count > 0)
        {
            DropDownList5.SelectedIndex = 0;
        }
        DropDownList2.DataBind();
        DropDownList3.DataBind();
        DropDownList4.DataBind();
        DropDownList5.DataBind();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       // DropDownList2.Items.Clear();
       // DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();
        DropDownList5.Items.Clear();
        DataAccess dt = new DataAccess();
        string teacher = DropDownList1.SelectedItem.ToString();
       
       
       // DropDownList3.SelectedIndex = 0;
        int day = 0;

        day = DropDownList3.SelectedIndex + 2;

        string subclass = DropDownList2.SelectedItem.ToString();
        string sql = "select slot from timetableofsubject where subjectcode ='" + subclass + "';";
        DataTable tbl = dt.getDataByQuery(sql);
        string[] slot = null;
        foreach (DataRow dr in tbl.Rows)
        {
            slot = dr[0].ToString().Replace(" ", "").Split(',');
        }
        List<int> intarr = new List<int>();
        for (int i = 1; i <= 6; i++)
        {
            intarr.Add(i);
        }

        for (int i = 0; i < slot.Length; i++)
        {
            string x = "-" + day;
            if (slot[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(slot[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        List<string> lichhoc = new List<string>();
        sql = "select slot from timetableofsubject where teacher ='" + DropDownList1.SelectedItem.ToString() + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x = dr[0].ToString().Replace(" ", "");
            string[] x2 = x.Split(',');
            for (int i = 0; i < x2.Length; i++)
            {
                if (!lichhoc.Contains(x2[i]))
                {
                    lichhoc.Add(x2[i]);
                }
            }
        }
        for (int i = 0; i < lichhoc.Count; i++)
        {
            string x = "-" + day;
            if (lichhoc[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(lichhoc[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < intarr.Count; i++)
        {
            DropDownList4.Items.Add(intarr[i].ToString());
        }
        day = DropDownList3.SelectedIndex + 2;
        string slottime = DropDownList4.SelectedItem.ToString();
        List<string> liststring = new List<string>();
        sql = "SELECT  *  FROM [ProJectCSharp].[dbo].[TimetableOfSubject] where Slot not like '%" + slottime + "-" + day + "%';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            int x = 0;
            for (int i = 0; i < liststring.Count; i++)
            {
                if (liststring[i].ToLower().Contains(dr[6].ToString().Replace(" ", "").ToLower()) ||
                    dr[6].ToString().Replace(" ", "").ToLower().Contains(liststring[i].ToLower()))
                {
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {
                liststring.Add(dr[6].ToString().Replace(" ", ""));
                DropDownList5.Items.Add("'" + dr[6].ToString().Replace(" ", "") + "'");
            }

        }
        if (DropDownList5.Items.Count > 0)
        {
            DropDownList5.SelectedIndex = 0;
        }
      
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DropDownList2.Items.Clear();
       // DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();
        DropDownList5.Items.Clear();
        DataAccess dt = new DataAccess();
        string teacher = DropDownList1.SelectedItem.ToString();
        
        
        int day = 0;

        day = DropDownList3.SelectedIndex + 2;
        string subclass = DropDownList2.SelectedItem.ToString();
        string sql = "select slot from timetableofsubject where subjectcode ='" + subclass + "';";
       DataTable tbl = dt.getDataByQuery(sql);
        string[] slot = null;
        foreach (DataRow dr in tbl.Rows)
        {
            slot = dr[0].ToString().Replace(" ", "").Split(',');
        }
        List<int> intarr = new List<int>();
        for (int i = 1; i <= 6; i++)
        {
            intarr.Add(i);
        }

        for (int i = 0; i < slot.Length; i++)
        {
            string x = "-" + day;
            if (slot[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(slot[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        List<string> lichhoc = new List<string>();
        sql = "select slot from timetableofsubject where teacher ='" + DropDownList1.SelectedItem.ToString() + "';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            string x = dr[0].ToString().Replace(" ", "");
            string[] x2 = x.Split(',');
            for (int i = 0; i < x2.Length; i++)
            {
                if (!lichhoc.Contains(x2[i]))
                {
                    lichhoc.Add(x2[i]);
                }
            }
        }
        for (int i = 0; i < lichhoc.Count; i++)
        {
            string x = "-" + day;
            if (lichhoc[i].Contains(x))
            {
                int busyslot = Convert.ToInt32(lichhoc[i].Replace(" ", "").Substring(0, 1));
                for (int j = 0; j < intarr.Count; j++)
                {
                    if (intarr[j] == busyslot)
                    {
                        intarr.RemoveAt(j);
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < intarr.Count; i++)
        {
            DropDownList4.Items.Add(intarr[i].ToString());
        }
        day = DropDownList3.SelectedIndex + 2;
        string slottime = DropDownList4.SelectedItem.ToString();
        List<string> liststring = new List<string>();
        sql = "SELECT  *  FROM [ProJectCSharp].[dbo].[TimetableOfSubject] where Slot not like '%" + slottime + "-" + day + "%';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            int x = 0;
            for (int i = 0; i < liststring.Count; i++)
            {
                if (liststring[i].ToLower().Contains(dr[6].ToString().Replace(" ", "").ToLower()) ||
                    dr[6].ToString().Replace(" ", "").ToLower().Contains(liststring[i].ToLower()))
                {
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {
                liststring.Add(dr[6].ToString().Replace(" ", ""));
                DropDownList5.Items.Add("'" + dr[6].ToString().Replace(" ", "") + "'");
            }
        }
        if (DropDownList5.Items.Count > 0)
        {
            DropDownList5.SelectedIndex = 0;
        }
    }

    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
       // DropDownList3.Items.Clear();
       // DropDownList4.Items.Clear();
        DropDownList5.Items.Clear();
        DataAccess dt = new DataAccess();
        string teacher = DropDownList1.SelectedItem.ToString();

       
        int day = 0;

        day = DropDownList3.SelectedIndex + 2;
        string subclass = DropDownList2.SelectedItem.ToString();
        string sql = "select slot from timetableofsubject where subjectcode ='" + subclass + "';";
        DataTable tbl = dt.getDataByQuery(sql);
      
        day = DropDownList3.SelectedIndex + 2;
        string slottime = DropDownList4.SelectedItem.ToString();
        List<string> liststring = new List<string>();
        sql = "SELECT  *  FROM [ProJectCSharp].[dbo].[TimetableOfSubject] where Slot not like '%" + slottime + "-" + day + "%';";
        tbl = dt.getDataByQuery(sql);
        foreach (DataRow dr in tbl.Rows)
        {
            int x = 0;
            for (int i = 0; i < liststring.Count; i++)
            {
                if (liststring[i].ToLower().Contains(dr[6].ToString().Replace(" ", "").ToLower())||
                    dr[6].ToString().Replace(" ", "").ToLower().Contains(liststring[i].ToLower()))
                {
                    x = 1;
                    break;
                }
            }
            if (x == 0)
            {
                liststring.Add(dr[6].ToString().Replace(" ", ""));
                DropDownList5.Items.Add("'" + dr[6].ToString().Replace(" ", "") + "'");
            }
        }
        if (DropDownList5.Items.Count > 0)
        {
            DropDownList5.SelectedIndex = 0;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string teacher = DropDownList1.SelectedItem.ToString();
        string Class = DropDownList2.SelectedItem.ToString();
        List<string> receiver = new List<string>();
        receiver.Add(teacher);
        DataAccess dt = new DataAccess();
        string sql = "select studentcode from [ClassAttendence] where subjectcode='" + Class + "';";
        DataTable tbl =dt.getDataByQuery(sql);
        foreach(DataRow dr in tbl.Rows)
        {
            receiver.Add(dr[0].ToString());
        }
        string msg = "You have slot " + DropDownList4.SelectedItem.ToString() + " with "+ Class+" on " + DropDownList3.SelectedItem.ToString() + " at room " + DropDownList5.SelectedItem.ToString();
        for(int i = 0; i < receiver.Count; i++)
        {
            int x = dt.inserttotresponse(receiver[i], msg);
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
}