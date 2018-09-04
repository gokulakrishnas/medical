<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication10.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Register.css" rel="stylesheet" />
      <link href="Styles/Register.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet"  />
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<%--<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>--%>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>


    <script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.15.0/jquery.validate.min.js"></script>
    <script type="text/javascript">
         $().ready(function() {
            $.validator.addMethod("EMAIL", function(value, element) {
                return this.optional(element) || /^[a-zA-Z0-9._-]+@[a-zA-Z0-9-]+\.[a-zA-Z.]{2,5}$/i.test(value);
             }, "Email Address is invalid: Please enter a valid email address.");
              });
       jQuery(document).ready(function() {
           $("#form1").validate({
                errorClass: 'error',
               rules: {
                    email: "required EMAIL",
                    passwords: {
                        minlength: 5
                    },
                    
                    confirmpassword: {
                        minlength: 5,
                        equalTo: "#passwords"
                    },
                },
                messages: {
                    username1: {
                        required: "Please enter your Username",
                        minlength: "your username must consists of at atleast 2 characters"
                    },
                    passwords: {
                        minlength: "Your password must be at least 5 characters long"
                    },
                    confirmpassword: {
                        minlength: "Your password must be at least 5 characters long",
                        equalTo: "Password do not match"
                    },
                }
            });
        });
    </script>
    
         <style type ="text/css" >  
        .error {
     color: #F00;
      
   }
     
    </style>
</head>
<body style="background-color:cadetblue">
   
   <div class="container">
    	<div class="row">
			<div class="col-md-6 col-md-offset-3">
				<div class="panel panel-login">
					<div class="panel-heading">
						<div class="row">
							
							<div style="margin :auto 0px">
								<h2 style="margin :auto 0px"></h2>
							</div>
						</div>
						<hr>
					</div>
					<div class="panel-body">
						<div class="row">
							<div class="col-lg-12">
								
                                       
                                	<form  runat="server" data-toggle="validator" id="form1">
						
									<div class="form-group">
										<input type="text" name="username" runat="server" id="username1" tabindex="1" class="form-control" placeholder="Username" value="" required="required"/>
									</div>
									<div class="form-group">
										<input type="email" name="email" runat="server" id="email" tabindex="1" class="form-control" placeholder="name@example.com" value="" data-error="Email address is invalid" required="required"/>
									 <label id="error"  style="color:red" runat="server"></label>
                                    </div>
									<div class="form-group">
										<input type="password" name="password" runat="server" id="passwords" class="form-control" placeholder="Password" required="required"  />
									</div>
									<div class="form-group">
										<input type="password" name="confirmpassword" runat="server" id="confirmpassword"  class="form-control" placeholder="Confirm Password"  required="required" />
                                      <%--   <span id='messages'></span>--%>
                                         <div class="help-block with-errors"></div>
									</div>
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
                                               
												<input type="submit" runat="server"  tabindex="4" class="form-control btn btn-register" value="Register Now" onserverclick="Registers"/>
											</div>
										</div>
                                       
									</div>
								</form>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</body>
</html>
