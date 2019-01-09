<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookRoom.aspx.cs" Inherits="WebSite2.BookRoom" %>

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
  border-collapse:collapse;
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
.myGridClass .myAltRowClass { background: #fcfcfc repeat-x top; }

/*and finally, we style the pager on the bottom*/
.myGridClass .myPagerClass { background: #424242; }

.myGridClass .myPagerClass table { margin: 5px 0; }

.myGridClass .myPagerClass td {
  border-width: 0;
  padding: 0 6px;
  border-left: solid 1px #666;
  font-weight: bold;
  color: #fff;
  line-height: 12px;
}

.myGridClass .myPagerClass a { color: #666; text-decoration: none; }

.myGridClass .myPagerClass a:hover { color: #000; text-decoration: none; } 
.ddl
        {
            border:2px solid #7d6754;
            border-radius:5px;
            padding:3px;
            -webkit-appearance: none; 
            background-image:url('Images/Arrowhead-Down-01.png');
            background-position:88px;
            background-repeat:no-repeat;
            text-indent: 0.01px;/*In Firefox*/
            text-overflow: '';/*In Firefox*/
        }

.Grid {background-color: #fff; margin: 5px 0 10px 0; border: solid 1px #525252; border-collapse:collapse; font-family:Calibri; color: #474747;}
.Grid td {
      padding: 2px;
      border: solid 1px #c1c1c1; }
.Grid th  {
      padding : 4px 2px;
      color: #fff;
      background: #363670 url(Images/grid-header.png) repeat-x top;
      border-left: solid 1px #525252;
      font-size: 0.9em; }
.Grid .alt {
      background: #fcfcfc url(Images/grid-alt.png) repeat-x top; }
.Grid .pgr {background: #363670 url(Images/grid-pgr.png) repeat-x top; }
.Grid .pgr table { margin: 3px 0; }
.Grid .pgr td { border-width: 0; padding: 0 6px; border-left: solid 1px #666; font-weight: bold; color: #fff; line-height: 12px; }  
.Grid .pgr a { color: Gray; text-decoration: none; }
.Grid .pgr a:hover { color: #000; text-decoration: none; }

    </style>
</head>
<body>
    <form id="form1" runat="server">
     
        <div style="text-align:center">
             
                <h2 class="h2b"> FPT EDUCATION SYSTEM</h2>
                <h4 class="h4b"> Student Control Panel</h4>
               </div> 

                
<div style="display:flex;margin-top:15%">
   <asp:TreeView ID="TreeView1" runat="server" Height="223px" Width="179px">
                    <Nodes>
                        <asp:TreeNode Text="Take Attendance" Value="Take Attendance Of
                            A Class" NavigateUrl="~/TakeAttendance.aspx">
                            
                        </asp:TreeNode>
                        <asp:TreeNode Text="My Schedule" Value="My Schedule" NavigateUrl="~/TeacherSchedule.aspx">
                            
                        </asp:TreeNode>
                        <asp:TreeNode Text="Status of a Room" Value="Transcript" NavigateUrl="~/BookRoom.aspx">
                            
                        </asp:TreeNode>
                        <asp:TreeNode Text="Send request" Value="request" NavigateUrl="~/TeacherRequest.aspx"></asp:TreeNode>
                        <asp:TreeNode Text="Annoucement" Value="Annoucement" NavigateUrl="~/AnnouncementofTeacher.aspx"></asp:TreeNode>
                        <asp:TreeNode NavigateUrl="~/Default.aspx" Text="Sign out" Value="out"></asp:TreeNode>
                        
                    </Nodes>
                </asp:TreeView>

                    <div style="margin-left:15%">
                    
                        <br/>
                        <div><center>
                        
                        <asp:Label ID="Label1" runat="server" Text="Room:" ForeColor="Brown" Font-Size="X-Large"></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="ddl"  Width="111px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                            </center></div>
                        
                        
                    
                                
                         <div>
                        
                        <asp:Label ID="Label4" runat="server" Text="Date :" ForeColor="Brown" Font-Size="X-Large"></asp:Label>                        
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="ddl"  Width="111px" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        </asp:DropDownList>
                           </div>
                         
                        
                        
                        
                        <asp:Label ID="Label2" runat="server" ForeColor="DarkOrange" Font-Size="X-Large"></asp:Label>
                        <asp:GridView ID="GridView1" runat="server" Width="100%" CellSpacing="0"  CssClass="Grid">
                        
                        <Columns>
                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Date" runat="server" Text='<%#Eval("day")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>

                            <Columns>
                <asp:TemplateField HeaderText="Slot" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="Slot" runat="server" Text='<%#Eval("slot")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns>

                        </asp:GridView>
                        
                        
                        


</div>
                </div>

            </div>
     
    </form>
</body>
</html>