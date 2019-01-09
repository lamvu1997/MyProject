<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoOfTeacher.aspx.cs" Inherits="InfoOfTeacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <style>
        .h4a { 
   position: absolute; 
   top:146px; 
   left: 445px; 
   width: 42%;
            height: 23px;
            margin-bottom: 19px;
        }
.h4b { 
   position: absolute; 
   top:56px; 
   left: 447px; 
   width: 44%;
            height: 25px;
            margin-bottom: 19px;
        }
.h2a { 
   position: absolute; 
   top: 107px; 
   left: 442px; 
   right: 245px;
   height: 27px;
            margin-bottom: 19px;
        }
.h2b { 
   position: absolute; 
   top: 19px; 
   left: 445px; 
   right: 147px;
   height: 26px;
            margin-bottom: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
               <div style="height: 492px; width: 100%;">
                <asp:Image alt="" runat="server" src="C:\Users\MyPC\Downloads\Java-Web-Spr2017\Java-Web-Spr2017\J3.L.P0009(student request)\images\front.jpg" style="margin-left: 0px;" Height="169px" Width="100%" />
                <h2 class="h2b">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FPT EDUCATION SYSTEM</h2>
                <h4 class="h4b">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Student Control Panel</h4>
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;<div style="width: 184px; height: 266px">
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
                    <div style="width: 829px; height: 214px; margin-left: 250px; margin-top: -250px">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Teacher ID"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text="Label" BorderColor="Black"></asp:Label>
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Full name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                        <br />
                        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    </form>
</body>
</html>
