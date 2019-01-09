<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background:url(../image/front.jpg) no-repeat top;
            background-size:contain;
        }
        .border_login{
            max-width:800px;margin:auto;
            margin-top:15%;
            text-align:center;
        }
        .tableLogin td{
            text-align:left;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
            
            <div class="border_login">
                
                <h2 class="h2b">FPT EDUCATION SYSTEM</h2>
                
                <h4 class="h4b">Student Control Panel</h4>
                
                <h2 class="h2a">Member Login </h2>
                
                <h4 class="h4a">Using your username and password.</h4>
                
            </div>
            

             
                        <div style= "text-align:center;margin-left: 135px; margin-top: 20px">                                                
                            <div>
                            <table class="tableLogin" style="margin-left: 33%;">
                                <tr>
                                    <td style="text-align:left">Code</td>
                                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                    <td> (*) (Ex:SE5000)</td>
                                </tr>
                                <tr>                               
                                    <td style="text-align:left">Password</td>
                                    <td><asp:TextBox ID="TextBox2" runat="server" Height="16px" TextMode="Password"></asp:TextBox></td>
                                    <td> (*)</td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="text-align:left" colspan="2"><asp:Label ID="Label5" runat="server" Font-Bold="True" Text="(*) field is required"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">Login as</td>
                                    <td style="text-align:left" colspan="2"><asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Selected="True">Student</asp:ListItem>
                                <asp:ListItem>Teacher</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                            </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="2"> <asp:Button ID="Button5" runat="server" style="margin-left: 0px" Text="Login" Width="68px" OnClick="Button5_Click" /></td>
                                </tr>
                            </table>
                            </div>
                            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text="Login failed, try again" Visible="False"></asp:Label>
            </div>
                 </form>
</body>
</html>
