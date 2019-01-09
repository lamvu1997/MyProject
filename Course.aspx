<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Course.aspx.cs" Inherits="Course" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background: url(../image/front.jpg) no-repeat top;
            background-size: contain;
        }
        #GridView1{
            margin-top:15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align:center">

            <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
            <h4 class="h4b">Student Control Panel</h4>
        </div>


        <div style="display:flex;margin-top:15%;">
            <div style="width:15%;">
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>
                    <asp:TreeNode Text="Timetable" Value="Timetable">
                        <asp:TreeNode Text="Timetable" Value="Timetable"></asp:TreeNode>
                        <asp:TreeNode Text="On going class" Value="On going class"></asp:TreeNode>
                        <asp:TreeNode Text="Take attendace" Value="Take attendace"></asp:TreeNode>
                        <asp:TreeNode Text="Course" Value="Course"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="Transcript" Value="Transcript">
                        <asp:TreeNode Text="Semester transcript" Value="Semester transcript"></asp:TreeNode>
                        <asp:TreeNode Text="Transcript" Value="Transcript"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="Register" Value="Register">
                        <asp:TreeNode Text="Sign in new class" Value="Sign in new class"></asp:TreeNode>
                        <asp:TreeNode Text="Change class" Value="Change class"></asp:TreeNode>
                        <asp:TreeNode Text="Cancel class" Value="Cancel class"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="Sign out" Value="Sign out"></asp:TreeNode>

                </Nodes>
            </asp:TreeView>
                </div>
            <div style="width:60%;margin-left:5%">

                <asp:Label ID="Label1" runat="server" Text="Subject"></asp:Label>

                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:Label ID="Label2" runat="server" Text="Class"></asp:Label>

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />




                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>


                <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
                </asp:GridView>



            </div>
        </div>

       

    </form>
</body>
</html>
