<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProgressReports.aspx.cs" Inherits="PostGrad.StudentProgressReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Progress Reports</title>
    <style>
        fieldset{
             border-color:blueviolet;
            margin: 3rem 0 5rem 1rem;
             max-width: 30rem;
}
        
        .item {
            margin:27px 10px;
        }
        label{
            margin-right:10px;
            
        }
        #area{
            display:flex;
            align-items:baseline;
            flex-direction:row;
        }
        textarea{
            height:1rem;
        }
        #Button1{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
         }
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
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Progress Reports</h1>
        </div>
        
             <asp:GridView ID="GridView1" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                 <HeaderStyle CssClass="header" />
                 <PagerStyle CssClass="pager" />
                 <RowStyle CssClass="rows" />
        </asp:GridView>
        
        <fieldset>
            <legend>Fill a Progress Report</legend>
        <div>
            <div class="item">
            <label>Progress Report Number:</label>
            
            <asp:TextBox ID="prn" runat="server"></asp:TextBox>
            </div>
            <div class="item">
            <label>State:</label>
            <asp:TextBox ID="state" runat="server"></asp:TextBox>
            </div>
            <div class="item" id="area">
             <label>Description:</label>
            <textarea id="descr" cols="20" rows="5" runat="server"></textarea>
            </div>

            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
            </fieldset>
    </form>
</body>
</html>
