<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentProfile.aspx.cs" Inherits="PostGrad.StudentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Profile</title>
    <style>
        fieldset{
             border-color:blueviolet;
            margin: 3rem 0 5rem 22.5rem;
             max-width: 30rem;
}
        
        .item {
            margin:0px 10px;
            display:flex;
            align-items:center;
        }
        #ID{
            margin-top:0.5rem;
        }
        label{
            margin-right:10px;
            
        }
        span{
            margin-right:10px;
        }
    
        h4{
            padding-right:1rem;
        }
        #ud{
            margin-bottom:1rem;
        }
         #update , #btn, #Button1{
             margin:15px 0 0 1rem;
             background-color:blueviolet;
             color:white;
             height: 35px;
         }
         label + .item{
             margin-bottom:2px;
         }
         .item2{
             position:relative;
         }
         
       
       #Button1{
           height:25px;
       }
      #phone .label {
          max-width:14rem;
          overflow-wrap:break-word;
      }
      .label label{
          margin : 0 2rem;
      }
      #addPhone{
          align-items:baseline;
      }
      #btn{
          height:25px;
      }
      #uid{
          display:flex;
          align-items:baseline;
      }
         
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset><legend>My Profile</legend>
        <div id="ID" class="item" runat="server">
            <h4>ID:</h4>
        </div>
        <div id="fn" runat="server"  class="item">
            <h4>First Name:</h4>
        </div>
        <div id="ln" runat="server"  class="item">
            <h4>Last Name:</h4>
        </div>
        <div id="em" runat="server"  class="item">
            <h4>Email:</h4>
        </div>
        <div id="add" runat="server"  class="item">
             <h4>Address:</h4>
        </div>
        <div id="phone" runat="server"  class="item">
           
             <h4 >Phones:</h4>
            <div class="label" runat="server" id="phones">
           
                </div>
                
            
            </div>
            <div class="item" id="addPhone">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Add Phone Number" OnClick="Button1_Click" />
            </div>
        <div id="Type" runat="server"  class="item">
             <h4>Type:</h4>
        </div>
        <div id="fac" runat="server" class="item">
             <h4>Faculty:</h4>
        </div>
        <div id="gpa" runat="server" class="item">
             <h4 id="ud">GPA:</h4>
        </div>
        <div id="uid" runat="server" class="item">
            <h4 id="underid" runat="server">UnderGraduate_Id:</h4>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             <asp:Button ID="btn" runat="server" Text="Add UnderGraduate_Id" OnClick="btn_Click" />
        </div>
        <asp:Button ID="update" runat="server" Text="Update my profile" onClick="Update"/>
      
            </fieldset>
    </form>
</body>
</html>
