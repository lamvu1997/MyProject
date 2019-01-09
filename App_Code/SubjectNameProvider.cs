using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace WebSite2
{
    public class SubjectNameProvider
    {
        public SubjectName getNameOfSubjectByCode(string code)
        {
            DataAccess access = new DataAccess();
            List<SubjectName> lcat = new List<SubjectName>();
            DataTable dt = access.getNameOfSubjectByCode(code);
            foreach (DataRow dr in dt.Rows)
                lcat.Add(new SubjectName(dr["SubjectName"].ToString()));
            return lcat[0];
        }
    }

    public class SubjectName
    {
        public string name { get; set; }
        public SubjectName(string a)
        {
            name = a;
        }
    }
}