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
    public partial class default_b : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        string conecta = ConfigurationManager.ConnectionStrings["conecta"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["cod_usuario"] == null)
                {

                    //Server.Transfer("default.aspx", false);
                    //Response.End();

                    //AcaoLogar("lucas.ramos@autocom3.com.br", "0DG4C");

                }

            }
            else
            {



            }

        }


        protected void AcaoLogar(string email, string senha)
        {

            using (SqlConnection conn = new SqlConnection(conecta))
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand("SE_COTACOES_LOGAR", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("email", SqlDbType.VarChar);
                cmd.Parameters["email"].Value = email;
                cmd.Parameters["email"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("senha", SqlDbType.VarChar);
                cmd.Parameters["senha"].Value = senha.ToUpper();
                cmd.Parameters["senha"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("msg", SqlDbType.VarChar);
                cmd.Parameters["msg"].Value = "";
                cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                string msglogar = cmd.Parameters["msg"].Value.ToString();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection.Close();
                cmd.Dispose();
                da.Fill(dt);

                SqlCommand cmdLimpa = new SqlCommand("DE_COTACOES_ANTIGAS", conn);

                cmdLimpa.CommandType = CommandType.StoredProcedure;
                cmdLimpa.Parameters.Add("msg", SqlDbType.VarChar);
                cmdLimpa.Parameters["msg"].Value = "";
                cmdLimpa.Parameters["msg"].Direction = ParameterDirection.Output;

                string msglimpar = cmd.Parameters["msg"].Value.ToString();

                if (msglogar == "")
                {

                    if (dt.Rows.Count > 0)
                    {

                        Session["codmatriz"] = dt.Rows[0]["codmatriz"];
                        Session["codfor"] = dt.Rows[0]["codfor"];
                        Session["nome"] = dt.Rows[0]["nome"];
                        Session["senha"] = dt.Rows[0]["senha"];
                        Session["email"] = dt.Rows[0]["email"];


                        Response.Redirect("menu_cotacoes.aspx");

                    }
                    else
                    {

                        Response.Redirect("https://autocom3.com.br/cotacao-e-mail-invalido");

                    }


                }
                else
                {

                    Response.Redirect("https://autocom3.com.br/cotacao-e-mail-invalido");

                }

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtemail.Text;
            email = email.Trim();

            string senha = txtsenha.Text;
            senha = senha.Trim();

            if ((email == "") || (senha == ""))
            {
                txtemail.Text = "";
                txtsenha.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "camposVazios();", true);
                return;
            }

            AcaoLogar(email, senha);

        }

        protected void btRecuperar_Click(object sender, EventArgs e)
        {

            string email = emailrecuperar.Text;

            email = email.Trim();

            if (email == "")
            {



            }
            else
            {

                Response.Redirect(string.Format("envia_email_v2.aspx?emailrecuperar={0}", emailrecuperar.Text));

            }



        }

        protected void lnkrecuperar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "senhaEsquecida();", true);
        }
    }
}