<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupUpdateInfo.aspx.cs" Inherits="PostGrad.SupUpdateInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        fieldset {
            position: absolute;
            left: 36%;
            top: 33%;
            width: 22rem;
            height: 12rem;
            border-color: blueviolet;
        }
        fieldset #one{
        font-size: xx-large;
    }
    #form1{
        font-size:x-large;
    }
    #Button1{
            background-color:blueviolet;
            font-size:x-large;
            left: 28px;
        }
        .auto-style2 {
            position: absolute;
            top: 20px;
            left: 10px;
        }
        .auto-style3 {
            position: absolute;
            top: 51px;
            left: 10px;
        }
        .auto-style4 {
            position: absolute;
            top: 81px;
            left: 10px;
        }
        .auto-style5 {
            position: absolute;
            top: 23px;
            left: 108px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 53px;
            left: 132px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
            top: 82px;
            left: 148px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 125px;
            left: 10px;
        }
        #Button1{
            background-color:blueviolet;
        }
        #one{
            font-size:larger;
        }
    </style>
</head>
<body style="height: 171px">
    <form id="form1" runat="server">
        <fieldset><legend id="one"> Update Your Information</legend>
        <div>
           <br />
            <div>
            <br />
            <asp:Label ID="Label3" runat="server" CssClass="auto-style3" style="z-index: 1" Text="New Name:"></asp:Label>
            <asp:TextBox ID="name" runat="server" CssClass="auto-style6"></asp:TextBox>
            </div>
            <div>
            <br />
            <asp:Label ID="Label4" runat="server" CssClass="auto-style4" style="z-index: 1" Text="New Faculty:"></asp:Label>
             <asp:TextBox ID="faculty" runat="server" CssClass="auto-style7"></asp:TextBox>
            <br />
            </div>
            </div>
            <div>
            <br />
            <asp:Button ID="Button1" runat="server" CssClass="auto-style8" style="z-index: 1" Text="Save" OnClick="Button1_Click" />
            <br />
            <br />
        </div>
            </fieldset>
    </form>
    </form>
</body>
</html>
