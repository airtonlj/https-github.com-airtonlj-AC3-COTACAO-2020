<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_cotacoes_detalhes.aspx.cs" Inherits="Autocom3_Cotacao.menu_cotacoes_detalhes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Cotações on-Line Menu de Cotações</title>
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

    <script src="js/jquery-2.1.1.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.1/js/bootstrap.min.js" integrity="sha384-XEerZL0cuoUbHE4nZReLT7nx9gQrQreJekYhJD9WNWhH8nEW+0c5qq7aIo2Wl30J" crossorigin="anonymous"></script>
    <script src="js/jquery.mask.js"></script>
    <style>
        .col {
            word-wrap: break-word;
        }

        #gridDetalhes {
            margin-left: auto;
            margin-right: auto;
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

        .btn-roxo {
            color: white;
            background-color: #64428c;
        }

            .btn-roxo:hover {
                color: white;
                background-color: #8963b5;
            }

        .btn-warning {
            color: White;
        }

            .btn-warning:hover {
                color: White;
            }
    </style>
    <script src="js/mecanica.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.0.0/animate.min.css" />
    <script>
        $(document).ready(function () {
            $('.money').mask('#.##0,00', { reverse: true });
            $('.money2').mask("#.##0,00", { reverse: true });
            $('.numeros').mask("###000", { reverse: true });
            $('.telefone').mask('(00) 0000-0000');
        });

       $(function () {
  $('.example-popover').popover({
    container: 'body'
  })
})

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptMan1" AsyncPostBackTimeout="600" runat="server"></asp:ScriptManager>
            <!-- Topo  -->
            <div class="d-flex bg_roxo fixed-top">
                <div class="mr-auto p-2 ml-3 align-self-center">
                    <a href="#" target="_self">
                        <img src="img/logo.svg" alt="Logo Autocom3" /></a>
                </div>
                <div class="p-2 align-self-center mr-3">
                    <a type="button" href="menu_cotacoes.aspx" class="botao_topo" data-toggle="tooltip" data-placement="bottom" title="Menu Inicial"><i class="fad fa-home"></i></a>
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

            <div class="container-fluid">

                <asp:HiddenField ID="hfFrete" runat="server" />
                <asp:HiddenField ID="hfCondicao" runat="server" />

                <div class="container-fluid">
                    <div class="row">

                        <div class="col-12">
                            <div id="contTabela" class="table-responsive mt-2" runat="server"></div>

                        </div>

                    </div>
                    <% if (Session["semdados"].ToString() == "sim")
                        {%>
                    <div class="mainbody-section text-center">
                        <div class="container">
                            <div class="col-12">
                                <div class="alert alert-danger alert-dismissible fade in" role="alert">
                                    <h3>Aviso.</h3>
                                    <h4>Não pudemos obter a lista de itens da cotação.</h4>
                                    <h4>Vamos começar de novo, por favor faça um novo login.</h4>
                                    <p><a href="cotacao_login.aspx" class="btn btn-default"><span class="glyphicon glyphicon-thumbs-up"></span>&nbsp;Tentar Novamente</a> </p>
                                </div>
                            </div>

                        </div>
                    </div>
                    <%}
                        else
                        {%>
                    <asp:UpdatePanel ID="UpMenu" runat="server">
                        <Triggers>
                        </Triggers>
                        <ContentTemplate>


                            <div class="row">

                                <div class="col-12">
                                    <div class="btn-group d-flex" role="group">
                                        <asp:LinkButton runat="server" CommandName="cmdOutros" class="btn btn-roxo w-100" ID="lnkOutros" OnCommand="lnkOutros_Command"><i class="fad fa-users fa-2x" aria-hidden="true"></i>&nbsp;Outros Participantes</asp:LinkButton>

                                        <% if ((Session["Encerrada"].ToString() == "sim") || (Session["Enviada"].ToString() == "sim"))
                                            { %>
                                        <a href="#" class="btn btn-roxo w-100" disabled="disabled"><i class="fad fa-edit fa-2x" aria-hidden="true"></i>&nbsp;Alterar Frete</a>
                                        <% }
                                            else
                                            { %>
                                        <asp:LinkButton runat="server" CommandName="cmdFrete" CssClass="btn btn-roxo w-100" ID="lnkFrete" OnCommand="lnkFrete_Command"><i class="fad fa-edit fa-2x" aria-hidden="true"></i>&nbsp;Alterar Frete</asp:LinkButton>
                                        <% } %>


                                        <% if ((Session["Encerrada"].ToString() == "sim") || (Session["Enviada"].ToString() == "sim"))
                                            { %>
                                        <a href="#" class="btn btn-roxo w-100" disabled="disabled"><i class="fad fa-calendar-edit fa-2x" aria-hidden="true"></i>&nbsp;Mesmo Prazo Em Todos</a>
                                        <% }
                                            else
                                            { %>
                                        <asp:LinkButton runat="server" CommandName="cmdMesmoPrazo" CssClass="btn btn-roxo w-100" ID="lnkBtMesmoPrazo" OnCommand="lnkBtMesmoPrazo_Command"><i class="fad fa-calendar-edit fa-2x" aria-hidden="true"></i>&nbsp;Mesmo Prazo Em Todos</asp:LinkButton>
                                        <% } %>


                                        <% if ((Session["Encerrada"].ToString() == "sim") || (Session["Enviada"].ToString() == "sim"))
                                            { %>
                                        <a href="#" class="btn btn-block btn-roxo w-100" style="color: White" disabled="disabled"><i class="fad fa-paper-plane fa-2x" aria-hidden="true"></i>&nbsp;Enviar Minha Cotação</a>
                                        <% }
                                            else
                                            { %>
                                        <a onclick="JavaScript:$('#janela').modal('show')" class="btn btn-roxo w-100" style="color: White" name="enviarcot" id="enviarcot"><i class="fad fa-paper-plane fa-2x" aria-hidden="true"></i>&nbsp;Enviar Minha Cotação</a>
                                        <% } %>
                                    </div>
                                </div>

                                <!-- fim da col -->
                            </div>


                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%} %>

                    <div class="row">
                        <div class="col-12">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <triggers></triggers>

                                    <div class="table-responsive">
                                        <table id="tbfrete" runat="server" class="table table-borderless">
                                            <tr>
                                                <th class="cor-do-texto">Frete</th>
                                                <th class="cor-do-texto">Condição de Pagamento</th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtValorFrete" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtCondicaoPagamento" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </div>

                                </ContentTemplate>

                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <br />

                    <div class="row">

                        <div class="col-12">

                            <div class="table-responsive table-condensed">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <Triggers>
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:GridView ID="gridDetalhes" runat="server" HorizontalAlign="Center" DataKeyNames="id"
                                            AllowPaging="True" AllowSorting="True" CssClass="table"
                                            Font-Size="Small" Style="width: 100%;" EnableModelValidation="True" AutoGenerateColumns="False" OnRowDataBound="gridDetalhes_RowDataBound" OnRowCommand="gridDetalhes_RowCommand" OnPageIndexChanging="gridDetalhes_PageIndexChanging" OnRowCancelingEdit="gridDetalhes_RowCancelingEdit" OnRowEditing="gridDetalhes_RowEditing" OnRowUpdating="gridDetalhes_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Chave Produto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblChave" runat="server" Text='<%# Eval("codchave") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="hideGridColumn" />
                                                    <ItemStyle CssClass="hideGridColumn" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Produto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblnomeproduto" runat="server" Text='<%# Bind("nomeproduto") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Em Falta">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblemfalta" runat="server" Text='<%# Bind("emfalta") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="hideGridColumn" />
                                                    <ItemStyle CssClass="hideGridColumn" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Prazo/Dias">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcotacaodias" runat="server" Text='<%# Bind("cotacao_dias") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" Width="80px" />
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtcotacaodias" runat="server" Text='<%# Eval("cotacao_dias") %>' CssClass="form-control numeros" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Preço">
                                                    <ItemTemplate>
                                                        <div style="overflow: auto; width: 100%">
                                                            <asp:Label ID="lblcotacaopreco" runat="server" Text='<%# string.Format("{0:C}", Eval("cotacao_preco")) %>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" Width="180px" />
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtcotacaopreco" runat="server" Text='<%# Eval("cotacao_preco") %>' CssClass="form-control money" />
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quant.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblquantidade" runat="server" Text='<%# Eval("quantidade", "{0:0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total">
                                                    <ItemTemplate>
                                                        <div style="overflow: auto; width: 100%">
                                                            <asp:Label ID="lbltotal" runat="server" Text='<%# string.Format("{0:C}", Convert.ToDouble(Eval("cotacao_preco")) * Convert.ToInt32(Eval("quantidade")))  /* Convert.ToDouble(Convert.ToDouble(Eval("cotacao_preco")) * Convert.ToInt32(Eval("quantidade"))).ToString("####0.00", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) */%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Info. Adicionais">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblinfoadicionais" runat="server" Text='<%# string.Format("Und:{0}<br/>Cód:{1}", Eval("unidade"), Eval("codchave")) %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titulo_tabela" ForeColor="White" />
                                                    <ItemStyle CssClass="fonte_listagem_tabela cor-do-texto-tabela" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Opções">
                                                    <ItemTemplate>
                                                        <%--<div style="overflow: auto; overflow-x: hidden; width: 100%">--%>
                                                        <asp:LinkButton ID="lnkCotar" runat="server" CssClass="btn btn-warning" CausesValidation="false" CommandName="Edit" CommandArgument='<%# Container.DataItemIndex%>' Text="<i class='fad fa-thumbs-up fa-2x' aria-hidden='true'></i>" data-toggle="popover" data-placement="top" title="Editar prazo e preço do item."></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkEmFalta" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="lnkEmFalta" CommandArgument='<%# Container.DataItemIndex%>' Text="<i class='fad fa-thumbs-down fa-2x' aria-hidden='true'></i>" data-toggle="popover" data-placement="top" title="Informar a falta do item no momento."></asp:LinkButton>
                                                        <%-- </div>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="btn btn-success" CausesValidation="false" CommandName="Update" Text="<i class='fad fa-save fa-2x'></i>" data-toggle="popover" data-placement="top" title="Salvar o novo prazo e valor do item."></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn btn-danger" CausesValidation="false" CommandName="Cancel" Text="<i class='fad fa-window-close fa-2x'></i>" data-toggle="popover" data-placement="top" title="Cancelar."></asp:LinkButton>
                                                    </EditItemTemplate>
                                                    <HeaderStyle BackColor="#8D6A9A" CssClass="fonte_titlo_tabela" ForeColor="White" />
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="150px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <PagerStyle CssClass="bs-pagination" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <% if (Session["Encerrada"].ToString() == "sim")
                                { %>
                            <div class="alert alert-danger" role="alert">
                                <h4><i class="fad fa-exclamation-triangle fa-1x"></i>&nbsp;Atenção</h4>
                                <p>Cotação já finalizada.</p>
                            </div>
                            <% }
                                else
                                { %>
                            <% if (Session["Enviada"].ToString() == "não")
                                { %>
                            <div class="alert alert-warning" role="alert">
                                <h4><i class="fad fa-exclamation-triangle fa-1x"></i>&nbsp;Atenção</h4>
                                <p>Sua cotação ainda não foi enviada ao comprador.</p>
                            </div>
                            <% }
                                else
                                { %>
                            <div class="alert alert-info" role="alert">
                                <h4><i class="fad fa-exclamation-triangle fa-1x"></i>&nbsp;Atenção</h4>
                                <p>Esta cotação já foi enviada ao comprador.</p>
                            </div>
                            <% } %>
                            <% } %>
                        </div>
                        <div class="col-3">
                        </div>
                        <div class="col-3">
                        </div>
                        <div class="col-2">&nbsp;</div>
                    </div>
                </div>

            </div>


            <!-- modal para editar um registro -->
            <div class="modal fade" tabindex="-1" data-backdrop="static" role="dialog" id="divCotar">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="exampleModalCenterTitle">Lançar Cotação</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body text-left">
                            <asp:UpdatePanel ID="upCotar" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-borderless">
                                            <tr>
                                                <td class="cor-do-texto">Produto:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblproduto" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Código:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblcodigo" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Quantidade:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblquantidade" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Preço de custo:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblprecocusto" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Digite o novo preço:</td>
                                                <td class="cor-do-texto">
                                                    <asp:TextBox ID="txtprecocusto" runat="server" CssClass="money form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Prazo de entrega(Dias):</td>
                                                <td class="cor-do-texto">
                                                    <asp:TextBox ID="txtprazoentrega" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Label ID="lblResult" Visible="false" runat="server"></asp:Label>
                                        <asp:Button ID="btnCotar" runat="server" Text="Lançar Cotação" CssClass="btn btn-warning" OnClick="btnCotar_Click" />
                                        <%-- <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Fechar</button>--%>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridDetalhes" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="btnCotar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                    <!-- /.modal-dialog -->
                </div>
            </div>

            <!-- modal para editar um registro -->
            <div class="modal fade" tabindex="-1" data-backdrop="static" role="dialog" id="divFrete">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="x">Informar frete e condição de pagamento</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="updtPanelFrete" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table class="table table-borderless">
                                            <tr>
                                                <td class="cor-do-texto">Frete:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblFrete" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Condição de Pagamento:</td>
                                                <td class="cor-do-texto">
                                                    <asp:Label ID="lblCondicao" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Novo Valor do Frete:</td>
                                                <td class="cor-do-texto">
                                                    <asp:TextBox ID="txtFrete" runat="server" CssClass="money form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="cor-do-texto">Nova Condição de Pagamento:</td>
                                                <td class="cor-do-texto">
                                                    <asp:TextBox ID="txtCondicao" Style="resize: none" TextMode="MultiLine" Rows="6" Columns="60" MaxLength="100" runat="server" CssClass="form-control medidaFixa"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnSalvarFrete" runat="server" Text="Salvar" CssClass="btn btn-roxo" OnClick="atualizarFrete" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridDetalhes" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSalvarFrete" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                    <!-- /.modal-dialog -->
                </div>
            </div>

            <!-- modal para editar um registro -->
            <div class="modal fade" id="divPrazoUnico">
                <div class="modal-dialog  modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="c">Igualar prazos</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body text-left">
                            <asp:UpdatePanel ID="upPrazoUnico" runat="server">
                                <ContentTemplate>
                                    <div class="modal-body">
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="cor-do-texto">Os produtos serão entregues em até:&nbsp;&nbsp;</td>
                                                <td class="cor-do-texto">
                                                    <asp:TextBox ID="txtprazounico" runat="server" CssClass="form-control"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnPrazoUnico" runat="server" Text="Confirmar" CssClass="btn btn-roxo" OnClick="btnPrazoUnico_Click" required="required" />
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridDetalhes" EventName="RowCommand" />
                                    <asp:AsyncPostBackTrigger ControlID="btnPrazoUnico" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                    <!-- /.modal-dialog -->
                </div>
            </div>


            <div class="modal fade" id="dialogoEmBranco">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="d">Por favor verifique</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <h4 class="cor-do-texto">Verifique o preenchimento dos campos preço de venda e prazo para entrega.</h4>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-lg btn-warning" data-dismiss="modal">Entendi</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->

            <div class="modal fade" tabindex="-1" id="outrosParticipantes">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="exampleModalLabel">Participam dessa cotação</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel ID="upParticipantes" runat="server">
                                <ContentTemplate>
                                    <div style="overflow-y: auto; height: 150px;">
                                        <div class="table-responsive cor-do-texto">
                                            <div id="participantes" runat="server"></div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers></Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-roxo" data-dismiss="modal">Fechar</button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->



            <!-- Indicar produto em falta -->

            <div class="modal fade" id="divemfalta">
                <div class="modal-dialog modal-lg modal-dialog-centered">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="b">Confirmar</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body text-left">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hfEmFalta" runat="server" />
                                    <asp:HiddenField ID="hfcodprod" runat="server" />
                                    <asp:Label ID="labelfrase" runat="server" CssClass="cor-do-texto" Text="Confirma que o produto selecionado está em falta?"></asp:Label>
                                    <asp:DetailsView ID="DetailsView1" runat="server"
                                        CssClass="table table-bordered table-hover cor-do-texto"
                                        BackColor="White"
                                        ForeColor="Black"
                                        FieldHeaderStyle-Wrap="false"
                                        FieldHeaderStyle-Font-Bold="true"
                                        FieldHeaderStyle-BackColor="LavenderBlush"
                                        FieldHeaderStyle-ForeColor="Black"
                                        BorderStyle="Groove"
                                        AutoGenerateRows="False">
                                        <Fields>
                                            <asp:BoundField DataField="codchave" HeaderText="Código" />
                                            <asp:BoundField DataField="nomeproduto" HeaderText="Produto" />
                                        </Fields>
                                    </asp:DetailsView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnEmfalta" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnEmfalta" class="btn btn-danger" runat="server" Text="Confirmar" OnClick="btnEmFalta_Click" />
                            <%--<button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Fechar</button>--%>
                        </div>
                    </div>
                </div>

            </div>

            <!-- região dos modais -->
            <div id="janela" class="modal fade">
                <div class="modal-dialog modal-sm modal-dialog-centered" tabindex="-1">
                    <div class="modal-content cor_modal">
                        <div class="modal-header">
                            <h5 class="modal-title cor-do-texto" id="q">Finalizando</h5>
                            <button type="button" class="close cor-do-texto" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <asp:UpdatePanel ID="update1" runat="server">
                            <ContentTemplate>
                                <div class="modal-body">
                                    <h6 class="cor-do-texto">Enviar sua cotação ao comprador?</h6>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal"><i class="fad fa-times-circle fa-1x"></i>&nbsp;Cancelar</button>
                                    <asp:LinkButton ID="lnkEnviar" runat="server" CssClass="btn btn-success" OnClick="btnEnviar_Click"><i class="fad fa-check-circle fa-1x"></i>&nbsp;Enviar Agora</asp:LinkButton>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lnkEnviar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>


            <script src="js/modo_escuro.js"></script>

            <script type="text/javascript">

                $(document).ready(function () {

                    const temaSalvo = localStorage.getItem('tema_cotacao') ? localStorage.getItem('tema_cotacao') : null;


                    if (temaSalvo != null) {

                        if (temaSalvo == 'darkMode') {
                            changeColors(darkMode)
                        }

                    }

                })

            </script>

            <script>

                $('#divPrazoUnico').on('shown.bs.modal', function () {
                    $('#txtprazounico').focus();
                })

                $('#divCotar').on('shown.bs.modal', function () {
                    $('#txtprecocusto').focus();
                })

                function popOutrosParticipantes() {
                    $('#outrosParticipantes').modal('show');
                }

                function closePopOutros() {
                    $('#outrosParticipantes').modal('hide');

                }

                function prazoUnico() {
                    $('#divPrazoUnico').modal('show');
                }

                function closePrazoUnico() {
                    $('#divPrazoUnico').modal('hide');

                }

                function cotacaoEmFalta() {
                    $('#divemfalta').modal('show');
                }

                function closecotacaoEmFalta() {
                    $('#divemfalta').modal('hide');

                }

                function cotacaoEmBranco() {
                    $('#dialogoEmBranco').modal('show');
                }

                function closeEmBranco() {
                    $('#dialogoEmBranco').modal('hide');

                }


                function cotarPreco() {
                    $('#divCotar').modal('show');
                }

                function closecotarPreco() {
                    $('#divCotar').modal('hide');

                }

                function lancarFrete() {
                    $('#divFrete').modal('show');
                }

                function closeFrete() {
                    $('#divFrete').modal('hide');

                }

                function selecione() {
                  <%--  $get('<%= FindControl("txtcotacaodias").ClientID %>').focus();
                    $get('<%= FindControl("txtcotacaodias").ClientID %>').select();--%>

                    //var table = document.getElementById("gridDetalhes");

                    //if (table.rows.length > 0) {
                    //    //loop the gridview table
                    //    for (var i = 1; i < table.rows.length; i++) {
                    //        //get all the input elements
                    //        var inputs = table.rows[i].getElementsByTagName("input");
                    //        for (var j = 0; j < inputs.length; j++) {
                    //            //get the textbox1
                    //            if (inputs[j].id.indexOf("txtcotacaodias") > -1) {
                    //                inputs[j].focus();
                    //                inputs[j].select();
                    //                break;
                    //            }

                    //        }

                    //    }
                    //}


                };

               <%-- $('#divFrete').on('click', '.btn-warning', function () {
                    var value =  $('#<%=txtFrete.ClientID%>').val();
                    $('.txtValorFrete').val(value);
                    $('#myModal').modal('hide');
                });--%>


                

            </script>

            <script type="text/javascript">

                function valorPadrao2(obj) {
                    if (obj.value === "") {
                        obj.value = "0,00";
                        return true;
                    }
                }


                $(function () {
                    function reposition() {
                        var modal = $(this),
                            dialog = modal.find('.modal-dialog');
                        modal.css('display', 'block');

                        // Dividing by two centers the modal exactly, but dividing by three 
                        // or four works better for larger screens.
                        dialog.css("margin-top", Math.max(0, ($(window).height() - dialog.height()) / 2));
                    }
                    // Reposition when a modal is shown
                    $('.modal').on('show.bs.modal', reposition);
                    // Reposition when the window is resized
                    $(window).on('resize', function () {
                        $('.modal:visible').each(reposition);
                    });
                });

            </script>



        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <footer class="footer">
            <div class="container-fluid">
                <div class="row footer_copyright ">
                    <div class="col-12 text-white  align-self-center">2020 – Todos os direitos reservados a Autocom3</div>
                </div>
            </div>
        </footer>



    </form>
</body>
</html>
