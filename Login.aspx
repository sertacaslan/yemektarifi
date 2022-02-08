<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalOdevi2.Login" %>




<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Giriş Yap</title>
    <style>
        html,
        body {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
        }

        body {
            background:brown;
        }

        .iskelet {
            margin: 1em;
            padding: 1em;
        }

        #form-input {
            margin-top: 4rem;
            text-align: center;
            width: min-content;
            height: min-content;
            margin-left: auto;
            margin-right: auto;
            background-color: rgba(221, 221, 221, 0.6);
            border-radius: 1em;
        }

        #form-ozet {
            background-color: rgba(221, 221, 221, 0.6);
            border-radius: 1em;
            margin-top: 2rem;
            text-align: center;
            width: min-content;
            height: min-content;
            margin-left: auto;
            margin-right: auto;
        }

        .btn {
            padding: 0.5rem;
            border-radius: 0.5em;
            border-color: black;
            margin: 0.1rem;
        }
        .auto-style1 {
            height: 33px;
        }
        .auto-style2 {
            width: 95px;
        }
        .auto-style3 {
            height: 33px;
            width: 95px;
        }
        .auto-style4 {
            height: 35px;
        }
    </style>
</head>
<body>
    <div id="form-input">
        <form  runat="server">
            <table class="iskelet">
                <tr>
                    <td colspan="2">
                        <h3>Giriş Yap</h3>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Nickname*</td>
                    <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style2">Şifre*</td>
                    <td><asp:TextBox ID="TextBox2" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">(*) Doldurmak Zorunludur<br />
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="Giriş Yap" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="Üye ol" OnClick="Button2_Click" /></td>
                </tr>
            </table>
        </form>
    </div>
</body>

</html>

