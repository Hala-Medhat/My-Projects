<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentUpdateProfile.aspx.cs" Inherits="PostGrad.StudentUpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update My Profile</title>
    <style>
         fieldset{
             border-color:blueviolet;
             margin: 5rem 0 5rem 23rem;
             max-width: 30rem;
}
        
        .items {
            margin:27px 10px;
        }
        label{
            margin-right:10px;
            
        }
        #add{
            padding-right:1rem;
        }
           #Button1 , #Button2{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset><legend>Update</legend>
        <div class="items">
           <label>Fist Name</label>
            <asp:TextBox ID="first" runat="server"  ></asp:TextBox>
        </div>
        <div class="items">
           <label>Last Name</label>
            <asp:TextBox ID="last" runat="server"  ></asp:TextBox>
        </div>
        <div class="items">
           <label id="add">Address</label>
            <asp:TextBox ID="address" runat="server"  ></asp:TextBox>
        </div>
        <div class="items">
           <label>Type</label>
            <asp:DropDownList ID="DropDownList1" runat="server" >
                <asp:ListItem>PHD</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>NAN</asp:ListItem>
            </asp:DropDownList>
        </div>
     
        <asp:Button ID="Button1" runat="server" Text="Submit" onClick="Submit"/>
        <asp:Button ID="Button2" runat="server" Text="Close" onClick="Close"/>
            </fieldset>
    </form>
</body>
</html>
