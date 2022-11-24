<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Installments.aspx.cs" Inherits="PostGrad.Installments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Installments</title>
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
        #GridView1 , #GridView2{
            margin-left:1rem;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Missed Installments</h1>
             <asp:GridView ID="GridView2" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                 <HeaderStyle CssClass="header" />
                 <PagerStyle CssClass="pager" />
              </asp:GridView>
        </div>
        <hr />
         <div>
            <h1>Upcoming Installments</h1>
            <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                 <HeaderStyle CssClass="header" />
                 <PagerStyle CssClass="pager" />
              </asp:GridView>
        </div>
    </form>
</body>
</html>
