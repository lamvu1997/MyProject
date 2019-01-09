<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TakeAttendance.aspx.cs" Inherits="WebSite2.TakeAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        body {
            background: url(../image/front.jpg) no-repeat top;
            background-size: contain;
        }

        .myGridClass {
            width: 150%;
            /*this will be the color of the odd row*/
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
        }

            /*data elements*/
            .myGridClass td {
                padding: 2px;
                border: solid 1px #c1c1c1;
                color: #717171;
            }

            /*header elements*/
            .myGridClass th {
                padding: 4px 2px;
                color: #fff;
                background: #424242;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            /*his will be the color of even row*/
            .myGridClass .myAltRowClass {
                background: #fcfcfc repeat-x top;
            }

            /*and finally, we style the pager on the bottom*/
            .myGridClass .myPagerClass {
                background: #424242;
            }

                .myGridClass .myPagerClass table {
                    margin: 5px 0;
                }

                .myGridClass .myPagerClass td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .myGridClass .myPagerClass a {
                    color: #666;
                    text-decoration: none;
                }

                    .myGridClass .myPagerClass a:hover {
                        color: #000;
                        text-decoration: none;
                    }

        .ddl {
            border: 2px solid #7d6754;
            border-radius: 5px;
            padding: 3px;
            -webkit-appearance: none;
            background-image: url('Images/Arrowhead-Down-01.png');
            background-position: 88px;
            background-repeat: no-repeat;
            text-indent: 0.01px; /*In Firefox*/
            text-overflow: ''; /*In Firefox*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align: center">

            <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
            <h4 class="h4b">Student Control Panel</h4>

        </div>

        <div style="display: flex; margin-top: 15%">
            <div style="width: 15%">
                <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    <Nodes>
                        <asp:TreeNode Text="Take Attendance" Value="Take Attendance Of
                            A Class"
                            NavigateUrl="~/TakeAttendance.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="My Schedule" Value="My Schedule" NavigateUrl="~/TeacherSchedule.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Status of a Room" Value="Transcript" NavigateUrl="~/BookRoom.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Send request" Value="request" NavigateUrl="~/TeacherRequest.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Annoucement" Value="Annoucement" NavigateUrl="~/AnnouncementofTeacher.aspx"></asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/Default.aspx" Text="Sign out" Value="Sign out"></asp:TreeNode>

                    </Nodes>
                </asp:TreeView>
            </div>
            <div style="width: 60%; margin-left: 10%">
                Class:
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="111px">
                    </asp:DropDownList>
                WEEK: 
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="ddl" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="111px">
                        </asp:DropDownList>

                <br />

                <asp:Label runat="server" ID="Label1" Font-Size="XX-Large" ForeColor="DarkOrange">abc</asp:Label>

                <br />

                <asp:Label runat="server" ID="Label2">Slots in week</asp:Label>

                <asp:ListBox runat="server" ID="ListBox1" Width="350px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            </div>
        </div>
        <center><asp:Label runat="server" ID="Label3" Font-Size="X-Large" ForeColor="Blue">Attendance detail</asp:Label></center>

        <asp:GridView ID="GridView1" runat="server" Width="100%" CellSpacing="0" CssClass="myGridClass" OnRowUpdated="GridView1_RowUpdated1">
            <Columns>
                <asp:TemplateField HeaderText="Student Code" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="StudentCode" runat="server" Text='<%#Eval("StudentCode")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField HeaderText="Student Full Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="StudentFullName" runat="server" Text='<%#Eval("StudentFullName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Image runat="server" Width="120" Height="180" ImageUrl="C:\Users\MyPC\Desktop\images.jpg"></asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Attendance" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:RadioButton AutoPostBack="true" Text="Attented" runat="server" GroupName='<%#Eval("StudentCode")%>' OnCheckedChanged="Unnamed_CheckedChanged" />

                        <asp:RadioButton AutoPostBack="true" Text="Absent" runat="server" GroupName='<%#Eval("StudentCode")%>' OnCheckedChanged="Unnamed_CheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>


        <asp:Button runat="server" ID="Button1" Text="Save" OnClick="Button1_Click" />

    </form>
</body>
</html>
