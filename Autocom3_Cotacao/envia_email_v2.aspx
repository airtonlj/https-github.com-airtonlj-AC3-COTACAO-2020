<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envia_email_v2.aspx.cs" Inherits="Autocom3_Cotacao.envia_email_v2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Cotação OnLine Recuperar Senha</title>

    <link rel="apple-touch-icon" sizes="76x76" href="img/icon_autocom3.png" />
    <link rel="icon" href="img/icon_autocom3.png" sizes="16x16" type="image/png" />

    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous"/>

    <!--Complemento Bootstrap -->
    <link rel="stylesheet" href="https://unpkg.com/@coreui/coreui/dist/css/coreui.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/@coreui/icons@2.0.0-beta.3/css/all.min.css" />

    <link rel="stylesheet" href="https://unpkg.com/@coreui/icons@2.0.0-beta.3/css/free.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/@coreui/icons@2.0.0-beta.3/css/brand.min.css" />
    <link rel="stylesheet" href="https://unpkg.com/@coreui/icons@2.0.0-beta.3/css/flag.min.css" />


    <!-- Font Awesome -->
    <link rel="stylesheet" href="fontawesome-pro/css/fontawesome.min.css" />
    <script defer src="fontawesome-pro/js/all.js"></script>

    <!-- CSS Externo com Estilo de conteúdos criados -->
    <link rel="stylesheet" href="css/style.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.1/js/bootstrap.min.js" integrity="sha384-XEerZL0cuoUbHE4nZReLT7nx9gQrQreJekYhJD9WNWhH8nEW+0c5qq7aIo2Wl30J" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <!-- Topo  -->
            <div class="d-flex bg_roxo fixed-top">
                <div class="mr-auto p-2 ml-3 align-self-center">
                    <a href="#" target="_self">
                        <img src="img/logo.svg" alt="Logo Autocom3" /></a>
                </div>
                <div class="p-2 align-self-center mr-3">
                    <a type="button" href="#" class="botao_topo" data-toggle="tooltip" data-placement="bottom" title="Efetuar Logoff"><i class="fas fa-power-off"></i></a>
                </div>
            </div>
            <!-- FIM - Topo  -->
            <br /><br /><br /><br />
            <div class="container">
                <div id="result" runat="server">
                </div>
            </div>

            <footer class="footer">
                <div class="container-fluid">
                    <div class="row footer_copyright">
                        <div class="col-12 text-white  align-self-center">2020 – Todos os direitos reservados a Autocom3</div>
                    </div>
                </div>
            </footer>
        </div>
    </form>
</body>
</html>
