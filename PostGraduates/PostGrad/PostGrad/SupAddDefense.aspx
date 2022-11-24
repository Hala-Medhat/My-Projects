<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupAddDefense.aspx.cs" Inherits="PostGrad.SupAddDefense" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        fieldset{
        position:absolute;
        left:35%;
        top:25%;
        width: 28rem;
        height: 21rem;
        border-color:blueviolet;
    }
    fieldset #one{
        font-size: xx-large;
    }
    #form1{
        font-size:x-large;
    }
        .auto-style2 {
            position: relative;
            top: 33px;
            left: 10px;
            right: 764px;
            z-index: 1;
            height: 19px;
        }
        .auto-style3 {
            position: absolute;
            top: 89px;
            left: 28px;
            right: 1088px;
            bottom: 217px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 134px;
            left: 28px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 46px;
            left: 217px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 91px;
            left: 216px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 138px;
            left: 216px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 250px;
            left: 10px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 191px;
            left: 10px;
            z-index: 1;
        }
        #Button1{
            background-color:blueviolet;
            font-size:x-large;
            left: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset><legend id="one"> Add Defense Information</legend>
            <div>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="Serial Number:"></asp:Label>
            <asp:TextBox ID="serialno" runat="server" CssClass="auto-style6"></asp:TextBox>
            </div>
            <div>
         <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Date:"></asp:Label>
        <asp:TextBox ID="date" runat="server" CssClass="auto-style7"></asp:TextBox>
        </div>
            <div>
          <asp:Label ID="Label4" runat="server" CssClass="auto-style4" Text="Location:"></asp:Label>
        <asp:TextBox ID="location" runat="server" CssClass="auto-style8"></asp:TextBox>
        </div>
            <div>
        <asp:CheckBox ID="gucian" runat="server" CssClass="auto-style11" Text="For Gucian Student?" />
                </div>
            <div>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style10" Text="Submit" OnClick="Button1_Click" />
        
            </div>
             </fieldset>
    </form>
</body>
</html>
