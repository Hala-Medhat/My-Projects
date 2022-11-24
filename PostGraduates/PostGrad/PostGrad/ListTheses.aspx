<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListTheses.aspx.cs" Inherits="PostGrad.List_Theses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Theses</title>
</head>
<body>
    <form id="form2" runat="server">
        <h1>ALL THESES IN THE SYSTEM</h1>
        <div style="margin-left:auto;margin-right:auto;">
            <asp:GridView runat="server" ID="Gv2" HeaderStyle-BackColor="BlueViolet" BackColor="Gainsboro">
            </asp:GridView>
            <asp:Label id="mylabel" runat="server">
            </asp:Label>
        </div>
    </form>
</body>
</html>
