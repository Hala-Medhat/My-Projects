<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupEvalPR.aspx.cs" Inherits="PostGrad.SupEvalPR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         fieldset{
        position:absolute;
        left:34%;
        top:16%;
        width: 28rem;
        height: 28rem;
        border-color:blueviolet;
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
    #Button2{
            background-color:blueviolet;
            font-size:x-large;
            left: 246px;
        }
    #Button3{
            background-color:blueviolet;
            font-size:x-large;
            left: 28px;
             top: 367px;
        }
        .auto-style2 {
            position: absolute;
            top: 32px;
            left: 10px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 90px;
            left: 10px;
            z-index: 1;
        }
        .auto-style4 {
            position: relative;
            top: 137px;
            left: -4px;
            right: 852px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 202px;
            left: 15px;
            z-index: 1;
        }
        .auto-style6 {
            height: 272px;
        }
        .auto-style7 {
            position: absolute;
            top: 36px;
            left: 107px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 94px;
            left: 238px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 150px;
            left: 270px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 208px;
            left: 140px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 252px;
            left: 34px;
            z-index: 1;
        }
        .auto-style12 {
            position: absolute;
            top: 316px;
            left: 13px;
            z-index: 1;
        }
        .auto-style13 {
            position: absolute;
            top: 366px;
            left: 28px;
            z-index: 1;
            margin-bottom: 0px;
        }
        .auto-style14 {
            position: absolute;
            top: 321px;
            left: 246px;
            z-index: 1;
        }
        .auto-style15 {
            position: absolute;
            top: 462px;
            left: 24px;
            z-index: 1;
        }
        #hr{
            position: relative;
    top: 252px;
    border-color: #f2e5ff;
    border-width: thick;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style6">
            <fieldset><legend id="one">Progress Report Evaluation</legend>
                 <div>
                      <asp:TextBox ID="supid" runat="server" CssClass="auto-style7"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="Your ID:"></asp:Label>
                     </div>
                <div>
                 <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="Thesis Serial Number:"></asp:Label>
            
                    <asp:TextBox ID="tsn" runat="server" CssClass="auto-style8"></asp:TextBox>
            
                     </div>
                <div>
           
                     </div>
                <div>
                     <asp:Label ID="Label5" runat="server" CssClass="auto-style5" Text="Evaluation:"></asp:Label>
                    <asp:DropDownList ID="eval" runat="server" CssClass="auto-style10">
                <asp:ListItem>0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
            </asp:DropDownList>
                    <asp:Label ID="Label4" runat="server" CssClass="auto-style4" Text="Progress Report Number:"></asp:Label>
           
                    <asp:TextBox ID="prn" runat="server" CssClass="auto-style9"></asp:TextBox>
                     </div>
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="auto-style11" OnClick="Button1_Click" Text="Submit" />
                     </div>
                <hr id="hr" />
                <div>
                    <asp:Label ID="Label6" runat="server" CssClass="auto-style12" Text="Thesis Serial Number:"></asp:Label>
            <asp:TextBox ID="tsn2" runat="server" CssClass="auto-style14"></asp:TextBox>
                     </div>
                <div>
                     <asp:Button ID="Button2" runat="server" CssClass="auto-style13" Text="Cancel Thesis" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" CssClass="auto-style15" Text="Add Grade" OnClick="Button3_Click" />
       
                     </div>
            
            
            </div>
                </fieldset>
    </form>
    </form>
</body>
</html>
