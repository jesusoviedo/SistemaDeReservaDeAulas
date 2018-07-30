
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <title>Inicio de Sesion</title>
    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <link href="~/scripts/css/bootstrap.css" rel="stylesheet" type="text/css" media="all">
    <!-- Custom Theme files -->
    <link href="~/scripts/css/style.css" rel="stylesheet" type="text/css" media="all" />
    <!--js-->
    <script src="~/scripts/js/jquery-2.1.1.min.js"></script>
    <!--icons-css-->
    <link href="~/scripts/css/font-awesome.css" rel="stylesheet">
    <!--Google Fonts-->
    <link href='//fonts.googleapis.com/css?family=Carrois+Gothic' rel='stylesheet' type='text/css'>
    <link href='//fonts.googleapis.com/css?family=Work+Sans:400,500,600' rel='stylesheet' type='text/css'>
    <!--static chart-->
</head>
<body>
    <div class="login-page">
        <div class="login-main">
            <div class="login-head">
                <h1>Iniciar Sesion</h1>
            </div>
            <div class="login-block">
                
                <form id="login-form" action="/Home/ingresar" method="post">
                    
                    <div class="form-group">
                        <input type="text" name="txtUser_name" id="txtUser_name" placeholder="Usuario" required>
                    </div>

                    <div class="form-group">
                        <input type="password" name="txtPassword" id="txtPassword" placeholder="Contraseña" required>
                    </div>                   
                    
                    <div class="forgot-top-grids">
                        <div class="clearfix"> </div>
                    </div>

                    <div class="form-group">
                        <input type="submit" name="submit" class="btn btn-info btn-md" value="Ingresar">
                    </div>

                    <div Class="alert alert-warning" role="alert" @IIf(ViewBag.Mensaje Is Nothing, "hidden", "")>@ViewBag.Mensaje &nbsp;</div>

                </form>               

            </div>

           

        </div>
    </div>

</body>
</html>

