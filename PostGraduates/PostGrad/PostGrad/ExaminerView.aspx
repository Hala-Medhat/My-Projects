

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerView.aspx.cs" Inherits="PostGrad.ExaminerView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Examiner Page</title>
    <style>
        #Button1{
            position:absolute;
            left:88%;
           color:aliceblue;
            background-color:blueviolet;
            
            font-size:medium;
            border-radius: 8px;
    width: 128px;
        }
        #Button1:hover{
            opacity:0.5;
        }
         #Button2{
            position:absolute;
            top:38px;
            left:80%;
           color:aliceblue;
            background-color:blueviolet;
            
            font-size:medium;
            width: 240px;
            border-radius: 8px;

            
        }
         #Button2:hover{
             opacity:0.5;
         }
           #Button3 {
            position: absolute;
            top: 69px;
            left: 81%;
            color: aliceblue;
            background-color: blueviolet;
            
            font-size: medium;
            border-radius: 8px;
            width: 227px;
        }
     #Button3 :hover{
         opacity: 0.5;
     }
         #form1 {
    display:flex;
    
     
    }
         #GridView1{
             border-color:blueviolet;
             border-width:2px;
             border-style:groove;

         }
         #TextBox1{
             width:40%;
    
         }
         #Button4{
             background-color:blueviolet;
             font:medium;
             color:aliceblue;
             border-radius:8px;
             width:100px;
         }
         #Button4:hover{
             opacity:0.5;
         }

 
    </style>
</head>
<body style="height: 104px; width: 1209px">
    <form id="form1" runat="server">
       <div> <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Thesis Title"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="Search"  OnClick="btnSearch_Click" /></div>
        <asp:GridView ID="GridView1" runat="server" Height="188px"></asp:GridView>

        <div>
            <asp:Button ID="Button1" runat="server" OnClick="editmyprofile"  Text="Edit My Profile" />       
              
     
        </div>
        <div>
             <asp:Button ID="Button2" runat="server" OnClick="AddDefense"  Text=" Add grade for a defense" />

        </div>
        <div>
             <asp:Button ID="Button3" runat="server" OnClick="AddComment"  Text=" Add comments for a defense" />

        </div>
    </form>
</body>
</html>
