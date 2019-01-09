using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WebSite2
{
    public class ListStudentInClassProvider
    {
        public List<StudentInClass> getStudentListByClassCode(string code)
        {
            DataAccess access = new DataAccess();
            List<StudentInClass> lcat = new List<StudentInClass>();
            DataTable dt = access.getStudentListByClassCode(code);
            foreach (DataRow dr in dt.Rows)
                lcat.Add(new StudentInClass(dr["StudentCode"].ToString(), dr["StudentFullName"].ToString()));
            return lcat;
        }
    }

    public class StudentInClass
    {
        public string StudentCode { get; set; }
        public string StudentFullName { get; set; }
        public StudentInClass(string a, string b)
        {
            StudentCode = a;
            StudentFullName = b;
        }
    }

    public class studentPresent
    {
        public string StudentCode { get; set; }
        public string Result { get; set; }
        public int Slot { get; set; }
        public studentPresent(string a, string b,int c)
        {
            StudentCode = a;
            Result = b;
            Slot = c;
        }

    }

    public class Schedule
    {
        public string day { get; set; }
        public string slot { get; set; }
        public string room { get; set; }
        public Schedule(string a, string b, string c)
        {
            day = a;
            slot = b;
            room = c;
        }
    }
}