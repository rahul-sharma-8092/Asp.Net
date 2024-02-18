<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationStudent.aspx.cs" Inherits="StudentCore.RegistrationStudent" %>

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
    <title>Registration | Student</title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>User Registration Form</h3>
        <div class="container">
            <label for="Name">Name:</label>
            <asp:TextBox runat="server" ID="Name" Text="" />

            <label for="Email">Email:</label>
            <asp:TextBox runat="server" ID="Email" Text="" TextMode="Email" />

            <label for="Password">Password:</label>
            <asp:TextBox runat="server" ID="Password" Text="" TextMode="Password" />

            <label for="Mobile">Mobile:</label>
            <asp:TextBox runat="server" ID="Mobile" Text="" TextMode="Number" />

            <label for="Image">Image:</label>
            <asp:FileUpload runat="server" ID="Image" />

            <asp:Button ID="BtnRegister" OnClick="BtnRegister_Click" Text="Register" runat="server" />

            <asp:Label ID="lblErrorMsg" Text="" runat="server" ForeColor="Red"/>

            <a href="StudentGrid.aspx">Student List</a>
        </div>
    </form>
</body>
</html>
