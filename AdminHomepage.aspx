<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHomepage.aspx.cs" Inherits="AdminHomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background: url(../image/front.jpg) no-repeat top;
            background-size: contain;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
           
            <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
            <h4 class="h4b">Student Control Panel</h4>
        </div>

        <div style="margin-top: 15%">

            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>
                    <asp:TreeNode Text="Request of teacher" Value="r"></asp:TreeNode>
                    <asp:TreeNode></asp:TreeNode>
                    <asp:TreeNode Text="Request of student" Value="New Node">
                        <asp:TreeNode Text="Change class" Value="C"></asp:TreeNode>
                        <asp:TreeNode Text="Sign in new course" Value="Course"></asp:TreeNode>
                        <asp:TreeNode Text="Cancel class" Value="Cancel"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode></asp:TreeNode>
                    <asp:TreeNode Text="Sign out" Value="Sign out"></asp:TreeNode>
                </Nodes>
            </asp:TreeView>


            <div style="width: 65%; margin-left: 15%">

                <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Text="Request has been deleted" Visible="False"></asp:Label>

            </div>
        </div>
    </form>
</body>
</html>
