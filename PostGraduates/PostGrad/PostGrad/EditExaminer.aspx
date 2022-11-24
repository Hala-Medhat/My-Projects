<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditExaminer.aspx.cs" Inherits="PostGrad.EditExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit My Profile</title>
    <style>
         fieldset{
        position:absolute;
        left:33%;
        top:20%;
        width: 25rem;
        height: 20rem;
        border-color:blueviolet;
       
    }
          #button{
       position:relative;
       left:10rem;
       background-color:blueviolet;
       color:white;
            height: 35px;
        }
           form div{
    margin:35px 51px;
    }
            #form1 {
    display:flex;
    
     
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <fieldset><legend>Edit My Profile</legend>
        <div>
       
        <div>
       <label> First Name: </label>
        <asp:TextBox  id="fname" runat="server"></asp:TextBox>
        </div>
         <div>
        <label> Last Name: </label>
        <asp:TextBox  id="lname" type="text" runat="server"></asp:TextBox>
        </div>
         <div>
        <label> Field Of Work: </label>
        <asp:TextBox  id="field" type="text" runat="server"></asp:TextBox>
        </div>
         <asp:Button id="button"  text="Submit" onClick="edit" runat="server"/>
        
        
      
</fieldset>
        </div>
    </form>
</body>
</html>
