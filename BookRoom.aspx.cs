using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite2
{
    public partial class BookRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoomProvider rProvider = new RoomProvider();
                List<Room> listRoom = rProvider.getNameOfAllRoom();
                foreach (Room r in listRoom)
                {
                    DropDownList1.Items.Add(r.name);
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




                string roomName = DropDownList1.SelectedValue.ToString();
                Label2.Text = "Room '" + roomName + "' is Available at the following slots:";

                AttendanceObjectProvider aoProvider = new AttendanceObjectProvider();
                List<AttendanceObject> lAtt = aoProvider.getTimeTableByRoom(roomName.Trim());

                List<string> totalSlot = new List<string>();
                List<string> realSlot = new List<string>();
                List<string> EndList = new List<string>();
                List<AvailableRoom> aRoom = new List<AvailableRoom>();
                for (int thu = 2; thu < 7; thu++)
                {
                    for (int slot = 1; slot < 7; slot++)
                    {
                        string s = slot + "-" + thu;
                        totalSlot.Add(s);
                    }
                }

                foreach (AttendanceObject att in lAtt)
                {
                    string slot = att.Slot;
                    realSlot.Add(slot.Substring(0, 3));
                    realSlot.Add(slot.Substring(4, 3));
                    realSlot.Add(slot.Substring(8, 3));
                }

                AttendanceObject atttObj = lAtt[0];
                DateTime fromDate = Convert.ToDateTime(atttObj.From);
                int currentWeek = DropDownList2.SelectedIndex;
                EndList = totalSlot.Except(realSlot).ToList();

                foreach (string sl in EndList)
                {
                    int dOw = Convert.ToInt32(sl.Substring(2, 1));
                    string numberOfSlot = sl.Substring(0, 1);
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

                    //ListBox1.Items.Add("Slot " + numberOfSlot + " - Thứ " + dOw + "( " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year + ")");
                    aRoom.Add(new AvailableRoom("T" + dOw + " - " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year, numberOfSlot));

                }
                GridView1.DataSource = aRoom;
                GridView1.AutoGenerateColumns = false;
                GridView1.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            reGetData();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            reGetData();
        }

        public void reGetData()
        {
            RoomProvider rProvider = new RoomProvider();
            List<Room> listRoom = rProvider.getNameOfAllRoom();


            string roomName = DropDownList1.SelectedValue.ToString();
            Label2.Text = "Room '" + roomName + "' is Available at the following slots:";

            AttendanceObjectProvider aoProvider = new AttendanceObjectProvider();
            List<AttendanceObject> lAtt = aoProvider.getTimeTableByRoom(roomName.Trim());

            List<string> totalSlot = new List<string>();
            List<string> realSlot = new List<string>();
            List<string> EndList = new List<string>();
            List<AvailableRoom> aRoom = new List<AvailableRoom>();
            for (int thu = 2; thu < 7; thu++)
            {
                for (int slot = 1; slot < 7; slot++)
                {
                    string s = slot + "-" + thu;
                    totalSlot.Add(s);
                }
            }

            foreach (AttendanceObject att in lAtt)
            {
                string slot = att.Slot;
                realSlot.Add(slot.Substring(0, 3));
                realSlot.Add(slot.Substring(4, 3));
                realSlot.Add(slot.Substring(8, 3));
            }

            AttendanceObject atttObj = lAtt[0];
            DateTime fromDate = Convert.ToDateTime(atttObj.From);
            int currentWeek = DropDownList2.SelectedIndex;
            EndList = totalSlot.Except(realSlot).ToList();

            foreach (string sl in EndList)
            {
                int dOw = Convert.ToInt32(sl.Substring(2, 1));
                string numberOfSlot = sl.Substring(0, 1);
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

                //ListBox1.Items.Add("Slot " + numberOfSlot + " - Thứ " + dOw + "( " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year + ")");
                aRoom.Add(new AvailableRoom("T" + dOw + " - " + NextDate.Day + "/" + NextDate.Month + "/" + NextDate.Year, numberOfSlot));

            }
            GridView1.DataSource = aRoom;
            GridView1.AutoGenerateColumns = false;
            GridView1.DataBind();
        }
    }
}