<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupAddExaminer.aspx.cs" Inherits="PostGrad.SupAddExaminer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        fieldset{
        position:absolute;
        left:35%;
        top:25%;
        width: 28rem;
        height: 23rem;
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
            top: 300px;
        }
        .auto-style2 {
            position: absolute;
            top: 26px;
            left: 11px;
            z-index: 1;
        }
        .auto-style3 {
            position: absolute;
            top: 66px;
            left: 10px;
            z-index: 1;
        }
        .auto-style4 {
            position: absolute;
            top: 106px;
            left: 10px;
            z-index: 1;
        }
        .auto-style5 {
            position: absolute;
            top: 146px;
            left: 10px;
            z-index: 1;
        }
        .auto-style6 {
            position: absolute;
            top: 246px;
            left: 10px;
            z-index: 1;
        }
        .auto-style7 {
            position: absolute;
                top: 31px;
             left: 185px;
            z-index: 1;
        }
        .auto-style8 {
            position: absolute;
            top: 72px;
              left: 160px;
            z-index: 1;
        }
        .auto-style9 {
            position: absolute;
            top: 111px;
            left: 184px;
            z-index: 1;
        }
        .auto-style10 {
            position: absolute;
            top: 152px;
             left: 165px;
            z-index: 1;
        }
        .auto-style11 {
            position: absolute;
            top: 226px;
            left: 10px;
            z-index: 1;
        }
        .pass{
            position: absolute;
          top: 187px;
        }
        .pa{
            
    position: absolute;
    top: 190px;
    left: 135px;

        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <fieldset><legend id="one"> Add Examiner Information</legend>
                 <div>
            <asp:Label ID="Label2" runat="server" CssClass="auto-style2" Text="ThesisSerialNo :"></asp:Label>
            <asp:TextBox ID="tsn" runat="server" CssClass="auto-style7"></asp:TextBox>
                     </div>
                 <div>
            <asp:Label ID="Label3" runat="server" CssClass="auto-style3" Text="DefenseDate :"></asp:Label>
            <asp:TextBox ID="dd" runat="server" CssClass="auto-style8"></asp:TextBox>
                      </div>
                 <div>
            <asp:Label ID="Label4" runat="server" CssClass="auto-style4" Text="ExaminerName :"></asp:Label>
            <asp:TextBox ID="en" runat="server" CssClass="auto-style9"></asp:TextBox>
                      </div>
                 <div>
            <asp:Label ID="Label5" runat="server" CssClass="auto-style5" Text="FieldOfWork :"></asp:Label>
            <asp:TextBox ID="fow" runat="server" CssClass="auto-style10"></asp:TextBox>
                      </div>
                  <div>
             <asp:Label ID="Label1" runat="server" CssClass="pass" Text="Password: "></asp:Label>
              <asp:TextBox ID="p" runat="server" CssClass="pa"></asp:TextBox>
        </div>
                 <div>
            <asp:CheckBox ID="national" runat="server" CssClass="auto-style6" Text="National" />
</div>
                 <div>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style11" Text="Submit" OnClick="Button1_Click" />
        </div>
        </fieldset>
    </form>
    </form>
</body>
</html>
