<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentThesis.aspx.cs" Inherits="PostGrad.StudentThesis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Theses</title>
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
        .thesis{
            background-color:white;
            box-shadow:0 0 2.0em -1em;
            width: 30%;
            padding-bottom: 1rem;
            border:solid 2px blueviolet;
            padding-left: 1rem;
            padding-top: 1rem;
            margin-left:1rem;
            margin-top:5rem;
        }
        label{
            margin-right: 1rem;
    
            font-weight: bold;
        }
        #progress , #publication{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
             margin:2rem 2rem;
         
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

      
    <div>
        <h1>Theses</h1>
    </div>
     <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                 <HeaderStyle CssClass="header" />
                 <PagerStyle CssClass="pager" />
              </asp:GridView>
        
    <div class="thesis">

        <label>Thesis Serial Number:</label>
        <asp:TextBox ID="Thesis" runat="server" ></asp:TextBox><br />
        <asp:Button ID="progress" runat="server" Text="Progress Reports" OnClick="progress_Click" />
        <asp:Button ID="publication" runat="server" Text="Publications" OnClick="publication_Click" />
    </div>
        
    </form>
</body>
</html>
