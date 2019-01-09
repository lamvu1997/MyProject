<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseTeacher.aspx.cs" Inherits="ResponseTeacher" %>

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
            <asp:Image alt="" runat="server" src="C:\Users\MyPC\Downloads\Java-Web-Spr2017\Java-Web-Spr2017\J3.L.P0009(student request)\images\front.jpg" Style="margin-left: 0px;" Height="169px" Width="100%" />
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
                            <asp:Label ID="Label1" runat="server" Text="Teacher"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Message"></asp:Label></td>

                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="90px" Rows="1" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Class"></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Day"></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Slot"></asp:Label></td>

                        <td><asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Room"></asp:Label></td>

                        <td>
                            <asp:DropDownList ID="DropDownList5" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button3" runat="server" OnClick="Button1_Click" Text="Save" /></td>
                        <td>
                            <asp:Button ID="Button4" runat="server" OnClick="Button2_Click" Text="Delete" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
