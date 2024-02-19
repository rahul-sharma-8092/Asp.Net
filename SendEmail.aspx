<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="StudentCore.SendEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        input, textarea {
            display: block;
            padding: 10px;
            margin: 5px 0 10px;
            width: 100%;
            box-sizing: border-box;
        }
        textarea{
            resize: none;
            height: 150px;
        }

        label {
            font-size: 18px;
            font-weight: 600;
        }

        span {
            font-weight: 700;
            color: red;
        }

        .Container {
            margin: 10px auto;
            width: 30%;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Container">
            <label for="SentTo">Sent To :<span>*</span></label>
            <asp:TextBox ID="SentTo" runat="server" Text="" TextMode="Email" />

            <label for="Subject">Subject :<span>*</span></label>
            <asp:TextBox runat="server" ID="Subject" Text="" />

            <label for="BodyMsg">Body Message :<span>*</span></label>
            <asp:TextBox runat="server" ID="BodyMsg" Text="" TextMode="MultiLine" />

            <label for="Attachment">Attachment :</label>
            <asp:FileUpload ID="Attachment" runat="server" />

            <asp:Button ID="BtnSendEmail" OnClick="BtnSendEmail_Click" Text="Send Email" runat="server" />

            <asp:Label ID="lblMessage" ForeColor="red" Text="" runat="server" />
        </div>
    </form>
</body>
</html>
