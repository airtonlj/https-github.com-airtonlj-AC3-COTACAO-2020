<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default_b.aspx.cs" Inherits="Autocom3_Cotacao.default_b" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Cotação OnLine</title>
    
    <meta name="viewport" content="width=device-width, initial-scale=1" />
   
    <link rel="apple-touch-icon" sizes="76x76" href="login_assets/images/icons/icon_autocom3.png" />

    <link rel="icon" href="login_assets/images/icons/icon_autocom3.png" sizes="16x16" type="image/png" />

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous"/>
    
    <link rel="stylesheet" type="text/css" href="login_assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css" />
   
    <link rel="stylesheet" type="text/css" href="login_assets/fonts/Linearicons-Free-v1.0.0/icon-font.min.css" />
   
    <link rel="stylesheet" type="text/css" href="login_assets/vendor/animate/animate.css" />
  
    <link rel="stylesheet" type="text/css" href="login_assets/vendor/css-hamburgers/hamburgers.min.css" />
   
    <link rel="stylesheet" type="text/css" href="login_assets/vendor/animsition/css/animsition.min.css" />
   
    <link rel="stylesheet" type="text/css" href="login_assets/vendor/select2/select2.min.css" />
  
    <link rel="stylesheet" type="text/css" href="login_assets/vendor/daterangepicker/daterangepicker.css" />
  
    <link rel="stylesheet" type="text/css" href="login_assets/css/util.css" />

    <link rel="stylesheet" type="text/css" href="login_assets/css/main.css" />
  
    <link href="https://fonts.googleapis.com/css?family=Titillium Web:600&display=swap" rel="stylesheet" />
  
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
        <div id="principal">
            <asp:ScriptManager ID="gerente" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="panellogin" runat="server">
                <ContentTemplate>
                    <div class="limiter">
                <div class="container-login100">
                    <div class="wrap-login100">
                        <div class="login100-form validate-form">
                            <span class="login100-form-title p-b-43">Cotação Online
                            </span>

                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="aviso_a" ControlToValidate="txtemail" ErrorMessage="Endereço de e-mail inválido!"></asp:RegularExpressionValidator>
                            <div class="wrap-input100 validate-input">
                                <asp:TextBox ID="txtemail" name="email" CssClass="input100" runat="server"></asp:TextBox>
                                <span class="focus-input100"></span>
                                <span class="label-input100">Email de Acesso</span>
                            </div>


                            <div class="wrap-input100 validate-input" data-validate="Informe a senha.">
                                <asp:TextBox ID="txtsenha" name="pass" TextMode="Password" CssClass="input100" runat="server"></asp:TextBox>
                                <span class="focus-input100"></span>
                                <span class="label-input100">Senha de Acesso</span>
                            </div>

                            <div class="flex-sb-m w-full p-t-3 p-b-32 m-l-8">
                                <div>
                                    <asp:LinkButton ID="lnkrecuperar" CssClass="txt1" runat="server" OnClick="lnkrecuperar_Click">Esqueceu sua senha?</asp:LinkButton>
                                </div>
                            </div>


                            <div class="container-login100-form-btn">
                                <asp:LinkButton ID="btnLogin" CssClass="login100-form-btn" runat="server" OnClick="btnLogin_Click">Login</asp:LinkButton>
                            </div>
                            <br />
                            <br />
                            <div class="login100-form-social flex-c-m">
                                <img src="login_assets/images/logo_autocom3.png" width="150" />
                            </div>

                        </div>
                        <div class="login100-more" style="background-image: url('login_assets/images/bg_cotacao.jpg');">
                        </div>
                    </div>
                </div>
            </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>

            <div id="esqueci" class="modal fade">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Recuperar login</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel ID="uppRecuperar" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">

                                    <h6>Podemos ajudar.</h6>
                                    <br />
                                    <p>Receba por e-mail suas informações de login.</p>
                                    <p>Informe abaixo o e-mail cadastrado</p>
                                    <br />
                                    <div class="input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text" id="basic-addon1">@</span>
                                        </div>
                                        <asp:TextBox runat="server" ID="emailrecuperar" placeholder="E-Mail:" CssClass="form-control" requerid></asp:TextBox>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btRecuperar" runat="server" CssClass="btn btn-warning" Text="Enviar" OnClick="btRecuperar_Click"></asp:Button>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btRecuperar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="alerta">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Aviso</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="alert alert-default" role="alert">
                                <h4>Informe e-mail e senha.</h4>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fa fa-times fa-lg"></i>&nbsp;Fechar</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>



        </div>


        <!--===============================================================================================-->
        <script src="login_assets/vendor/jquery/jquery-3.2.1.min.js"></script>
        <!--===============================================================================================-->
        <script src="login_assets/vendor/animsition/js/animsition.min.js"></script>
        <!--===============================================================================================-->
        <script src="login_assets/vendor/bootstrap/js/popper.js"></script>
        <script src="login_assets/vendor/bootstrap/js/bootstrap.min.js"></script>
        <!--===============================================================================================-->
        <script src="login_assets/vendor/select2/select2.min.js"></script>
        <!--===============================================================================================-->
        <script src="login_assets/js/main.js"></script>

        <script>
            function camposVazios() {
                $('#alerta').modal('show');
            }

            function senhaEsquecida() {
                $('#esqueci').modal('show');
            }
        </script>

    </form>
</body>
</html>
