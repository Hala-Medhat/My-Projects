<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IssueThesisPayment.aspx.cs" Inherits="PostGrad.Issue_Thesis_Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue Thesis Payment</title>
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
        <h1> Issue Payment to Thesis </h1>
        <div>
             <fieldset><legend>Issue Payment To Thesis</legend>
        <div class="item">
       <label>Thesis Serial Number: </label>
        <asp:TextBox  id="Thesis" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label>Amount of Payment </label>
        <asp:TextBox  id="Amount" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label>Number of Installments: </label>
        <asp:TextBox  id="NoInstallments" runat="server"></asp:TextBox>
        </div>
        <div class="item">
        <label>Fund Percentage: </label>
        <asp:TextBox  id="FundPercentage" runat="server"></asp:TextBox>
        </div>
         <asp:Button id="button"  text="Submit" onClick="Payment" runat="server"/>
        </fieldset>
            </div>
    </form>
</body>
</html>
