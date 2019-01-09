using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public string code { get; set; }
    public string name { get; set; }
    public Subject(string code,string name)
    {
        //
        // TODO: Add constructor logic here
        //
        this.code = code;
        this.name = name;
    }
}