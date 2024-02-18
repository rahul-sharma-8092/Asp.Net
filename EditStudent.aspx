<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditStudent.aspx.cs" Inherits="StudentCore.EditStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        input, textarea {
            display: block;
            padding: 5px;
            margin-bottom: 10px;
            width: 300px
        }

        label {
            font-size: 18px;
            font-weight: 600;
        }

        .container {
            margin: 10px auto;
        }

        a {
            text-align: center;
            text-decoration: none;
            font-size: 20px;
            color: #000000;
            font-weight: 600;
        }

            a:hover {
                text-decoration: underline;
            }
    </style>
    <title>Edit | Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Edit User Details</h3>
        <div class="container">
            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>
                    <label for="Name">Name:</label>
                    <asp:TextBox runat="server" ID="Name" Text='<%# Eval("name") %>' />

                    <label for="Email">Email:</label>
                    <asp:TextBox runat="server" ID="Email" Text='<%# Eval("EmailId") %>' TextMode="Email" Enabled="false" />

                    <label for="Password">Password:</label>
                    <asp:TextBox runat="server" ID="Password" Text='<%# Eval("password") %>' TextMode="Password" />

                    <label for="Mobile">Mobile:</label>
                    <asp:TextBox runat="server" ID="Mobile" Text='<%# Eval("mobile") %>' TextMode="Number" />

                    <label for="Image">Image:</label><br />
                    <asp:Image ImageUrl='<%# "Images/" + (Eval("Image") == null ? "default.jpg": Eval("Image")) %>' ID="prevImage" Width="150px" runat="server" AlternateText="No Image Found" />
                    <asp:FileUpload runat="server" ID="currImage" />

                </ItemTemplate>
            </asp:Repeater>
            <asp:Button ID="BtnEdit" OnClick="BtnEdit_Click" Text="Edit" runat="server" />

            <asp:Label ID="lblErrorMsg" Text="" runat="server" ForeColor="Red" />

            <a href="StudentGrid.aspx">Student List</a>
            <a href="RegistrationStudent.aspx">Student List</a>
        </div>
    </form>
</body>
</html>
