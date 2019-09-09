<%@ Page Language="C#" Inherits="ApsNetWebApp.Default"  %>

<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
    <link rel="stylesheet" type="text/css" href="/Contents/bootstrap-lumen.css" media="screen" />
</head>
<body>
	<form id="form1" runat="server">
		<div class="jumbotron">
            <p ></p>
           <h3 class="display-4"><asp:Label ID="Label1" runat="server" Text="Please enter input in below format:"></asp:Label></h3><br />
                <h4 class="lead"><asp:Label ID="Label2" runat="server" Text="Draw a <shape> with a (measurement) of (amount) [and a (measurement) of (amount)]"></asp:Label></h4><br />
       &nbsp; <asp:TextBox id="inputBox" runat="server" Width="500" required="true" CssClass="form-control"/><br />
                
            <p  class="lead">
       &nbsp; <asp:Button id="button1" runat="server" Text="Draw a Shape" OnClick="button1Clicked" Class="btn btn-primary btn-lg"/>
            </p>
            </div>
        <div class="col-md-4">

         
            <asp:Image
             ID="Image1"
             runat="server"
             />
        </div>
        <div class="col-md-4"
        <p>
                <br/>
               <canvas id="canvas" width=100 height=100></canvas>
            
            </p>
            </div>
	</form>
    <script src="/Scripts/shapes.js" type="text/javascript"></script>
</body>
</html>
