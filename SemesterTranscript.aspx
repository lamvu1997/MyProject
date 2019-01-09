<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SemesterTranscript.aspx.cs" Inherits="SemesterTranscript" %>

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
        <div style="text-align:center">
            <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
            <h4 class="h4b">Student Control Panel</h4>
            </div>
            <div style="display:flex;margin-top:15%">
                <div style="width:15%">
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
                <div style="width:60%;margin-left:10%">
                    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" Visible="False">
                    </asp:GridView>
                    <asp:Label ID="Label6" runat="server" Text="Label" ForeColor="#9999FF" Visible="False"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" OnRowDataBound="GridView2_RowDataBound" Visible="False">
                    </asp:GridView>
                    <asp:Label ID="Label7" runat="server" Text="Label" ForeColor="#666633" Visible="False"></asp:Label>

                    <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" OnRowDataBound="GridView3_RowDataBound" Visible="False">
                    </asp:GridView>
                    <asp:Label ID="Label8" runat="server" Text="Label" ForeColor="#666633" Visible="False"></asp:Label>

                    <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>


                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" OnRowDataBound="GridView4_RowDataBound" Visible="False">
                    </asp:GridView>
                    <asp:Label ID="Label9" runat="server" Text="Label" ForeColor="#666633" Visible="False"></asp:Label>

                    <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" OnRowDataBound="GridView5_RowDataBound" Visible="False">
                    </asp:GridView>
                    <asp:Label ID="Label10" runat="server" Text="Label" ForeColor="#666633" Visible="False"></asp:Label>

                    <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="Label" Visible="False"></asp:Label>

                    <asp:GridView ID="GridView6" runat="server" OnRowDataBound="GridView6_RowDataBound" Visible="False">
                    </asp:GridView>

                    <asp:Label ID="Label17" runat="server" ForeColor="#666633" Text="Label" Visible="False"></asp:Label>

                    <asp:Label ID="Label18" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>

    </form>
</body>
</html>
