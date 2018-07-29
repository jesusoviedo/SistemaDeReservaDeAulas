﻿
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Login</title>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
</head>


<!------ Include the above in your HEAD tag ---------->
<body>
    <div id="login">
        <h3 class="text-center text-white pt-5">Login form</h3>
        <div class="container">
            <div id="login-row" class="row justify-content-center align-items-center">
                <div id="login-column" class="col-md-6">
                    <div id="login-box" class="col-md-12">
                        <form id="login-form" class="form" action="/Home/ingresar" method="post">
                            <h3 class="text-center text-info">Iniciar Sesión</h3>
                            <div class="form-group">
                                <label for="username" class="text-info">Usuario:</label><br>
                                <input type="text" name="txtUser_name" id="txtUser_name" class="form-control" required>
                            </div>
                            <div class="form-group">
                                <label for="password" class="text-info">Contraseña:</label><br>
                                <input type="password" name="txtPassword" id="txtPassword" class="form-control" required>
                            </div>
                            <div class="form-group">
                                <input type="submit" name="submit" class="btn btn-info btn-md" value="Ingresar">
                            </div>
                            

                            <div Class="alert alert-warning" role="alert" @IIf(ViewBag.Mensaje Is Nothing, "hidden", "") >@ViewBag.Mensaje</div>

                            
                            
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>