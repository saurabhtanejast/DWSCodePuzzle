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
            <p class="lead">
       &nbsp; <asp:TextBox id="inputBox" runat="server" Width="500" required="true"/>
                </p>
            <p  class="lead">
       &nbsp; <asp:Button id="button1" runat="server" Text="Draw a Shape" OnClick="button1Clicked"/>
            </p>
            </div>
        <div class="col-md-4">

            <hr width="650" align="left" color="DeepSkyBlue" />
            <asp:Image
             ID="Image1"
             runat="server"
             />
        </div>
	</form>
    <script src="/Scripts/shapes.js" type="text/javascript"></script>
</body>
</html>
