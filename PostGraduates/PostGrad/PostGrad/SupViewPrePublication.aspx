<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupViewPrePublication.aspx.cs" Inherits="PostGrad.SupViewPrePublication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        fieldset{
        position:absolute;
        left:34%;
        top:35%;
        width: 24rem;
        height: 10rem;
        border-color:blueviolet;
    }
    fieldset #one{
        font-size:xx-large;
    }
    #form1{
        font-size:x-large;
    }
    #sid{
        position: relative;
    top: 24px;
    }
    #Label1{
        position: relative;
          top: 27px;
    }
    #Button1{
            background-color:blueviolet;
            font-size:x-large;
            left: 28px;
            top: 57px;
            position: relative;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset><legend id="one">Publications</legend>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter Student ID:"></asp:Label>
            <asp:TextBox ID="sid" runat="server"></asp:TextBox>
        </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                </div>

        </div>
    </form>
</body>
</html>
