<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Addpage.aspx.cs" Inherits="FinalOdevi2.Addpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>     
        .noresize {
           resize:none;     
            }
        .sendbtn{

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table style="align-self:center;margin-top:30px">
                <tr>
            <td colspan="2" style="text-align:center"><h1 style="color:white;font-family:'Monotype Corsiva'">Tarif Ekle</h1></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align:center"><img src="assets/addlogo.png" style="width:100px;height:100px;margin-left:auto;margin-right:auto"/></td>
        </tr>
        <tr>
            <td>Yemek Adı</td>
            <td><asp:TextBox ID="adbox" runat="server" MaxLength="50"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Malzemeler</td>
            <td><asp:TextBox ID="malzemebox" runat="server" MaxLength="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Tarif</td>
            <td><asp:TextBox ID="tarifbox" runat="server" Height="200px" Wrap="False" TextMode="MultiLine" CssClass="noresize" MaxLength="5000"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Yemek Görseli</td>
            <td><asp:FileUpload ID="resim" runat="server" /></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="Button1" runat="server" Text="Gönder" OnClick="Button1_Click"/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
        </tr>
                <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>




    
    
    
</asp:Content>
