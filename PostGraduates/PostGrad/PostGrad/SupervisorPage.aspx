<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorPage.aspx.cs" Inherits="PostGrad.SupervisorPage" %>
<system.web>  
<sessionState mode="SQLServer" sqlConnectionString="Server=DIVS\SQLEXPRESS;Integrated Security=true"></sessionState>  
<compilation debug="true" targetFramework="4.0" />  
</system.web> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    fieldset{
        position:absolute;
        left:30%;
        top:10%;
        width: 30rem;
        height: 36rem;
        border-color:blueviolet;
       
    }
    
    fieldset #one{
        font-size: xx-large;
    }
    #form1{
        font-size:x-large;
        display:flex;
    }
    #Button1{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            left: 28px;
        }
    #Button2{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            left: 28px;
        }
    #Button3{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            left: 28px;
        }
    #Button4{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            left: 28px;
        }
    #viewpro{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            left: 28px;

        }
    #updateinfo{
            background-color:blueviolet;
            color:white;
            font-size:x-large;
            position:relative;

        }




    form div{
    margin:55px 51px;
    }
    
        </style>
</head>
<body>
    <form id="form1" runat="server">
         <fieldset><legend id="one"> Home Page</legend>
        <div>
            <asp:Button ID="Button1" runat="server" CssClass="auto-style2" OnClick="Button1_Click" Text="Student's Theses" />
          </div>
             <div>
                 <asp:Button ID="Button2" runat="server" CssClass="auto-style4" OnClick="Button2_Click" Text="Publication" />
           </div>
             <div>
             <asp:Button ID="Button4" runat="server" CssClass="auto-style6" OnClick="Button4_Click" Text="Progress Report" />
         </div> 
             <div> <asp:Button ID="Button3" runat="server" CssClass="auto-style5" OnClick="Button3_Click" Text="Defense" />
        </div>
             <div>
                 <asp:Button ID="viewpro" runat="server" Text="View My Profile" OnClick="viewpro_Click" />
                 </div>
             <div>
                 <asp:Button ID="updateinfo" runat="server" Text="Update My Personal Information" Width="358px" OnClick="updateinfo_Click" />
             </div>
             </fieldset>
    </form>
    </form>
</body>
</html>
