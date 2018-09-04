<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication10.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Register.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet"  />
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
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
								
                                       
                                	<form  runat="server">
						
									<div class="form-group">
										<input type="text" name="username" runat="server" id="username1" tabindex="1" class="form-control" placeholder="Username" value=""/>
									</div>
									
									<div class="form-group">
										<input type="password" name="password" runat="server" id="passwords" tabindex="2" class="form-control" placeholder="Password"/>
									</div>
								
									<div class="form-group">
										<div class="row">
											<div class="col-sm-6 col-sm-offset-3">
                                               
												<input type="submit" runat="server"  tabindex="4" class="form-control btn btn-register" value="Login Now" onserverclick="Logins"/>
											</div>
										</div>
                                       


                                        <div class="form-group">
                                            Dont Have account  <a href ="Register.aspx">signup now</a> 
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
