<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleCancelClass.aspx.cs" Inherits="HandleCancelClass" %>

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

        <div style="margin-top: 15%; display: flex">

            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <Nodes>
                    <asp:TreeNode Text="Request of teacher" Value="r"></asp:TreeNode>
                    <asp:TreeNode></asp:TreeNode>
                    <asp:TreeNode Text="Request of student" Value="New Node">
                        <asp:TreeNode Text="Change class" Value="c"></asp:TreeNode>
                        <asp:TreeNode Text="Sign in new course" Value="Course"></asp:TreeNode>
                        <asp:TreeNode Text="Cancel class" Value="Cancel"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode></asp:TreeNode>
                    <asp:TreeNode Text="Sign out" Value="Sign out"></asp:TreeNode>
                </Nodes>
            </asp:TreeView>


            <div style="width: 65%; margin-left: 10%">
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label7" runat="server" ForeColor="Lime" Text="Saved change successfully" Visible="False"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Student" Visible="False"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Message" Visible="False"></asp:Label></td>

                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="61px" TextMode="MultiLine" Visible="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Class" Visible="False"></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Visible="False" /></td>

                        <td>
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete" Visible="False" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
