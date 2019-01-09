using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequestOfTeacher
/// </summary>
public class RequestOfTeacher
{
    public string sender { get; set; }
    public string msg { get; set; }
    public RequestOfTeacher(string a,string b)
    {
        //
        // TODO: Add constructor logic here
        //
        this.sender = a;
        this.msg = b;
    }
}