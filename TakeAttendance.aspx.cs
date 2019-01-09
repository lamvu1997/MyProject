using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite2
{
    public partial class TakeAttendance : System.Web.UI.Page
    {

        List<studentPresent> listAttendanceResult = new List<studentPresent>();
        int slotNo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                Session["slotNumber"] = 1;

                AttendanceObjectProvider aOb = new AttendanceObjectProvider();
                // string cUser = "chilp";// replace by current user in session
                string cUser = (string)Session["CUser"];
                List<AttendanceObject> listSubject = aOb.getAllSubjectsOfTeacher(cUser);

                foreach (AttendanceObject ao in listSubject)
                {
                    DropDownList1.Items.Add(ao.SubjectCode);
                }
                for (int i = 1; i < 11; i++)
                {
                    DropDownList2.Items.Add("Week " + i);
                }


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
                    else if (dOw == 4)
                    {
                        numAdd = (currentWeek * 7) + 2;
                    }
                    else if (dOw == 5)
                    {
                        numAdd = (currentWeek * 7) + 3;
                    }
                    else
                    {
                        numAdd = (currentWeek * 7) + 4;
                    }
                    DateTime NextDate = fromDate.AddDays(numAdd);

                    ListBox1.Items.Add("Slot " + numberOfSlot + " - Thứ " + dOw + "( " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year + ")");
                }
                ShowAttendanceList();
            }

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        public void doWhenIndexChanged()
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
            ListBox1.Items.Clear();
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
                else if (dOw == 4)
                {
                    numAdd = (currentWeek * 7) + 2;
                }
                else if (dOw == 5)
                {
                    numAdd = (currentWeek * 7) + 3;
                }
                else
                {
                    numAdd = (currentWeek * 7) + 4;
                }
                DateTime NextDate = fromDate.AddDays(numAdd);

                ListBox1.Items.Add("Slot " + numberOfSlot + " - Thứ " + dOw + "( " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year + ")");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doWhenIndexChanged();
            int index = 0;
            if (ListBox1.SelectedIndex != -1)
            {
                 index = Convert.ToInt32(ListBox1.SelectedIndex);
            }
            int currentWeek = Convert.ToInt32(DropDownList2.SelectedIndex);

            slotNo = currentWeek * 3 + (index + 1);
            Session["slotNumber"] = slotNo;
            ShowAttendanceList();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            doWhenIndexChanged();

            int index = 0;
            if (ListBox1.SelectedIndex != -1)
            {
                index = Convert.ToInt32(ListBox1.SelectedIndex);
            }

            int currentWeek = Convert.ToInt32(DropDownList2.SelectedIndex);

            slotNo = currentWeek * 3 + (index + 1);
            Session["slotNumber"] = slotNo;
            ShowAttendanceList();
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (ListBox1.SelectedIndex != -1)
            {
                index = Convert.ToInt32(ListBox1.SelectedIndex);
            }

            int currentWeek = Convert.ToInt32(DropDownList2.SelectedIndex);

            slotNo = currentWeek * 3 + (index + 1);
            Session["slotNumber"] = slotNo;
            ShowAttendanceList();
        }

        public void ShowAttendanceList()
        {
            string curretnSubjectCode = DropDownList1.SelectedValue.ToString();
            ListStudentInClassProvider lsic = new ListStudentInClassProvider();
            List<StudentInClass> list = lsic.getStudentListByClassCode(curretnSubjectCode);
            slotNo = (int)Session["slotNumber"];
            foreach (StudentInClass sic in list)
            {
                listAttendanceResult.Add(new studentPresent(sic.StudentCode, null, slotNo));
            }

            Session["atStudent"] = listAttendanceResult;
            GridView1.DataSource = list;
            GridView1.AutoGenerateColumns = false;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Label2.Text = "hello";
        }

        protected void GridView1_RowUpdated1(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void Unnamed_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Label2.Text = rb.Text;
            string cde = rb.GroupName;

            List<studentPresent> lsp = (List<studentPresent>)Session["atStudent"];
            foreach (studentPresent sp in lsp)
            {
                if (sp.StudentCode.Equals(cde))
                {
                    sp.Result = rb.Text;
                    Session["atStudent"] = lsp;
                    break;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<studentPresent> lsp = (List<studentPresent>)Session["atStudent"];
            Boolean isEnough = true;
            foreach (studentPresent sp in lsp)
            {
                if (sp.Result == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(),
                 "alertMessage", @"alert('Please checkout all students before save')", true);
                    isEnough = false;
                    break;
                }
            }
            if (isEnough == true)
            {

                string classCode = (string)Session["drop1"];

                DataAccess access = new DataAccess();
                int count = 0;
                foreach (studentPresent sp in lsp)
                {
                    count = access.takeAttendanceForAClass(sp.Slot, sp.Result, classCode, sp.StudentCode);

                }
                
                  ScriptManager.RegisterClientScriptBlock(this, GetType(),
                 "alertMessage", @"alert('TAKE ATTENDANCE SUCCESSFULLY!')", true);
                Response.Redirect("TeacherSchedule.aspx");

            }

           

        }





    }
}