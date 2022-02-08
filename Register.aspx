<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalOdevi2.WebForm2" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Üyelik Sayfası</title>
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
            margin-top: 2rem;
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
    </style>
</head>
<body>
    <div id="form-input">
        <form  runat="server">
            <table class="iskelet">
                <tr>
                    <td colspan="2">
                        <h3>Kişi Bilgileri</h3>
                        <h3>
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>Ad*</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Soyad*</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>E-mail*</td>
                    <td><asp:TextBox ID="TextBox3" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h3>Üyelik Bilgileri</h3>
                    </td>
                </tr>
                <tr>
                    <td>Nickname*</td>
                    <td><asp:TextBox ID="TextBox4" runat="server" MaxLength="20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Şifre*</td>
                    <td><asp:TextBox ID="TextBox5" runat="server" MaxLength="20" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2">(*) Doldurmak Zorunludur</td>
                </tr>

                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Button ID="Button1" runat="server" Text="Üye Ol" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="Temizle" OnClick="Button2_Click" /></td>
                </tr>
            </table>
        </form>
    </div>
</body>

</html>





