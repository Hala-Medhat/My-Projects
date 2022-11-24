<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThesisInstallments.aspx.cs" Inherits="PostGrad.ThesisInstallments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thesis Installments</title>
    <style>
     h1{
            font-size:30px;
           text-decoration:underline;
           text-decoration-style:inherit;
            margin-left:1rem;

        }

        .header{
            background-color:blueviolet;
            color:white;
        }
        .mydatagrid
        {
        border: solid 2px black;
        min-width: 70%;
        }
        .rows{
            text-align:center;
            background-color:gainsboro;
        }
        #GridView1{
            margin-left:1rem;
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
        <div>
            <h1>Thesis Installments</h1>
        </div>
        <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                 <HeaderStyle CssClass="header" />
                 <PagerStyle CssClass="pager" />
              </asp:GridView>
    </form>
</body>
</html>
