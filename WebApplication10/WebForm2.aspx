<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication10.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/json2/20130526/json2.min.js"></script>
    <title></title>
</head>
<body>
    username
    <input type="text"  id="txtName1"/>
   emailaddress
     <input type="text" id="txtName2"/>
    password
     <input type="text" id="txtName3"/>
    confirmpassword
     <input type="text" id="txtName4"/>
    <input type="button" id="btnGet" value="submit"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnGet").click(function () {
                var person = '{username: "' + $("#txtName1").val() + '",EmailAddress:"' + $("#txtName2").val() + '",password:"' + $("#txtName3").val() + '",confirmPassword:"' + $("#txtName4").val() + '"}';
               
                $.ajax({
                    type: "POST",
                    url: "/api/values/Register",
                    data: person,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        alert("Registered successfully: ");
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
