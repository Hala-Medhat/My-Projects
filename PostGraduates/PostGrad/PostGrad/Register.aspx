<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PostGrad.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        #buttons{
            position:absolute;
            left:15%;
            top:25%;
            display:flex;

        }
        #Button1,#Button2,#Button3{
            position:relative;
            border-radius:5%;
            height:20rem;
            width:15rem;
            font-size:2em;
            background-color:blueviolet;
            color:white;
            border:none;
            margin:0 10px;
           

        }
        #Button4:hover, #Button5:hover, #Button6:hover {
            opacity: 0.9;
        }
        
         #Button4,#Button5,#Button6{
             position:relative;
             bottom:-7rem;
             left:-10.5rem;
             color: black;
            background-color: white;
            border: none;
            height: 40px;
}
         h1{
             margin-top: 30px;
            text-align: center;
            font-size: 40px;
            text-shadow: 1px 0px blueviolet;
            text-decoration: underline;

         }
 

           
         

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Register As</h1>
        
        <div id="buttons"> 
            <div class="button">
            <asp:Button ID="Button1" runat="server" Text="Student" /> 
            <asp:Button ID="Button4" runat="server" Text="Register"  OnClick="Student"/> 

             </div>
            <div class="button">

            <asp:Button ID="Button2" runat="server" Text="Supervisor"   />
            <asp:Button ID="Button5" runat="server" Text="Register"  OnClick="Supervisor"/>
            </div>
            <div class="button">
               
            <asp:Button ID="Button3" runat="server" Text="Examiner" />
            <asp:Button ID="Button6" runat="server" Text="Register"  OnClick="Examiner"/>
            </div>

        </div>
    </form>
</body>
</html>
