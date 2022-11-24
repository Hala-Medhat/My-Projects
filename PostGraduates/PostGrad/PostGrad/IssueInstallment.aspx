<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueInstallment.aspx.cs" Inherits="PostGrad.Issue_Installment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Installments to Payments</title>
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
            font-size: 90px;
            text-shadow: 3px 2px blueviolet;
            text-decoration: solid;

     }
        #button1{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1> Issue Installments </h1>
        <div>
             <fieldset><legend>Issue Installments</legend>
        <div class="item">
       <label>Payment Id: </label>
        <asp:TextBox  id="payId" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label>Installment Start Date: </label>
        <asp:TextBox  id="startdate" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
        </div>
          <asp:Button id="button1"  text="Submit" onClick="Installments" runat="server"/>
        </fieldset>
            </div>
    </form>
</body>
</html>
