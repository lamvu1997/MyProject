using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTableOfStudent
/// </summary>
public class TimeTableOfStudent
{
    public string subject { get; set; }
    public string room { get; set; }
    public string slot { get; set; }
    public TimeTableOfStudent(string a,string b,string c)
    {
        //
        // TODO: Add constructor logic here
        //
        this.subject = a;
        this.room = b;
        this.slot = c;
    }
}