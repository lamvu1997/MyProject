using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHomepage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["delete"]!=null)
            {
                Label1.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "HideLabel", "<script type=\"text/javascript\">setTimeout(\"document.getElementById('" + "Label1" + "').style.display='none'\",4000)</script>");
            }
        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string value = TreeView1.SelectedValue.ToString();
        if (value.Equals("r"))
        {
            Response.Redirect("ResponseTeacher.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.ToLower().Equals("c"))
        {
            Response.Redirect("HandleChangeclass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Course"))
        {
            Response.Redirect("HandleAddClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else if (value.Equals("Cancel"))
        {
            Response.Redirect("HandleCancelClass.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else
        {
            Response.Redirect("Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}