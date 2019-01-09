using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite2
{
    public partial class TeacherSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                AttendanceObjectProvider aOb = new AttendanceObjectProvider();
                // string cUser = "chilp";// replace by current user in session
                string cUser = (string)Session["CUser"];
                List<AttendanceObject> listSubject = aOb.getAllSubjectsOfTeacher(cUser);

                foreach (AttendanceObject ao in listSubject)
                {
                    DropDownList1.Items.Add(ao.SubjectCode);
                }
                DropDownList2.Items.Add("04/09-10/09");
                DropDownList2.Items.Add("11/09-17/09");
                DropDownList2.Items.Add("18/09-24/09");
                DropDownList2.Items.Add("25/09-01/10");
                DropDownList2.Items.Add("02/10-08/10");
                DropDownList2.Items.Add("09/10-15/10");
                DropDownList2.Items.Add("16/10-22/10");
                DropDownList2.Items.Add("23/10-29/10");
                DropDownList2.Items.Add("30/10-05/11");
                DropDownList2.Items.Add("06/11-12/11");


                string name = DropDownList1.SelectedValue.ToString();
                Session["drop1"] = name;
                string cutName = "";
                if (name.Length > 6)
                {
                    cutName = name.Substring(0, 6);
                }
                SubjectNameProvider snPro = new SubjectNameProvider();
                SubjectName sn = snPro.getNameOfSubjectByCode(cutName);
                Label1.Text = "     Subject Name: " + sn.name;



                AttendanceObject atttObj = listSubject[0];
                for (int i = 0; i < listSubject.Count; i++)
                {
                    if (listSubject[i].SubjectCode.Equals(name))
                    {
                        atttObj = listSubject[i];
                        break;
                    }
                }

                DateTime fromDate = Convert.ToDateTime(atttObj.From);
                int currentWeek = DropDownList2.SelectedIndex;
                string slot = atttObj.Slot;
                List<string> slots = new List<string>();
                slots.Add(slot.Substring(0, 3));
                slots.Add(slot.Substring(4, 3));
                slots.Add(slot.Substring(8, 3));

                List<Schedule> list = new List<Schedule>();

                foreach (string sl in slots)
                {
                    int dOw = Convert.ToInt32(sl.Substring(2, 1));
                    int numberOfSlot = Convert.ToInt32(sl.Substring(0, 1));
                    int numAdd;
                    if (dOw == 2)
                    {
                        numAdd = (currentWeek * 7);
                    }
                    else if (dOw == 3)
                    {
                        numAdd = (currentWeek * 7) + 1;
                    }
                    else if (dOw == 3)
                    {
                        numAdd = (currentWeek * 7) + 2;
                    }
                    else if (dOw == 3)
                    {
                        numAdd = (currentWeek * 7) + 3;
                    }
                    else
                    {
                        numAdd = (currentWeek * 7) + 4;
                    }
                    DateTime NextDate = fromDate.AddDays(numAdd);



                    string s = "T" + dOw + " - " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year;
                    Schedule sche = new Schedule(s, numberOfSlot.ToString(), atttObj.Room);
                    list.Add(sche);
                }
                GridView1.DataSource = list;
                GridView1.AutoGenerateColumns = false;
                GridView1.DataBind();
            }
        }

        public void fillDataPage()
        {
            AttendanceObjectProvider aOb = new AttendanceObjectProvider();
            string cUser = "chilp";// replace by current user in session
            List<AttendanceObject> listSubject = aOb.getAllSubjectsOfTeacher(cUser);

            string name = DropDownList1.SelectedValue.ToString();
            Session["drop1"] = name;
            string cutName = name.Substring(0, 6);
            SubjectNameProvider snPro = new SubjectNameProvider();
            SubjectName sn = snPro.getNameOfSubjectByCode(cutName);
            Label1.Text = "     Subject Name: " + sn.name;



            AttendanceObject atttObj = listSubject[0];
            for (int i = 0; i < listSubject.Count; i++)
            {
                if (listSubject[i].SubjectCode.Equals(name))
                {
                    atttObj = listSubject[i];
                    break;
                }
            }

            DateTime fromDate = Convert.ToDateTime(atttObj.From);
            int currentWeek = DropDownList2.SelectedIndex;
            string slot = atttObj.Slot;
            List<string> slots = new List<string>();
            slots.Add(slot.Substring(0, 3));
            slots.Add(slot.Substring(4, 3));
            slots.Add(slot.Substring(8, 3));

            List<Schedule> list = new List<Schedule>();

            foreach (string sl in slots)
            {
                int dOw = Convert.ToInt32(sl.Substring(2, 1));
                int numberOfSlot = Convert.ToInt32(sl.Substring(0, 1));
                int numAdd;
                if (dOw == 2)
                {
                    numAdd = (currentWeek * 7);
                }
                else if (dOw == 3)
                {
                    numAdd = (currentWeek * 7) + 1;
                }
                else if (dOw == 3)
                {
                    numAdd = (currentWeek * 7) + 2;
                }
                else if (dOw == 3)
                {
                    numAdd = (currentWeek * 7) + 3;
                }
                else
                {
                    numAdd = (currentWeek * 7) + 4;
                }
                DateTime NextDate = fromDate.AddDays(numAdd);



                string s = "T" + dOw + " - " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year;
                Schedule sche = new Schedule(s, numberOfSlot.ToString(), atttObj.Room);
                list.Add(sche);
            }
            GridView1.DataSource = list;
            GridView1.AutoGenerateColumns = false;
            GridView1.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataPage();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDataPage();
        }
    }
}