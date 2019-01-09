using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
   public string code { get; set; }
   public string pass { get; set; }
    public Account(string a,string b)
    {
        //
        // TODO: Add constructor logic here
        //
        this.code = a;
        this.pass = b;
    }
}