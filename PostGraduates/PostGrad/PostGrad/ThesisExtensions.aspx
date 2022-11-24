<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThesisExtensions.aspx.cs" Inherits="PostGrad.Thesis_Extensions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
       fieldset{
             border-color:blueviolet;
             margin: 5rem 0 5rem 24.5rem;
             max-width: 30rem;
}
        
        .item {
            margin:27px 10px;
        }
        label{
            margin-right:10px;
            
        }
        h1{
            margin-top: 40px;
            text-align: center;
            font-size: 70px;
            text-shadow: 3px 2px blueviolet;
            text-decoration: solid;

     }
        #button{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1> Update The Thesis Number Extension By 1 </h1>
        <div>
             <fieldset><legend>Update Number of Extension</legend>
        <div class="item">
       <label>Thesis Serial Number: </label>
        <asp:TextBox  id="Thesis" runat="server"></asp:TextBox>
        </div>
        
         <asp:Button id="button"  text="Submit" onClick="Extension" runat="server"/>
        </fieldset>
            </div>
    </form>
</body>
</html>
