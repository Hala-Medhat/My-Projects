<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="PostGrad.StudentRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Register</title>

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
        #Address{
            margin-left:13px;
        }
         #Password{
            margin-left:2px;
        }
         #Email{
             margin-left:26px;
         }
         #Gucian{
             margin-left:127px;
         }
         #DropDownList1{
             margin-left :16px;
                                        
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
        <fieldset><legend>Student Register</legend>
        <div class="item">
       <label> FirstName: </label>
        <asp:TextBox  id="FName" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label> LastName: </label>
        <asp:TextBox  id="LName" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <label> Address: </label>
        <asp:TextBox  id="Address" runat="server"></asp:TextBox>
        </div>
         <div class="item">
        <asp:CheckBox ID="Gucian" runat="server" Text="Gucian" />
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
        <label> Faculty: </label>
         <asp:DropDownList ID="DropDownList1" runat="server" >
             <asp:ListItem>Business Informatics</asp:ListItem>
             <asp:ListItem>Managment</asp:ListItem>
             <asp:ListItem>Pharmacy</asp:ListItem>
             <asp:ListItem>Law</asp:ListItem>
             <asp:ListItem>Biotechnology</asp:ListItem>
             <asp:ListItem>IET</asp:ListItem>
             <asp:ListItem>EMS</asp:ListItem>
             <asp:ListItem>MET</asp:ListItem>
             <asp:ListItem>Applied Arts</asp:ListItem>
            </asp:DropDownList>
       
        </div>
         <asp:Button id="button"  text="Submit" onClick="register" runat="server"/>
        </fieldset>
         
    </form>
</body>
</html>
