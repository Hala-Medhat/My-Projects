<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="PostGrad.StudentHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #Thesis{
           margin:2rem;
        }
        fieldset{
            border-color:blueviolet;
            border-style:outset;
            background: gainsboro;
            width:35rem;
            margin-top: 7rem;
            margin-left: 1rem;
        }
        div{
            display:flex;
            align-items:baseline;
        }
        h4{
            margin:24px;
        }
        #buttons{
          display:inline;
          padding:0 2rem 6rem 0;
          align-items:center



        }
        #nav{
            display:flex;
            flex-direction:row;
            position:sticky;
            top:0;
            background-color:black;
            margin: -5rem -2.5rem 0rem -3em;
            height:5rem;
            padding-bottom:1rem;
        }
      
       
        
        h3{
            margin-right: 30rem;
            margin-left: 4rem;
            font-size: 30px;
            color:blueviolet;
}
        
        #choices{
            position:absolute;
            display:flex;
            flex-direction:column;
            background-color:white;
            box-shadow: 0 0 1.3em -0.5em;
            
                right: 6rem;
               top: 4.3rem;
               display:none;
               
            
        }

        #Button1 , #Button2 , #Button3 ,  #Button5  , #Button8{
            border:none;
            background-color:transparent;
            padding:1.5em;
            color:white;
            

        }
        #Button4 , #Button6, #Button7{
             border:none;
            background-color:transparent;
            padding:1.2em 0;
            width:11rem;
           
        }
        #Button4:hover , #Button6:hover , #Button7:hover{
            color:#5f93f5;
            background-color:white;
            box-shadow:0 0 1.3em -0.5em;
            
        }
       
          #Button1:hover , #Button2:hover , #Button3:hover ,  #Button5:hover 
          {
              color:#5f93f5;
          }
          #Button8{
              color:#5f93f5;
              
          }
          #Button3:hover + #choices {
              display:flex;
              

          }
            #choices:hover {
              display:flex;
              

          }
     
       


    </style>
</head>
<body>
    
    <form id="Thesis" runat="server">
    <div id="nav">
    <h3 id="title">PostGradOffice</h3>
    <div id="buttons">
    <asp:Button ID="Button8" runat="server" Text="Home" />
    <asp:Button ID="Button1" runat="server" Text="My Profile"  OnClick="Button1_Click"/>
    <asp:Button id="Button2" runat="server" Text="Courses" OnClick="Button2_Click" />
    <asp:Button id="Button5" runat="server" Text="Thesis" OnClick="Button5_Click"/>
    <asp:Button id="Button3" runat="server" Text="Payment"/>
    <div id="choices">
    <asp:Button id="Button4" runat="server" Text="Course" OnClick="Button4_Click"/>
    <asp:Button id="Button6" runat="server" Text="Thesis" OnClick="Button6_Click"/>
    <asp:Button id="Button7" runat="server" Text="Installmets" OnClick="Button7_Click"/>
            </div>
    </div>
    </div>
        
    <fieldset>
        <legend>Your Thesis Information</legend>
        <div id="serial" runat="server">
            <h4>Thesis: </h4>
        </div>
        <div id="Title" runat="server">
            <h4>Title: </h4>
        </div>
        <div id="start" runat="server">
            <h4>Start Date: </h4>
        </div>
        <div id="end" runat="server">
            <h4>End Date: </h4>
        </div>
        <div id="no" runat="server">
            <h4>NoOfExtensions: </h4>
        </div>
        </fieldset>
        
    
     </form>

</body>
</html>
