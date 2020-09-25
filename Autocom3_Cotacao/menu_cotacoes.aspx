<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_cotacoes.aspx.cs" Inherits="Autocom3_Cotacao.menu_cotacoes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Cotação OnLine Menu de Cotações</title>

    <link rel="apple-touch-icon" sizes="76x76" href="img/icon_autocom3.png" />
    <link rel="icon" href="img/icon_autocom3.png" sizes="16x16" type="image/png" />

    <!-- Bootstrap -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.1/css/bootstrap.min.css" integrity="sha384-VCmXjywReHh4PwowAiWNagnWcLhlEJLA5buUprzK8rxFgeH0kww/aWY76TfkUoSX" crossorigin="anonymous" />

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

    <style>
        #gridCotacao {
            margin-left: auto;
            margin-right: auto;
            height: 100px;
        }

        .modal1 {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.9;
            left: 0px;
        }

        .center1 {
            z-index: 1000;
            margin: auto;
            position: absolute;
            top: 0;
            left: 0;
            bottom: 0;
            right: 0;
            padding: 40px;
            text-align: center;
            height: 100px;
            width: 350px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=90);
            opacity: 0.9;
        }

        .hideGridColumn {
            display: none;
        }

        .btn-warning {
            color: White;
        }

            .btn-warning:hover {
                color: White;
            }
    </style>
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
                    <a type="button" href="https://www.autocom3service.com.br/cotacaov7/" class="botao_topo" data-toggle="tooltip" data-placement="bottom" title="Efetuar Logoff"><i class="fas fa-power-off"></i></a>
                </div>
            </div>
            <!-- FIM - Topo  -->

            <!-- Sub Título com o nome da Empresa em uma faixa branca com uma divisória inferior -->
            <sub_header id="sub_header">
            <div class="container align-self-center text-center">
                <div class="row">
                    <div class="col-12 align-self-center ml-3"><span class="texto_empresa cor-do-texto"><%=Session["nome"]%></span></div>
                </div>
            </div>
        </sub_header>

            <!--  Banner com Texto e Imagem em Background  -->
            <div class="banner">
                <div class="container-fluid">
                    <div class="row banner-text">
                        <span class="col-sm-12 mt-5 ml-4">Bem vindo à <b>Cotação Online</b></span>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="container-fluid mt-2">
                    <div class="row">
                        <div class="col-3">
                            <table class="table table-borderless">
                                <tr>
                                    <td style="text-align: center;" class="cor-do-texto"><i class="fad fa-smile-wink fa-3x"></i></td>
                                    <td style="text-align: center;" class="cor-do-texto"><i class="fad fa-surprise fa-3x"></i></td>
                                    <td style="text-align: center;" class="cor-do-texto"><i class="fad fa-sad-tear fa-3x"></i></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center;" class="cor-do-texto">Aberta</td>
                                    <td style="text-align: center;" class="cor-do-texto">Encerra Hoje</td>
                                    <td style="text-align: center;" class="cor-do-texto">Encerrada</td>
                                </tr>
                            </table>
                        </div>
                        <div class="col-9">
                            <div class="row text-right">
                                <div class="col-12 inline">
                                    <div class="toggle">
                                        <input id="switch" type="checkbox" name="theme" />
                                        <label id="lblswitch" for="switch"></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:ScriptManager ID="ScriptMan1" AsyncPostBackTimeout="600" runat="server"></asp:ScriptManager>


                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                        <Triggers>
                        </Triggers>

                        <ContentTemplate>

                            <asp:UpdateProgress ID="updtprogresso0" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                                DisplayAfter="1000">
                                <ProgressTemplate>
                                    <div class="modal1">
                                        <div class="center1">
                                            <center><div style="margin-top: -25px">
                                                <i class="fa fa-spinner fa-spin fa-3x fa-fw"></i>
                                                            <br></br><h2 style="font-size: 1.0em;"><span class="label label-danger">CONSULTANDO</span></h2>
                                            </div></center>
                                        </div>
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div class="table-responsive">
                                <asp:GridView ID="gridCotacao" runat="server" HorizontalAlign="Center"
                                    AllowPaging="True" AllowSorting="True" CssClass="table"
                                    DataKeyNames="id" Font-Size="Small" Style="width: 100%;" EnableModelValidation="True" AutoGenerateColumns="False" OnRowDataBound="gridCotacao_RowDataBound" OnPageIndexChanging="gridCotacao_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <%--<asp:Image ID="resultImage" runat="server" ImageUrl='<%#  ((Eval("status").ToString() == "A") ? "legenda/green_button_g.png" : "legenda/warning_big.png") %>' />--%>
                                                <%--<asp:Image ID="imgID" runat="server" />--%>
                                                <asp:Label ID="lblstatus" runat="server" Text="Label"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codfor" HeaderText="codfor" Visible="False">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="descricao" HeaderText="Descrição">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="data" HeaderText="data" Visible="False">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="validade" DataFormatString="{0:dd/MM/yy}" HeaderText="Encerramento em">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="status_for" HeaderText="status_for">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="informacao" HeaderText="Detalhes da Cotação">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="codbarras" HeaderText="Código">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Opções">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDetalhes" runat="server" CausesValidation="false"
                                                    CommandName="btnDetalhes" Text="<i class='fad fa-eye fa-1x'></i>&nbsp;Mais Detalhes" PostBackUrl='<%#"menu_cotacoes_detalhes.aspx?codbarras="+HttpUtility.HtmlEncode(Eval("codbarras").ToString())+"&validade="+HttpUtility.HtmlEncode(Eval("validade").ToString())+"&status="+HttpUtility.HtmlEncode(Eval("status").ToString())+"&status_for="+HttpUtility.HtmlEncode(Eval("status_for").ToString())+"&informacao="+HttpUtility.HtmlEncode(Eval("informacao").ToString())%>' />
                                            </ItemTemplate>
                                            <ControlStyle CssClass="btn btn-warning" />
                                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="fonte_titulo_tabela" BackColor="#8D6A9A" ForeColor="White" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="codmatriz" HeaderText="codmatriz" Visible="False">
                                            <HeaderStyle CssClass="fonte_titulo_tabela" />
                                            <ItemStyle CssClass="cor-do-texto-tabela" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="status" HeaderText="status">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="validade" HeaderText="validade">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerStyle CssClass="bs-pagination" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>

                    </asp:UpdatePanel>

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

        <script src="js/modo_escuro.js"></script>

        <script type="text/javascript">

            $(document).ready(function () {

                const temaSalvo = localStorage.getItem('tema_cotacao') ? localStorage.getItem('tema_cotacao') : null;

                if (temaSalvo != null) {

                    if (temaSalvo == 'darkMode') {
                        $("#switch").prop("checked", true);
                        changeColors(darkMode)
                    }

                }

            })

        </script>

    </form>
</body>
</html>

