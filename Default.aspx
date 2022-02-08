<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalOdevi2.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-left:auto;margin-right:auto;"><br />
        
        <div class="warn"><asp:Label ID="Label1" runat="server" Text=""></asp:Label><h1 style="color:white;font-family:'Monotype Corsiva'">Tüm Tarifler</h1></div>
  
        <div id="sonuc" runat="server" style="width:700px;"></div>
        <div id="sayfalama" runat="server" style="width:100px;margin-left:auto;margin-right:auto;">
        </div>
        </div>
</asp:Content>
