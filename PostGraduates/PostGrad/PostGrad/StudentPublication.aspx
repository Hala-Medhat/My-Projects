<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPublication.aspx.cs" Inherits="PostGrad.StudentPublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Publications</title>
    <style>
         fieldset{
             border-color:blueviolet;
             margin: 5rem 0 5rem 23rem;
             max-width: 30rem;
}
        
        .item {
            margin:27px 10px;
        }
        label{
            margin-right:10px;
            
        }
        #Button1{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Fill a Publication</legend>
            <div class="item">
            <label>Publication Title: </label>
            <asp:TextBox ID="title" runat="server"></asp:TextBox>
                </div>
            <div class="item">
            <label>Publication Date:</label>
             <asp:TextBox ID="date" runat="server" placeholder="mm/dd/yyyy" TextMode="DateTimeLocal"></asp:TextBox>
                </div>
            <div class="item">
             <label>Host</label>
            <asp:TextBox ID="host" runat="server"></asp:TextBox>
                </div>
            <div class="item">
             <label>Place:</label>
            <asp:TextBox ID="place" runat="server"></asp:TextBox>
                </div>
            <div class="item">
            <asp:CheckBox ID="accepted" runat="server" Text="Accepted" />
                </div>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            </fieldset>
    </form>
</body>
</html>
