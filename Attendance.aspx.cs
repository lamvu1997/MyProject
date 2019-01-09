using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Attendance : System.Web.UI.Page
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
            List<Label> labellist = new List<Label>();
            labellist.Add(Label5);
            labellist.Add(Label1);
            labellist.Add(Label2);
            labellist.Add(Label3);
            labellist.Add(Label4);
            labellist.Add(Label6);
            List<LinkButton> btnlist = new List<LinkButton>();
            btnlist.Add(LinkButton1);
            btnlist.Add(LinkButton2);
            btnlist.Add(LinkButton3);
            btnlist.Add(LinkButton4);
            btnlist.Add(LinkButton5);
            btnlist.Add(LinkButton6);
            btnlist.Add(LinkButton7);
            btnlist.Add(LinkButton8);
            btnlist.Add(LinkButton9);
            btnlist.Add(LinkButton10);
            btnlist.Add(LinkButton11);
            btnlist.Add(LinkButton12);
            List<GridView> gridviewlist = new List<GridView>();
            gridviewlist.Add(GridView1);
            gridviewlist.Add(GridView2);
            gridviewlist.Add(GridView3);
            gridviewlist.Add(GridView4);
            gridviewlist.Add(GridView5);
            gridviewlist.Add(GridView6);
            for (int i = 0; i < subjectlist.Count; i++)
            {
                labellist[i].Visible = true;
                labellist[i].Text = subjectNamelist[i];
                btnlist[i * 2].Visible = true;
                btnlist[i * 2].Text = subjectlistCode[i];
               // btnlist[i * 2].Click += new EventHandler(LinkButton_Click_even);
                btnlist[i * 2+1].Visible = true;
                btnlist[i * 2+1].Text = subjectlist[i];
               // btnlist[i * 2+1].Click += new EventHandler(LinkButton_Click_odd);
                gridviewlist[i].Visible = true;
            }
            Session["btnlist"] = btnlist;
            Session["subjectnamelist"] = subjectNamelist;
            Session["subjectlistcode"] = subjectlistCode;
            for(int j = 0; j < subjectlist.Count; j++)
            {
                DataTable tbl1 = new DataTable();
                tbl1.Columns.Add("Lesson learn");
                tbl1.Columns.Add("Date");
                tbl1.Columns.Add("Slot");
                tbl1.Columns.Add("Watcher");
                tbl1.Columns.Add("Description");
                tbl1.Columns.Add("Study status");
                tbl1.Columns.Add("Note");
                string slot = dt.getTimetableByClass(subjectlist[j]);
                DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[j]);
                teacherList.Add(classattend.teacher);
                string[] time = slot.Split(',');
                for (int i = 0; i < 30; i++)
                {
                    DataRow row = tbl1.NewRow();
                    row[0] = i + 1;
                    if (slot.Contains("-2"))
                    {
                        if (i == 0)
                        {
                            row[1] = "Monday - 04/09/2017 ";
                        }
                        else
                        {
                            if (i % 3 != 0)
                            {
                                date = date.AddDays(2);
                                row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date = date.AddDays(3);
                                row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                    else
                    {
                        //string[] time = slot.Split(',');
                        if (i == 0)
                        {
                            row[1] = "Tuesday - 05/09/2017";
                        }
                        else
                        {
                            if (i % 3 == 1)
                            {

                                if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                                {
                                    date1 = date1.AddDays(2);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                                {
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    date1 = date1.AddDays(5);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                            }
                            else if (i % 3 == 2)
                            {

                                if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                                {
                                    date1 = date1.AddDays(2);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                                {
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    date1 = date1.AddDays(5);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                            }
                            else
                            {
                                if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                                {
                                    date1 = date1.AddDays(2);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                                {
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    date1 = date1.AddDays(5);
                                    row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                                }
                            }
                        }
                    }
                    if (slot.Contains("-2"))
                    {
                        row[2] = slot.Substring(0, 1);
                    }
                    else
                    {
                        string time1 = slot.Substring(0, 1);
                        string time2 = slot.Substring(4, 1);
                        string time3 = slot.Substring(8, 1);
                        if (i % 3 == 0)
                        {
                            row[2] = time1;
                        }
                        else if (i % 3 == 1)
                        {
                            row[2] = time2;
                        }
                        else
                        {
                            row[2] = time3;
                        }
                    }
                    row[3] = classattend.teacher;
                    row[4] = "";
                    row[5] = classattend.arr[i];
                    row[6] = "";
                    tbl1.Rows.Add(row);
                }
                gridviewlist[j].DataSource = tbl1;
                gridviewlist[j].DataBind();
            }
            
           
            Session["teacherlist"] = teacherList;
        }
        

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 0)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[0]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[0]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {
                    //string[] time = slot.Split(',');
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView1.DataSource = tbl1;
            GridView1.DataBind();
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 1)
        {
            GridView2.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[1]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[1]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {

                    date = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView2.DataSource = tbl1;
            GridView2.DataBind();
        }
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 2)
        {
            GridView3.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[2]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[2]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {

                    date = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView3.DataSource = tbl1;
            GridView3.DataBind();
        }
    }

    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 3)
        {
            GridView4.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[3]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[3]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {

                    date = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView4.DataSource = tbl1;
            GridView4.DataBind();
        }
    }

    protected void GridView5_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 4)
        {
            GridView5.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[4]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[4]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {

                    date = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView5.DataSource = tbl1;
            GridView5.DataBind();
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

    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //string user = "SE5000";
        string user = Session["CUser"].ToString();
        DataAccess dt = new DataAccess();
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
        if (subjectlist.Count > 5)
        {
            GridView6.PageIndex = e.NewPageIndex;
            DataTable tbl1 = new DataTable();
            tbl1.Columns.Add("Lesson learn");
            tbl1.Columns.Add("Date");
            tbl1.Columns.Add("Slot");
            tbl1.Columns.Add("Watcher");
            tbl1.Columns.Add("Description");
            tbl1.Columns.Add("Study status");
            tbl1.Columns.Add("Note");
            string slot = dt.getTimetableByClass(subjectlist[5]);
            DateTime date = DateTime.ParseExact("04/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date1 = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ClassAttend classattend = dt.GetClassAttendenceByStudentIDandSubject(user, subjectlist[5]);
            string[] time = slot.Split(',');
            for (int i = 0; i < 30; i++)
            {
                DataRow row = tbl1.NewRow();
                row[0] = i + 1;
                if (slot.Contains("-2"))
                {
                    if (i == 0)
                    {
                        row[1] = "Monday - 04/09/2017 ";
                    }
                    else
                    {
                        if (i % 3 != 0)
                        {
                            date = date.AddDays(2);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            date = date.AddDays(3);
                            row[1] = date.DayOfWeek + " - " + date.ToString("dd/MM/yyyy");
                        }
                    }
                }
                else
                {

                    date = DateTime.ParseExact("05/09/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (i == 0)
                    {
                        row[1] = "Tuesday - 05/09/2017";
                    }
                    else
                    {
                        if (i % 3 == 1)
                        {

                            if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) > Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)) == Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else if (i % 3 == 2)
                        {

                            if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) > Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)) == Convert.ToInt16(time[1].Substring(time[1].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) > Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                date1 = date1.AddDays(2);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else if (Convert.ToInt16(time[0].Substring(time[0].Length - 1, 1)) == Convert.ToInt16(time[2].Substring(time[2].Length - 1, 1)))
                            {
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                date1 = date1.AddDays(5);
                                row[1] = date1.DayOfWeek + " - " + date1.ToString("dd/MM/yyyy");
                            }
                        }
                    }
                }
                if (slot.Contains("-2"))
                {
                    row[2] = slot.Substring(0, 1);
                }
                else
                {
                    string time1 = slot.Substring(0, 1);
                    string time2 = slot.Substring(4, 1);
                    string time3 = slot.Substring(8, 1);
                    if (i % 3 == 0)
                    {
                        row[2] = time1;
                    }
                    else if (i % 3 == 1)
                    {
                        row[2] = time2;
                    }
                    else
                    {
                        row[2] = time3;
                    }
                }
                row[3] = classattend.teacher;
                row[4] = "";
                row[5] = classattend.arr[i];
                row[6] = "";
                tbl1.Rows.Add(row);
            }
            GridView6.DataSource = tbl1;
            GridView6.DataBind();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 0)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[0] + "&code=" + subjectlistcode[0]);
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 1)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[1] + "&code=" + subjectlistcode[1]);
        }
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 2)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[2] + "&code=" + subjectlistcode[2]);
        }
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 3)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[3] + "&code=" + subjectlistcode[3]);
        }
    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 4)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[4] + "&code=" + subjectlistcode[4]);
        }
    }

    protected void LinkButton11_Click(object sender, EventArgs e)
    {
        List<string> subjectnamelist = (List<string>)Session["subjectnamelist"];
        List<string> subjectlistcode = (List<string>)Session["subjectlistcode"];
        if (subjectlistcode.Count > 5)
        {
            Response.Redirect("Course.aspx?name=" + subjectnamelist[5] + "&code=" + subjectlistcode[5]);
        }
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        List<string> teacherList = (List<string>)Session["teacherlist"];
        if(teacherList.Count>0)
        Response.Redirect("InfoOfClass.aspx?class=" + LinkButton2.Text + "&teacher=" + teacherList[0]);
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        List<string> teacherList = (List<string>)Session["teacherlist"];
        if (teacherList.Count > 1)
            Response.Redirect("InfoOfClass.aspx?class=" + LinkButton4.Text + "&teacher=" + teacherList[1]);
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        List<string> teacherList = (List<string>)Session["teacherlist"];
        if (teacherList.Count > 2)
            Response.Redirect("InfoOfClass.aspx?class=" + LinkButton6.Text + "&teacher=" + teacherList[2]);
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        List<string> teacherList = (List<string>)Session["teacherlist"];
        if (teacherList.Count > 3)
            Response.Redirect("InfoOfClass.aspx?class=" + LinkButton8.Text + "&teacher=" + teacherList[3]);
    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        List<string> teacherList = (List<string>)Session["teacherlist"];
        if (teacherList.Count > 4)
            Response.Redirect("InfoOfClass.aspx?class=" + LinkButton10.Text + "&teacher=" + teacherList[4]);
    }

    protected void LinkButton12_Click(object sender, EventArgs e)
    {
        List<string> teacherList = (List<string>)Session["teacherlist"];
        if (teacherList.Count > 5)
            Response.Redirect("InfoOfClass.aspx?class=" + LinkButton12.Text + "&teacher=" + teacherList[5]);
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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if(e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }
            
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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if (e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }

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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if (e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }

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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if (e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }

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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if (e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }

        }
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
            if (e.Row.Cells[5].Text.ToLower().Contains("absent"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#E74C3C");
                e.Row.Cells[5].ForeColor = color;
            }
            else if (e.Row.Cells[5].Text.ToLower().Contains("attend"))
            {
                System.Drawing.Color color = System.Drawing.ColorTranslator.FromHtml("#239B56");
                e.Row.Cells[5].ForeColor = color;
            }

        }
    }
}