<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Attendance.aspx.cs" Inherits="Attendance" %>

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

        <div style="display:flex;margin-top:15%">
            <div style="width:15%">
            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Width="175px">
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
                <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">LinkButton</asp:LinkButton>

                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" Visible="False">LinkButton</asp:LinkButton>

                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound" Visible="False">
                </asp:GridView>

                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click" Visible="False">LinkButton</asp:LinkButton>

                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowDataBound="GridView2_RowDataBound" Visible="False">
                </asp:GridView>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound" Visible="False">
                </asp:GridView>
                <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:GridView ID="GridView4" runat="server" AllowPaging="True" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowDataBound="GridView4_RowDataBound" Visible="False">
                </asp:GridView>
                <asp:Label ID="Label4" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:GridView ID="GridView5" runat="server" AllowPaging="True" OnPageIndexChanging="GridView5_PageIndexChanging" OnRowDataBound="GridView5_RowDataBound" Visible="False">
                </asp:GridView>
                <asp:Label ID="Label6" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click" Visible="False">LinkButton</asp:LinkButton>
                <asp:GridView ID="GridView6" runat="server" AllowPaging="True" OnPageIndexChanging="GridView6_PageIndexChanging" OnRowDataBound="GridView6_RowDataBound" Visible="False">
                </asp:GridView>
            </div>
        </div>


    </form>
</body>
</html>
