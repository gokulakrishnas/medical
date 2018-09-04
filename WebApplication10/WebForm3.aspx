<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication10.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    username
    <input type="text"  id="txtName1"/>
  
    password
     <input type="text" id="txtName2"/>
   
    <input type="button" id="btnGet" value="submit"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnGet").click(function () {
                var person = '{username: "' + $("#txtName1").val() + '",password:"' + $("#txtName2").val() + '"}';
                console.log(person);
                $.ajax({
                    type: "GET",
                    url: "/api/values/GetName",
                    data: person,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.responseText == "true") {
                            console.log(response.responseText);
                            alert("Login successfully: ");
                        }
                            
                        else {
                           console.log(response.responseText);
                            alert("failed");
                        }
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            });
        });
    </script>
</body>
</html>
