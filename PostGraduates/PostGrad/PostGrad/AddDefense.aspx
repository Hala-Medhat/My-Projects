<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDefense.aspx.cs" Inherits="PostGrad.AddDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Grade</title>
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
    margin:28px 51px;
    }
           #TextBox1{
               margin-left:1px;
               width:100%;
           }
            #TextBox2{
               margin-left:1px;
               width:100%;
           }
             #TextBox3{
               margin-left:1px;
               width:100%;
           }
             #button{
                 position:relative;
                 left:10rem;
                 background-color:blueviolet;
                 color:white;
                 height: 35px;
             }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <fieldset><legend> Add grade for a defense</legend>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Thesis Serial Number:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Thesis Serial Number"></asp:TextBox>
        </div>
         <div>
            <asp:Label ID="Label3" runat="server" Text="Defense Date :"></asp:Label>
             </div>
             <asp:TextBox ID="TextBox2" runat="server" TextMode="DateTimeLocal"/>
         <div>
             <asp:Label ID="Label2" runat="server" Text="Grade:"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Grade"></asp:TextBox>
        </div>
             <div>
                 <asp:Button id="button"  text="Submit" onClick="add" runat="server"/>
             </div>
             </fieldset>
    </form>
</body>
</html>
