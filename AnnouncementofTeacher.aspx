<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnnouncementofTeacher.aspx.cs" Inherits="AnnouncementofTeacher" %>

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

        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }

            .Grid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
            }

            .Grid th {
                padding: 4px 2px;
                color: #fff;
                background: #363670 url(Images/grid-header.png) repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

            .Grid .alt {
                background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
            }

            .Grid .pgr {
                background: #363670 url(Images/grid-pgr.png) repeat-x top;
            }

                .Grid .pgr table {
                    margin: 3px 0;
                }

                .Grid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .Grid .pgr a {
                    color: Gray;
                    text-decoration: none;
                }

                    .Grid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="text-align: center">
            <asp:Image ID="Image1" alt="" runat="server" src="C:\Users\MyPC\Downloads\Java-Web-Spr2017\Java-Web-Spr2017\J3.L.P0009(student request)\images\front.jpg" Style="margin-left: 0px;" Height="170px" Width="100%" />
            <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
            <h4 class="h4b">Student Control Panel</h4>


        </div>
        <div style="display: flex; margin-top: 15%">
            <asp:TreeView ID="TreeView1" runat="server">
                <Nodes>
                    <asp:TreeNode Text="Take Attendance" Value="Take Attendance Of
                            A Class"
                        NavigateUrl="~/TakeAttendance.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="My Schedule" Value="My Schedule" NavigateUrl="~/TeacherSchedule.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="Status of a Room" Value="Transcript" NavigateUrl="~/BookRoom.aspx"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/TeacherRequest.aspx" Text="Send request" Value="Send request"></asp:TreeNode>
                    <asp:TreeNode Text="Annoucement" Value="Annoucement" NavigateUrl="~/AnnouncementofTeacher.aspx"></asp:TreeNode>
                    <asp:TreeNode NavigateUrl="~/Default.aspx" Text="Sign out" Value="Sign out"></asp:TreeNode>

                </Nodes>
            </asp:TreeView>

            <div style="width: 65%; margin-left: 15%">



                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" Text="Announcement has been deleted" Visible="False"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Your message box is empty"></asp:Label>
                <br />

                <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" Height="97px" TextMode="MultiLine" Width="244px" Visible="False"></asp:TextBox>

                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete" Visible="False" />

            </div>
        </div>



    </form>

</body>
</html>
