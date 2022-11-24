<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupAddDE.aspx.cs" Inherits="PostGrad.SupAddDE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        fieldset{
        position:absolute;
        left:33%;
        top:37%;
        width: 29rem;
        height: 8rem;
        border-color:blueviolet;
       
    }
            fieldset #one {
                font-size: xx-large;
            }
            #Button{
                font-size:x-large;
                background-color:blueviolet;
            }
            #Button1{
                font-size:x-large;
                background-color:blueviolet;
            }
        .auto-style2 {
            position: absolute;
            top: 53px;
            left: 42px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 54px;
            left: 281px;
            z-index: 1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset><legend id="one">Defense</legend>
            <br />
                <div>
            <asp:Button ID="Button" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="Add Defense" />
            </div>
            <div>
             <asp:Button ID="Button1" runat="server" CssClass="auto-style3" Text="Add Examiner" OnClick="Button2_Click1" />
            </div>
            <br />
        </div>
    </form>
</body>
</html>
