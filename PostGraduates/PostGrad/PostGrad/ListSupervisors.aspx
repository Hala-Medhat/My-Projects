<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListSupervisors.aspx.cs" Inherits="PostGrad.List_Supervisors" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SUPERVISORS</title>
</head>

<body>
    <form id="form1" runat="server">
        <h2>All Supervisors In The System</h2>
        <div>
            <asp:GridView runat="server" ID="Gv1" HeaderStyle-BackColor="BlueViolet" BackColor="Gainsboro">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
