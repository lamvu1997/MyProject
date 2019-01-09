using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassAttend
/// </summary>
public class ClassAttend
{
    public string subject { get; set; }
    public string teacher { get; set; }
    public string student { get; set; }
    public List<string> arr;
    public ClassAttend(string a,string b,string c,List<string> arr)
    {
        //
        // TODO: Add constructor logic here
        //
        this.subject = a;
        this.teacher = b;
        this.student = c;
        this.arr = arr;
    }
}