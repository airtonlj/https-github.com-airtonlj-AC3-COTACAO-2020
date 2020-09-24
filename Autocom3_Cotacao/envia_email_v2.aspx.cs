using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Autocom3_Cotacao
{
    public partial class envia_email_v2 : System.Web.UI.Page
    {

        DataTable tb = new DataTable();
        StringBuilder email = new StringBuilder();

        string conecta = ConfigurationManager.ConnectionStrings["conecta"].ConnectionString;

        private string validarEmail(string email)
        {

            using (SqlConnection con = new SqlConnection(conecta))
            {

                string sql = "SELECT COUNT(*) AS Retorno FROM ac3_cotacao_login	WHERE (email = @email COLLATE SQL_Latin1_General_CP1_CS_AS)";

                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("email", SqlDbType.VarChar);
                        cmd.Parameters["email"].Value = email;
                        cmd.Parameters["email"].Direction = ParameterDirection.Input;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        tb.Clear();
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


                return tb.Rows[0]["retorno"].ToString();


            }

        }

        private string montarEmail(string email)
        {

            using (SqlConnection con = new SqlConnection(conecta))
            {

                string sql = "SELECT codmatriz,codfor,nome,senha,email FROM ac3_cotacao_login WHERE (email = @email COLLATE SQL_Latin1_General_CP1_CS_AS)";

                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@email", SqlDbType.VarChar);
                        cmd.Parameters["@email"].Value = email;
                        cmd.Parameters["@email"].Direction = ParameterDirection.Input;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        tb.Clear();
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


                StringBuilder modelo = new StringBuilder();

                modelo.Append("<table border=\"0\" width=\"100%\" cellpadding=\"5px\">");
                modelo.AppendFormat("< tr >< td >< span style = \"font - family:calibri; font - size:14px; color:#555;\">Empresa :</span></td><td><span style=\"font-family:calibri;font-size:14px;color:#555;\">{0}</span></td></tr>", tb.Rows[0]["nome"]);
                modelo.AppendFormat("<tr><td><span style=\"font-family:calibri;font-size:14px;color:#555;\">E-Mail :</span></td><td><span style=\"font-family:calibri;font-size:14px;color:#555;\">{0}</span></td></tr>", tb.Rows[0]["email"]);
                modelo.AppendFormat("<tr><td><span style=\"font-family:calibri;font-size:14px;color:#555;\">Senha :</span></td><td><span style=\"font-family:calibri;font-size:14px;color:#555;\">{0}</span></td></tr>", tb.Rows[0]["senha"]);
                modelo.Append("<tr><td colspan=\"2\">&nbsp;</td></tr></table>");

                string mensagem = email.Replace("_DADOSLOGIN", modelo.ToString());

                return mensagem;


            }

        }

        private int incluirEmail(string email, string mensagem)
        {

            using (SqlConnection con = new SqlConnection(conecta))
            {

                string sql = "INSERT INTO followup_emails(email, cc, nome, assunto, mensagem) VALUES (@email, '', 'Autocom3', 'Recuperação de Login', @mensagem)";
                int retorno;

                con.Open();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    using (SqlCommand cmd = new SqlCommand(sql, con, trann))
                    {

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add("@email", SqlDbType.VarChar);
                        cmd.Parameters["@email"].Value = email;
                        cmd.Parameters["@email"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@mensagem", SqlDbType.VarChar);
                        cmd.Parameters["@mensagem"].Value = mensagem;
                        cmd.Parameters["@mensagem"].Direction = ParameterDirection.Input;

                        retorno = cmd.ExecuteNonQuery();
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


                return retorno;


            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                string emailRecuperado = Request.QueryString["emailrecuperar"];

                email.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                email.Append("<html xmlns = \"http://www.w3.org/1999/xhtml\">");
                email.Append("<head>< meta content =\"text/html; charset=UTF-8\" http-equiv=\"Content-Type\"/>< meta content =\"initial-scale=1.0\" name=\"viewport\"/>< meta content =\"telephone=no\" name=\"format-detection\"/>< title > Autocom3 - Recuperar E - Mail da Cotação On - Line </ title >< style type =\"text/css\"> .ReadMsgBody{width:100%;background-color:#ffffff}.ExternalClass{width:100%;background-color:#ffffff}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div{line-height:100%}html{width:100%}body{-webkit-text-size-adjust:none;-ms-text-size-adjust:none}body{margin:0;padding:0}table{border-spacing:0}img{display:block !important}table td{border-collapse:collapse}.yshortcuts a{border-bottom:none !important}img{height:auto !important}@media only screen and (max-width: 640px){body{width:auto !important}table[class=\"container\"]{width:100% !important;padding-left:20px !important;padding-right:20px !important}img[class=\"image-100-percent\"]{width:100% !important;height:auto !important;max-width:100% !important}img[class=\"small-image-100-percent\"]{width:100% !important;height:auto !important}table[class=\"full-width\"]{width:100% !important}table[class=\"full-width-text\"]{width:100% !important;background-color:#b91925;padding-left:20px !important;padding-right:20px !important}table[class=\"full-width-text2\"]{width:100% !important;background-color:#f3f3f3;padding-left:20px !important;padding-right:20px !important}table[class=\"col-2-3img\"]{width:50% !important;margin-right:20px !important}table[class=\"col-2-3img-last\"]{width:50% !important}table[class=\"col-2\"]{width:47% !important;margin-right:20px !important}table[class=\"col-2-last\"]{width:47% !important}table[class=\"col-3\"]{width:29% !important;margin-right:20px !important}table[class=\"col-3-last\"]{width:29% !important}table[class=\"row-2\"]{width:50% !important}td[class=\"text-center\"]{text-align:center !important}table[class=\"rem\"]{display:none !important}td[class=\"rem\"]{display:none !important}table[class=\"fix-box\"]{padding-left:20px !important;padding-right:20px !important}td[class=\"fix-box\"]{padding-left:20px !important;padding-right:20px !important}td[class=\"font-resize\"]{font-size:18px !important;line-height:22px !important}table[class=\"space-scale\"]{width:100% !important;float:none !important}}@media only screen and (max-width: 479px){body{font-size:10px !important}table[class=\"container\"]{width:100% !important;padding-left:10px !important;padding-right:10px !important}table[class=\"container2\"]{width:100% !important;float:none !important}img[class=\"image-100-percent\"]{width:100% !important;height:auto !important;max-width:100% !important;min-width:124px !important}img[class=\"small-image-100-percent\"]{width:100% !important;height:auto !important;max-width:100% !important;min-width:124px !important}table[class=\"full-width\"]{width:100% !important}table[class=\"full-width-text\"]{width:100% !important;background-color:#b91925;padding-left:20px !important;padding-right:20px !important}table[class=\"full-width-text2\"]{width:100% !important;background-color:#f3f3f3;padding-left:20px !important;padding-right:20px !important}table[class=\"col-2\"]{width:100% !important;margin-right:0px !important}table[class=\"col-2-last\"]{width:100% !important}table[class=\"col-3\"]{width:100% !important;margin-right:0px !important}table[class=\"col-3-last\"]{width:100% !important}table[class=\"row-2\"]{width:100% !important}table[id=\"col-underline\"]{float:none !important;width:100% !important;border-bottom:1px solid #eee}td[id=\"col-underline\"]{float:none !important;width:100% !important;border-bottom:1px solid #eee}td[class=\"col-underline\"]{float:none !important;width:100% !important;border-bottom:1px solid #eee}td[class=\"text-center\"]{text-align:center !important}div[class=\"text-center\"]{text-align:center !important}table[id=\"clear-padding\"]{padding:0 !important}td[id=\"clear-padding\"]{padding:0 !important}td[class=\"clear-padding\"]{padding:0 !important}table[class=\"rem-479\"]{display:none !important}td[class=\"rem-479\"]{display:none !important}table[class=\"clear-align\"]{float:none !important}table[class=\"width-small\"]{width:100% !important}table[class=\"fix-box\"]{padding-left:0px !important;padding-right:0px !important}td[class=\"fix-box\"]{padding-left:0px !important;padding-right:0px !important}td[class=\"font-resize\"]{font-size:14px !important}td[class=\"increase-Height\"]{height:10px !important}td[class=\"increase-Height-20\"]{height:20px !important}}@media only screen and (max-width: 320px){table[class=\"width-small\"]{width:125px !important}img[class=\"image-100-percent\"]{width:100% !important;height:auto !important;max-width:100% !important;min-width:124px !important}</style></ head > ");
                email.Append("<body style=\"font-size:12px; background-color:#ececec;\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" id=\"mainStructure\" style=\"background-color:#ececec;\" width=\"100%\"><tbody>");
                email.Append("<tr><td align=\"center\" style=\"background-color: #ececec; \" valign=\"top\"><table align=\"center\" bgcolor=\"#777777\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\" style=\"background-color: #777777; \" width=\"600\"><tbody>");
                email.Append("<tr> <td valign=\"top\"><table align=\"center\" bgcolor=\"#777777\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"full-width\" style=\"background-color: #777777; \" width=\"560\"><tbody> <tr>");
                email.Append("<td valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody> <tr> <td valign=\"top\"><table align=\"right\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container2\"><tbody>");
                email.Append("<tr><td align=\"center\" valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\"><tbody> <tr><td style=\"font-size: 12px; line-height: 27px; font-family: Arial,Tahoma, Helvetica, sans-&#10;serif; color:#ffffff; font-weight:normal; text-align:center; padding-right: 10px;\"></td>");
                email.Append("<td align=\"center\" id=\"clear-padding\" valign=\"middle\"><a href=\"https://www.facebook.com/sharer/sharer.php?u=www.autocom3.com.br\" target=\"_blank\"><img alt=\"icon-facebook\" border=\"0\" hspace=\"0\" src=\"https://painel.mail2easy.com.br/images/templates/texto01/icon-facebook.png\" style=\"max-width:30px;\" vspace=\"0\" width=\"30\"/>");
                email.Append("</a></td><td align=\"center\" id=\"clear-padding\" s=\"\" valign=\"middle\"><a href=\"https://twitter.com/intent/tweet?url=www.autocom3.com.br&text=AUTOCOM3 - O Sistema que se encaixa à sua empresa. &hashtags=autocom3%2Csoftware%2Cautomacao&original_referer=\" target=\"_blank\">");
                email.Append("<img alt=\"icon-twitter\" border=\"0\" hspace=\"0\" src=\"https://painel.mail2easy.com.br/images/templates/texto01/icon-twitter.png\" style=\"max-width:30px;\" vspace=\"0\" width=\"30\"/></a></td><td align=\"center\" id=\"clear-padding\" valign=\"middle\">");
                email.Append("<a href=\"https://plus.google.com/share?url=www.autocom3.com.br&text=wow\" target=\"_blank\"><img alt=\"icon-googleplus\" border=\"0\" hspace=\"0\" src=\"https://painel.mail2easy.com.br/images/templates/texto01/icon-googleplus.png\" style=\"max-width:30px;\" vspace=\"0\" width=\"30\"/></a></td>");
                email.Append("</tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr> <td valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"background-color:#ececec;\" width=\"100%\"><tbody>");
                email.Append("<tr><td align=\"center\" class=\"fix-box\" valign=\"top\"><table align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\" style=\"background-color:#ffffff;\" width=\"600\"><tbody><tr>");
                email.Append("<td valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"full-width\" width=\"560\"><tbody> <tr><td height=\"20\" valign=\"top\"> </td></tr><tr> <td valign=\"middle\">");
                email.Append("<table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container2\"><tbody> <tr><td align=\"center\" valign=\"top\"><a href=\"http://www.autocom3.com.br/\"><img alt=\"Logo\" src=\"http://www.autocom3ftp.com.br/download/email/logocor.png\" style=\"border-width: 0px; border-style: solid; margin: 0px; width: 170px; height: 44px; max-width: 182px;\"/>");
                email.Append("</a></td></tr><tr><td class=\"increase-Height-20\" valign=\"top\"> </td></tr></tbody></table><table align=\"right\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container2\"></table></td></tr></tbody></table></td></tr></tbody>");
                email.Append("</table></td></tr></tbody></table></td></tr><tr><td align=\"center\" class=\"fix-box\" valign=\"top\"><table align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\" style=\"background-color: #ffffff; border-bottom:2px solid #ececec; \" width=\"600\"><tbody>");
                email.Append("<tr> <td valign=\"top\"><table align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"full-width\" style=\"background-color:#ffffff;\" width=\"560\"><tbody> <tr><td height=\"20\"> </td></tr><tr> <td valign=\"top\"><table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
                email.Append("<tbody> <tr><td style=\"font-size: 26px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#555555; font-weight:bold; text-&#10;align:center;\"><span style=\"font-weight: bold;\"><span style=\"color:#808080;\">Login e Senha para as </span><span style=\"color:#FFA07A;\">Cotações.</span></span></td></tr><tr>");
                email.Append("<td height=\"15\"> </td></tr><tr><td style=\"font-size: 14px; line-height: 22px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#555555; font-weight:normal; text-&#10;align:left; \"><p style=\"margin: 0cm 0cm 0pt;\"> </p><p style=\"margin: 0cm 0cm 0pt;\"><b><font face=\"Calibri\" size=\"3\">Prezado Fornecedor, </font></b>");
                email.Append("<br><br></p><p style=\"margin: 0cm 0cm 0pt;\"> </p><p style=\"margin: 0cm 0cm 0pt;\"><font face=\"Calibri\" size=\"3\">Segue seu login e senha para acesso ao nosso serviço de cotação on-line. Sempre que lançarmos uma cotação, você receberá um e-mail informando que ela está disponível em nosso portal, aguardando que você nos informe o seu preço atual e condição de entrega. Se tiver alguma dúvida no uso do serviço, pode estar entrando em contato com nossa central de atendimento.</font>");
                email.Append("<strong><p style=\"font-size: 14px; line-height: 22px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#555555; font-weight:normal; text-&#10;align:left; \"><p style=\"margin: 0cm 0cm 0pt;\"> </p><p style=\"margin: 0cm 0cm 0pt;\"><b><font face=\"Calibri\" size=\"3\"><br/>Logins e Senha Encontrados:</font></p><br/>_DADOSLOGIN</td></tr>");
                email.Append("<tr><td style=\"font-size: 14px; line-height: 22px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#555555; font-weight:normal; text-&#10;align:left; \"><tbody></tbody><div style=\"text-align: right;\"> </div></td></tr></tbody></table></td></tr><tr><td height=\"20\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td align=\"center\" class=\"fix-box\" valign=\"top\">");
                email.Append("<table align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\" style=\"background-color: #ffffff; border-bottom:2px solid #c7c7c7; \" width=\"600\"><tbody> <tr> <td valign=\"top\"><table align=\"center\" bgcolor=\"#ffffff\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"full-width\" style=\"background-color:#ffffff;\" width=\"560\"><tbody>");
                email.Append("<tr><td height=\"20\"> </td></tr><tr> <td valign=\"top\"><table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody> <tr><td align=\"left\" style=\"padding-right:10px;\" valign=\"top\" width=\"29\"><table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"29\"><tbody> <tr valign=\"top\"><td align=\"left\" valign=\"middle\"><img alt=\"megaphone\" border=\"0\" hspace=\"0\" src=\"https://painel.mail2easy.com.br/images/templates/texto01/chat.png\" style=\"max-width:40px; diaplay:block;\" vspace=\"0\" width=\"36\"/></td></tr></tbody></table></td><td align=\"left\" style=\"font-size: 18px; line-height: 22px; font-family: Arial,Tahoma, Helvetica, sans-serif; color:#555555; font-&#10;weight:bold; text-align:left;\">Fale com a gente por <a href=\"#\" style=\"text-decoration: none; color: #FFA07A; \">chat</a>, <a href=\"#\" style=\"text-decoration: none; color: #FFA07A; \">e-mail</a> ou ligue [21] 3005-7138</td></tr></tbody></table></td></tr><tr><td height=\"15\"> </td></tr><tr> <td valign=\"top\"><table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tbody> <tr><td style=\"font-size: 11px; line-height: 18px; font-family:Arial,Tahoma, Helvetica, sans-serif; color:#a3a2a2; font-weight:normal; text-&#10;align:left; \">O software que se ajusta à sua empresa.</td></tr></tbody></table></td></tr><tr><td height=\"20\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr><tr> <td valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><tbody> <tr><td align=\"center\" class=\"fix-box\" valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container\" width=\"600\"><tbody> <tr> <td valign=\"top\"><table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"full-width\" width=\"560\"><tbody> <tr><td height=\"20\" valign=\"top\"> </td></tr><tr> <td valign=\"middle\"><table align=\"left\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container2\"><tbody> <tr><td align=\"center\" valign=\"top\"><a href=\"http://www.autocom3.com.br/\"><img alt=\"Logo\" src=\"http://www.autocom3ftp.com.br/download/email/logocinza.png\" style=\"border-width: 0px; border-style: solid; margin: 0px; width: 170px; height: 44px; max-width: 137px;\"/></a></td></tr><tr><td class=\"increase-Height-20\" valign=\"top\"> </td></tr></tbody></table><table align=\"right\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"container2\"><tbody> <tr><td align=\"center\" valign=\"middle\"><table align=\"right\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"clear-align\" style=\"height:100%;\"><tbody> <tr><td style=\"font-size: 13px; line-height: 18px; color: #FFA07A; font-weight:normal; text-&#10;align: center; font-family:Tahoma, Helvetica, Arial, sans-serif;\"><span style=\"text-decoration: none; color: #FFA07A;\"><a href=\"http://www.autocom3.com.br/contato/\" style=\"text-decoration: none; color: #FFA07A; \">Contato&nbsp;</a></span>&nbsp;|&nbsp; <span style=\"text-&#10;decoration: none; color: #FFA07A;\"><a href=\"http://www.autocom3.com.br/a-empresa/\" style=\"text-decoration: none; color: #FFA07A; \">Quem Somos</a></span></td></tr></tbody></table></td></tr></tbody></table></td></tr><tr><td height=\"20\" valign=\"top\"> </td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>");

                string retorno = validarEmail(emailRecuperado);

                if (retorno == "0")
                {
                    Response.Redirect("https://autocom3.com.br/cotacao-e-mail-invalido"); 
                }
                else
                {

                    int retornoint = incluirEmail(emailRecuperado, retorno);

                    if (retornoint == 1)
                    {

                        Response.Redirect("https://autocom3.com.br/cotacao_concluido");  

                    }

                }

            }

        }
    }
}