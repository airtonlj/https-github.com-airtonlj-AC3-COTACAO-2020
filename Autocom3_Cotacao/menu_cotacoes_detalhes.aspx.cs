using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Autocom3_Cotacao
{
    public partial class menu_cotacoes_detalhes : System.Web.UI.Page
    {
        private string conecta = ConfigurationManager.ConnectionStrings["conecta"].ConnectionString;
        private DataTable funcaoDT = new DataTable();
        private DataTable tbMaster = new DataTable();
        private DataTable tbDetalhes = new DataTable();

        private void fecharCotacao(string codbarras, string codmatriz, string codfor)
        {
            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    string sql = @"UPDATE ac3_cotacao_master_v7 SET status_for = 'E', STATUS = 'F' 
                                WHERE codbarras = @CODBARRAS AND codmatriz = @CODMATRIZ AND codfor = @CODFOR";

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        string retorno = (string)cmd.Parameters["msg"].Value;

                        cmd.ExecuteNonQuery();
                        trann.Commit();

                        if (retorno == "")
                        {
                            Session["Enviada"] = "sim";
                            Response.Redirect("menu_cotacoes.aspx");
                        }
                        else
                        {
                            Response.Write(retorno);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private bool validar(string texto)
        {

            if (texto.Length == 0)
            {

                StringBuilder sb = new StringBuilder("<script type = 'text/javascript'>");
                sb.Append("alert('Informe o prazo.');");
                sb.Append("</script>");
                ScriptManager.RegisterStartupScript(this, GetType(), "x", sb.ToString(), true);
                return false;

            }

            return true;
        }

        private void updateEmFalta(string emfalta,
                                string codmatriz,
                                string codbarras,
                                string codfor,
                                string codchave)
        {
            if (emfalta == "S")
            {
                emfalta = "N";
            }
            else
            {
                emfalta = "S";
            }

            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {
                    string sql = @"UPDATE ac3_cotacao_itens_v7 SET emfalta = @emfalta, cotacao_preco = '0',
                                    cotacao_dias = '0' WHERE codmatriz = @codmatriz AND codbarras = @codbarras AND
                                    codfor = @codfor AND codchave = @codchave";

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("emfalta", SqlDbType.VarChar);
                        cmd.Parameters["emfalta"].Value = emfalta;
                        cmd.Parameters["emfalta"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codchave", SqlDbType.VarChar);
                        cmd.Parameters["codchave"].Value = codchave;
                        cmd.Parameters["codchave"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        trann.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void executeUpdateQuantidades(string codbarras, string codfor, string codmatriz, string dias)
        {
            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    string acao = @"UPDATE ac3_cotacao_itens_v7
                                    SET cotacao_dias = @DIAS
                                    WHERE codmatriz = @CODMATRIZ
                                        AND codbarras = @CODBARRAS
                                        AND codfor = @CODFOR AND upper(emfalta) = 'N'";

                    using (SqlCommand cmd = new SqlCommand(acao, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("dias", SqlDbType.Decimal);
                        cmd.Parameters["dias"].Value = dias;
                        cmd.Parameters["dias"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        trann.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }


        private void executeUpdate_A(string codmatriz, string codbarras, string codfor, decimal vrfrete, string condpagt)
        {

            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    string sql = @"UPDATE ac3_cotacao_master_v7 SET vrfrete = @vrfrete, condpagt = @condpagt 
                                WHERE codbarras = @CODBARRAS AND codmatriz = @CODMATRIZ AND codfor = @CODFOR";

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("vrfrete", SqlDbType.Decimal);
                        cmd.Parameters["vrfrete"].Value = vrfrete;
                        cmd.Parameters["vrfrete"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("condpagt", SqlDbType.VarChar);
                        cmd.Parameters["condpagt"].Value = condpagt;
                        cmd.Parameters["condpagt"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        string retorno = (string)cmd.Parameters["msg"].Value;

                        cmd.ExecuteNonQuery();
                        trann.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

        }


        private void executeUpdate_B(string codchave, string codbarras, string codfornecedor, string codmatriz, double preco, int dias)
        {
            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {
                    string acao = @"UPDATE ac3_cotacao_itens_v7
                                    SET cotacao_preco = @preco
                                        ,cotacao_dias = @dias
                                    WHERE codmatriz = @codmatriz
                                        AND codbarras = @codbarras
                                        AND codfor = @codfor
                                        AND codchave = @codchave";

                    using (SqlCommand cmd = new SqlCommand(acao, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codchave", SqlDbType.VarChar);
                        cmd.Parameters["codchave"].Value = codchave.Trim();
                        cmd.Parameters["codchave"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfornecedor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("preco", SqlDbType.Decimal);
                        cmd.Parameters["preco"].Value = preco;
                        cmd.Parameters["preco"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("dias", SqlDbType.Decimal);
                        cmd.Parameters["dias"].Value = dias;
                        cmd.Parameters["dias"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        int retorno = cmd.ExecuteNonQuery();
                        trann.Commit();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private DataTable localizarOutrosParticipantes(string codbarras)
        {
            DataTable tb = new DataTable();

            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                string query = @"SELECT m.codbarras,l.codmatriz
                                ,l.codfor,l.nome FROM ac3_cotacao_login AS l
                            INNER JOIN ac3_cotacao_master_v7 AS m ON l.codmatriz = m.codmatriz
                                AND l.codfor = m.codfor
                            WHERE m.codbarras = @codbarras";

                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        da.Fill(tb);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return tb;
            }
        }

        private DataTable cotacaoMaster(string codmatriz, string codbarras, string codfor)
        {
            DataTable tb = new DataTable();

            using (SqlConnection con = new SqlConnection(conecta))
            {
                con.Open();
                string query = @"select descricao,vrfrete,condpagt,data,validade,informacao from ac3_cotacao_master_v7
                                where codmatriz=@codmatriz and codfor=@codfor and codbarras=@codbarras";

                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con, trann))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        da.Fill(tb);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return tb;
            }
        }

        private DataTable produtos(string codmatriz, string codbarras, string codfor)
        {
            using (SqlConnection con = new SqlConnection(conecta))
            {
                DataColumn column = new DataColumn("id");
                column.DataType = System.Type.GetType("System.Int32");
                column.AutoIncrement = true;
                column.AutoIncrementSeed = 1;
                column.AutoIncrementStep = 1;

                funcaoDT.Columns.Add(column);

                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SE_COTACOES_MASTER_DETALHES", con, trann))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = codmatriz;
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codbarras", SqlDbType.VarChar);
                        cmd.Parameters["codbarras"].Value = codbarras;
                        cmd.Parameters["codbarras"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = codfor;
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        da.Fill(funcaoDT);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return funcaoDT;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["codmatriz"].ToString() == "") || (Session["codfor"].ToString() == ""))
                {
                    Response.Redirect("aviso.aspx");
                }

                string informacaoRecebida = HttpUtility.HtmlDecode(Request.QueryString["informacao"]);
                string validadeRecebida = HttpUtility.HtmlDecode(Request.QueryString["validade"]);

                validadeRecebida = Convert.ToDateTime(validadeRecebida).ToShortDateString();

                if ((string.IsNullOrEmpty(Session["codbarras"] as string)) || (Session["codbarras"].ToString() != HttpUtility.HtmlDecode(Request.QueryString["codbarras"])))
                {
                    Session["codbarras"] = HttpUtility.HtmlDecode(Request.QueryString["codbarras"]);
                }

                if (HttpUtility.HtmlDecode(Request.QueryString["status_for"]) == "e")
                {
                    Session["Enviada"] = "sim";
                }
                else
                {
                    Session["Enviada"] = "não";
                }

                if ((DateTime.Today > Convert.ToDateTime(validadeRecebida)) || (HttpUtility.HtmlDecode(Request.QueryString["status"]) == "F"))
                {
                    Session["Encerrada"] = "sim";
                }
                else
                {
                    Session["Encerrada"] = "não";
                }

                if (string.IsNullOrEmpty(informacaoRecebida))
                {
                    Session["Informacao"] = informacaoRecebida;
                }

                if (!string.IsNullOrEmpty(informacaoRecebida))
                {
                    Session["Informacao"] = informacaoRecebida;
                }

                BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

                DataTable tbretorno = cotacaoMaster(Session["codmatriz"].ToString(), Session["codbarras"].ToString(), Session["codfor"].ToString());

                string tabelabs = "<table class=\"table table-bordered\">";
                tabelabs += "<th class=\"cor-do-texto\">Descrição</th><th class=\"cor-do-texto\">Encerramento em</th><th class=\"cor-do-texto\">Detalhes da Cotação</th>";
                foreach (DataRow linha in tbretorno.Rows)
                {
                    tabelabs += "<tr><td class=\"cor-do-texto\">" + linha["descricao"].ToString() + "</td><td class=\"cor-do-texto\">" + Convert.ToDateTime(linha["validade"].ToString()).ToString("dd/MM/yyyy") + "</td><td class=\"cor-do-texto\">" + linha["informacao"].ToString() + "</td></tr>";
                }
                tabelabs += "</table>";

                if (Session["vrfrete"] != null)
                {
                    txtValorFrete.Text = Session["vrfrete"].ToString();

                }
                else
                {
                    txtValorFrete.Text = tbretorno.Rows[0]["vrfrete"].ToString();
                }

                if (Session["condpagt"] != null)
                {
                    txtCondicaoPagamento.Text = Session["condpagt"].ToString();
                }
                else
                {
                    txtCondicaoPagamento.Text = tbretorno.Rows[0]["condpagt"].ToString();
                }



                contTabela.InnerHtml = tabelabs;

                //HtmlTableRow tlinha = new HtmlTableRow();

                //foreach (DataRow linha in tbretorno.Rows)
                //{

                //    HtmlTableCell tbcelula1 = new HtmlTableCell();
                //    HtmlTableCell tbcelula2 = new HtmlTableCell();
                //    hfFrete.Value = linha["vrfrete"].ToString();
                //    tbcelula1.InnerText = linha["vrfrete"].ToString();
                //    tlinha.Controls.Add(tbcelula1);
                //    hfCondicao.Value = linha["condpagt"].ToString();
                //    tbcelula2.InnerText = linha["condpagt"].ToString();
                //    tlinha.Controls.Add(tbcelula2);


                //}

                //tbfrete.Rows.Add(tlinha);



            }

            txtprecocusto.Attributes.Add("onfocus", "this.select()");
            txtprecocusto.Attributes.Add("onblur", "return valorPadrao2(this);");
            txtFrete.Attributes.Add("onfocus", "this.select()");
            txtFrete.Attributes.Add("onblur", "return valorPadrao2(this);");
            txtprazounico.Attributes.Add("onfocus", "this.select()");
            txtprazounico.Attributes.Add("onKeyPress", "return SomenteNumero(event);");
            txtprazounico.Attributes.Add("onblur", "return valorPadrao(this);");
            txtprazoentrega.Attributes.Add("onfocus", "this.select()");
            txtprazoentrega.Attributes.Add("onKeyPress", "return SomenteNumero(event);");
            txtprazoentrega.Attributes.Add("onblur", "return valorPadrao(this);");
        }

        private void BindGrid(string codmatrizRecebida, string codforRecebido, string codbarrasRecebida)
        {
            tbDetalhes = produtos(codmatrizRecebida, codbarrasRecebida, codforRecebido);

            if (tbDetalhes == null)
            {
                Session["semdados"] = "sim";
            }
            else
            {
                Session["semdados"] = "não";

                Session["tabela"] = tbDetalhes;
                gridDetalhes.DataSource = tbDetalhes;
                gridDetalhes.DataBind();
            }
        }

        protected void gridDetalhes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //gridDetalhes.Columns[0].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow) //to access data rows only (not to deal with HeaderRow and FooterRow
            {
                Label View = e.Row.FindControl("lblemfalta") as Label;
                if (View != null)
                {
                    LinkButton lnkcotar = e.Row.FindControl("lnkCotar") as LinkButton;
                    LinkButton lnkemfalta = e.Row.FindControl("lnkEmFalta") as LinkButton;

                    if (lnkcotar != null)
                    {
                        if (Session["Encerrada"].ToString() == "sim")
                        {
                            lnkcotar.Enabled = false;
                            lnkemfalta.Enabled = false;

                            if (View.Text.Trim() == "S")
                            {
                                lnkemfalta.CssClass = "btn btn-info";
                                lnkemfalta.Text = "<i class='fad fa-box-check fa-2x'></i>";
                            }


                        }
                        else
                        {

                            if (Session["Enviada"].ToString() == "não")
                            {

                                if (View.Text.Trim() == "S")
                                {
                                    lnkcotar.Enabled = false;
                                    lnkemfalta.CssClass = "btn btn-info";
                                    lnkemfalta.Text = "<i class='fad fa-box-check fa-2x'></i>";
                                }
                                else
                                {
                                    lnkcotar.Enabled = true;
                                }


                            }

                        }
                    }
                }
            }
        }

        protected void gridDetalhes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("lnkCotar"))
            {
                int index = int.Parse(e.CommandArgument.ToString()) % gridDetalhes.PageSize;
                Label lbl;
                GridViewRow linha = gridDetalhes.Rows[index];

                lblcodigo.Text = linha.Cells[0].Text;
                lbl = linha.FindControl("lblnomeproduto") as Label;
                lblproduto.Text = lbl.Text;
                lbl = linha.FindControl("lblquantidade") as Label;
                lblquantidade.Text = lbl.Text;
                lbl = linha.FindControl("lblcotacaopreco") as Label;
                lblprecocusto.Text = lbl.Text;
                txtprecocusto.Text = "0,00";
                lbl = linha.FindControl("lblcotacaodias") as Label;
                txtprazoentrega.Text = lbl.Text;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cotarPreco();", true);
                return;
            }
            else if (e.CommandName.Equals("lnkEmFalta"))
            {
                int index = int.Parse(e.CommandArgument.ToString()) % gridDetalhes.PageSize;
                Label lbl;
                GridViewRow linha = gridDetalhes.Rows[index];
                
                hfcodprod.Value = Convert.ToString((gridDetalhes.Rows[index].FindControl("lblChave") as Label).Text.Trim()); 
                string codchave = Convert.ToString((gridDetalhes.Rows[index].FindControl("lblChave") as Label).Text.Trim());
                lbl = linha.FindControl("lblemfalta") as Label;
                hfEmFalta.Value = lbl.Text;

                DataTable tbrecuperada = (DataTable)Session["tabela"];

                DataRow[] lin = tbrecuperada.Select(string.Format("codchave='{0}'", codchave));

                DataTable tb = lin.CopyToDataTable();
                DetailsView1.DataSource = tb;
                DetailsView1.DataBind();
                if ((hfEmFalta.Value == "N") || (hfEmFalta.Value == ""))
                {
                    labelfrase.Text = "Confirma que o produto selecionado está em falta?";
                }
                else
                {
                    labelfrase.Text = "Confirma que o produto selecionado possui estoque?";
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cotacaoEmFalta();", true);
            }
        }

        private bool validarCampos()
        {
            string preco = txtprecocusto.Text;
            preco = preco.Trim();

            string dias = txtprazoentrega.Text;
            dias = dias.Trim();

            if ((dias == "") || (preco == ""))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "cotacaoEmBranco();", true);
                return false;
            }

            return true;
        }

        protected void btnCotar_Click(object sender, EventArgs e)
        {
            double preco = Convert.ToDouble(txtprecocusto.Text);

            executeUpdate_B(lblcodigo.Text, Session["codbarras"].ToString(), Session["codfor"].ToString(), Session["codmatriz"].ToString(), preco, Convert.ToInt32(txtprazoentrega.Text));

            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "closecotarPreco();", true);
            return;
        }

        protected void btnEmFalta_Click(object sender, EventArgs e)
        {
            updateEmFalta(hfEmFalta.Value, Session["codmatriz"].ToString(), Session["codbarras"].ToString(), Session["codfor"].ToString(), hfcodprod.Value);

            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "closecotacaoEmFalta();", true);
            return;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            fecharCotacao(Session["codbarras"].ToString(), Session["codmatriz"].ToString(), Session["codfor"].ToString());
        }

        protected void btnPrazoUnico_Click(object sender, EventArgs e)
        {

            if (validar(txtprazounico.Text.Trim()))
            {
                executeUpdateQuantidades(Session["codbarras"].ToString(), Session["codfor"].ToString(), Session["codmatriz"].ToString(), txtprazounico.Text);

                BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "closePrazoUnico();", true);
                return;
            }


        }

        protected void lnkOutros_Command(object sender, CommandEventArgs e)
        {
            DataTable tbOutros = localizarOutrosParticipantes(Session["codbarras"].ToString());

            string tabelabs = "<table class=\"table table-borderless\">";
            tabelabs += "<th class=\"cor-do-texto\">Cotação</th><th class=\"cor-do-texto\">Participante</th>";
            foreach (DataRow linha in tbOutros.Rows)
            {
                tabelabs += "<tr><td class=\"cor-do-texto\">" + linha["codbarras"].ToString() + "</td><td class=\"cor-do-texto\">" + linha["nome"].ToString() + "</td></tr>";
            }
            tabelabs += "</table>";

            participantes.InnerHtml = tabelabs;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "popOutrosParticipantes();", true);
            return;
        }

        protected void lnkBtMesmoPrazo_Command(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "prazoUnico();", true);
            return;
        }

        protected void gridDetalhes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridDetalhes.PageIndex = e.NewPageIndex;

            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

        }

        protected void lnkFrete_Command(object sender, CommandEventArgs e)
        {

            //double no = Convert.Int(hidden_field.Value.TrimStart());
            double no = 0;

            if (!double.TryParse(txtValorFrete.Text.TrimStart(), out no))
            {
                lblFrete.Text = "0,00";

            }
            else
            {
                lblFrete.Text = txtValorFrete.Text.TrimStart();
            }

            lblCondicao.Text = txtCondicaoPagamento.Text;

            txtFrete.Text = "0,00";
            txtCondicao.Text = "";


            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "lancarFrete();", true);
            return;
        }

        protected void atualizarFrete(object sender, EventArgs e)
        {

            string novoValor = txtFrete.Text;
            //string valorAtual = txtValorFrete.Text;

            string novaCondicao = txtCondicao.Text;
            //string condicaoAtual = txtCondicaoPagamento.Text;

            //if (novoValor != valorAtual)
            //{
            Session["vrfrete"] = novoValor.ToString();
            //}

            //if (condicaoAtual != novaCondicao)
            //{
            Session["condpagt"] = novaCondicao;
            //}

            txtValorFrete.Text = string.Format("{0:C}", Session["vrfrete"].ToString());
            txtCondicaoPagamento.Text = Session["condpagt"].ToString();

            executeUpdate_A(Session["codmatriz"].ToString(), Session["codbarras"].ToString(), Session["codfor"].ToString(), Convert.ToDecimal(txtValorFrete.Text), txtCondicaoPagamento.Text);

            ScriptManager.RegisterStartupScript(this, GetType(), "Close", "closeFrete();", true);
            return;

        }

        protected void gridDetalhes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
            gridDetalhes.EditIndex = e.NewEditIndex;
            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());
            ScriptManager.RegisterStartupScript(this, GetType(), "x", "selecione()",true);

        }

        protected void gridDetalhes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gridDetalhes.EditIndex = -1;
            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

        }

        protected void gridDetalhes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string chave = Convert.ToString((gridDetalhes.Rows[e.RowIndex].FindControl("lblChave") as Label).Text.Trim());

            string preco = (gridDetalhes.Rows[e.RowIndex].FindControl("txtcotacaopreco") as TextBox).Text.Trim(); 

            if (preco.Length == 0)
            {
                preco = "0,00";
            }

            string dias = Convert.ToString((gridDetalhes.Rows[e.RowIndex].FindControl("txtcotacaodias") as TextBox).Text.Trim());

            if (dias.Length == 0)
            {
                dias = "0";
            }

            executeUpdate_B(chave, Session["codbarras"].ToString(), Session["codfor"].ToString(), Session["codmatriz"].ToString(), Convert.ToDouble(preco) , Convert.ToInt32(dias));

            gridDetalhes.EditIndex = -1;

            BindGrid(Session["codmatriz"].ToString(), Session["codfor"].ToString(), Session["codbarras"].ToString());

        }
    }
}