<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerRegister.aspx.cs" Inherits="PostGrad.ExaminerRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Examiner Register</title>
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
            margin-right:40px;
            
        }
        #National{
            margin-left:127px;
        }
         #Password{
            margin-left:2px;
        }
         #Email{
             margin-left:26px;
         }
         #work{
             margin-left:-21px;
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
        <fieldset><legend>Examiner Register</legend>
        <div class="item">
       <label> FirstName: </label>
        <asp:TextBox  id="FName" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label> LastName: </label>
        <asp:TextBox  id="LName" runat="server"></asp:TextBox>
        </div>
        <div class="item">
        <label> Email: </label>
        <asp:TextBox  id="Email" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label> Password: </label>
        <asp:TextBox  id="Password" type="password" runat="server"></asp:TextBox>
        </div>
        <div class="item">
        <label> FieldOfWork: </label>
         <asp:TextBox  id="work"  runat="server"></asp:TextBox>
        <div class="item">
         <asp:CheckBox ID="National" Text="IsNational" runat="server" />
            </div>
       
        </div>
         <asp:Button id="button"  text="Submit" onClick="register" runat="server"/>
            </fieldset>
         </form>
</body>
</html>
