<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentGrid.aspx.cs" Inherits="StudentCore.StudentGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        th, td {
            padding: 10px
        }
        a{
            text-align: center;
            text-decoration: none;
            font-size: 30px;
            color: #000000;
            font-weight: 600;
        }
        a:hover{
            text-decoration: underline;
        }
    </style>
    <title>Lists | Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <a href="RegistrationStudent.aspx">New Student Registration</a>
            <%-- ASP:Repeater --%>
            <table border="1" style="margin: 10px auto; border-collapse: collapse; min-width: 95%;">
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <tr style="background-color: #1032a7; color: #ffffff; letter-spacing: 1px; font-size: 20px">
                            <th>Id</th>
                            <th>Name</th>
                            <th>Email Id</th>
                            <th>Password</th>
                            <th>Mobile</th>
                            <th>Image</th>
                            <th>Action</th>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td style="text-align: center"><%# Eval("Id") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("EmailId") %></td>
                            <td><%# Eval("Password") %></td>
                            <td style="text-align: center"><%# Eval("Mobile") %></td>
                            <td style="text-align: center;">
                                <asp:Image ImageUrl='<%# "Images/" + Eval("Image") %>' ID="dpImage" Width="150px" runat="server" AlternateText="No Image Found"/>

                            </td>
                            <td style="text-align: center;">
                                <asp:Button ID="EditBtn" OnClick="EditBtn_Click" CommandArgument='<%# Eval("Id") %>' Text="Edit" runat="server" />
                                <asp:Button ID="DeleteBtn" OnClick="DeleteBtn_Click" CommandArgument='<%# Eval("Id") %>' Text="Delete" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <tr style="background-color: #F8C8DC;">
                            <td style="text-align: center"><%# Eval("Id") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("EmailId") %></td>
                            <td><%# Eval("Password") %></td>
                            <td style="text-align: center"><%# Eval("Mobile") %></td>
                            <td style="text-align: center;">
                                <asp:Image ImageUrl='<%# "Images/" + (Eval("Image") == null ? "default.jpg": Eval("Image")) %>' ID="dpImage" Width="150px" runat="server" AlternateText="No Image Found"/>
                            </td>

                            <td style="text-align: center;">
                                <asp:Button ID="EditBtn" OnClick="EditBtn_Click" CommandArgument='<%# Eval("Id") %>' Text="Edit" runat="server" />
                                <asp:Button ID="DeleteBtn" OnClick="DeleteBtn_Click" CommandArgument='<%# Eval("Id") %>' Text="Delete" runat="server" />
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </form>
</body>
</html>
