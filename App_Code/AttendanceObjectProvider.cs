using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WebSite2
{
    public class AttendanceObjectProvider
    {
         public List<AttendanceObject> getAllSubjectsOfTeacher(string name)
            {
                DataAccess access = new DataAccess();
                List<AttendanceObject> lcat = new List<AttendanceObject>();
                DataTable dt = access.getAllSubjectsOfTeacher(name);
                foreach (DataRow dr in dt.Rows)
                    lcat.Add(new AttendanceObject(dr["SubjectCode"].ToString(), dr["Slot"].ToString(),dr["DayOfWeek"].ToString(),dr["From"].ToString(),dr["To"].ToString(),dr["Teacher"].ToString(),dr["Room"].ToString()));
                return lcat;
            }


         public List<AttendanceObject> getTimeTableByRoom(string room)
         {
             DataAccess access = new DataAccess();
             List<AttendanceObject> lcat = new List<AttendanceObject>();
             DataTable dt = access.getTimeTableByRoom(room);
             foreach (DataRow dr in dt.Rows)
                 lcat.Add(new AttendanceObject(dr["SubjectCode"].ToString(), dr["Slot"].ToString(), dr["DayOfWeek"].ToString(), dr["From"].ToString(), dr["To"].ToString(), dr["Teacher"].ToString(), dr["Room"].ToString()));
             return lcat;
         }

    }

    public class AttendanceObject
    {
        public string SubjectCode { get; set; }
        public string Slot { get; set; }
        public string DayOfWeek { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Teacher { get; set; }
        public string Room { get; set; }

        public AttendanceObject(string s1, string s2, string s3, string s4, string s5, string s6,string s7)
        {
            SubjectCode = s1;
            Slot = s2;
            DayOfWeek = s3;
            From = s4;
            To = s5;
            Teacher = s6;
            Room = s7;
        }
    }

    public class AvailableRoom
    {
        public string day { get; set; }
        public string slot { get; set; }
        public AvailableRoom(string a, string b)
        {
            day = a;
            slot = b;
        }
    }
}