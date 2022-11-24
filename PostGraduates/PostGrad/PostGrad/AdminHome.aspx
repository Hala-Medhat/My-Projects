<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="PostGrad.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home Page</title>
    <style>
    #buttons{
            position:absolute;
            left:1%;
            top:25%;
            display:flex;

        }
    #Button1,#Button2,#Button3, #Button4, #Button5{
            position:relative;
            border-radius:15%;
            height:15rem;
            width:23rem;
            font-size:2em;
            background-color:blueviolet;
            color:white;
            border:none;
            margin:11px 11px;
           

     }
    h1{
            margin-top: 40px;
            text-align: center;
            font-size: 90px;
            text-shadow: 3px 2px blueviolet;
            text-decoration: solid;

     }
        </style>
</head>
<body style="background-image: url('C:\Users\Zizo\Documents\rana GUC\database\16676.jpg' ); background-size:cover; ">
    <form id="form1" runat="server">
        <h1> ADMIN HOME PAGE</h1>
        <div id="buttons">

            <asp:Button ID="Button1" runat="server" OnClick="Theses"  Text="List of Theses" />
             <asp:Button ID="Button2" runat="server" OnClick="Payment" Text="Issue Thesis Payments" />
            <asp:Button ID="Button3" runat="server" OnClick="Installment"  Text="Issue Installment" />
            <asp:Button ID="Button4" runat="server" OnClick="Supervisors" Text="List of Supervisors" />
            <asp:Button ID="Button5" runat="server" OnClick="ThesisExtensions" Text="Update Thesis Extension" />
       
        </div>
    </form>
</body>
</html>
