<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PostGrad.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
    fieldset{
        position:absolute;
        left:33%;
        top:20%;
        width: 25rem;
        height: 20rem;
        border-color:blueviolet;
       
    }
    #form1 {
    display:flex;
    
     
    }
    form div{
    margin:55px 51px;
    }
    #button{
       position:relative;
       left:10rem;
       background-color:blueviolet;
       color:white;
            height: 35px;
        }
    #email{
        margin-left:24px;
    }
    #butt{
        position: absolute;
        bottom: 40px;
        left: 80px;
        color:#2b0a4a;
        border:none;
        background-color:transparent;

    }
       #butt:hover {
            color: #5f93f5;
        }
    #DropDownList1{
        display:none;

    }
        </style>

</head>
<body>
    <form id="form1" runat="server">
        <fieldset><legend>Login</legend>
        <div>
       <label> Email: </label>
        <asp:TextBox  id="email" runat="server"></asp:TextBox>
        </div>
         <div>
        <label> Password: </label>
        <asp:TextBox  id="password" type="password" runat="server"></asp:TextBox>
        </div>
         <asp:Button id="button"  text="Submit" onClick="Login" runat="server"/>
         <asp:Button id="butt" runat="server"  Text="I don't have an account i want to register" OnClick="register" />
        
      
</fieldset>
    </form>
</body>
</html>

