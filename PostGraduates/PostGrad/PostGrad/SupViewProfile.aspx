<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupViewProfile.aspx.cs" Inherits="PostGrad.SupViewProfile" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        #GridView1{
            text-align:center;
            margin: auto;
            width:50%
        }
    </style>
<body>
    <form id="form1" runat="server">
         <asp:GridView ID="GridView1" runat="server"><HeaderStyle ForeColor="White" Font-Bold="True"
       BackColor=blueviolet></HeaderStyle></asp:GridView>
    </form>
</body>
</html>
