using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Autocom3_Cotacao
{
    public partial class menu_cotacoes : System.Web.UI.Page
    {

        string conecta = ConfigurationManager.ConnectionStrings["conecta"].ConnectionString;

        public void BindGrid()
        {

            using (SqlConnection con = new SqlConnection(conecta))
            {

                con.Open();
                DataTable dt = new DataTable();
                SqlTransaction trann;
                trann = con.BeginTransaction();
                try
                {

                    using (SqlCommand cmd = new SqlCommand("SE_COTACOES_MASTER", con, trann))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("codmatriz", SqlDbType.VarChar);
                        cmd.Parameters["codmatriz"].Value = Session["codmatriz"];
                        cmd.Parameters["codmatriz"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("codfor", SqlDbType.VarChar);
                        cmd.Parameters["codfor"].Value = Session["codfor"];
                        cmd.Parameters["codfor"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("msg", SqlDbType.VarChar);
                        cmd.Parameters["msg"].Value = "";
                        cmd.Parameters["msg"].Direction = ParameterDirection.Output;

                        string msg = cmd.Parameters["msg"].Value.ToString();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        cmd.Connection.Close();
                        cmd.Dispose();
                        da.Fill(dt);

                        if (msg != "")
                        {

                        }
                        else
                        {

                            if (dt.Rows.Count == 0)
                            {
                                gridCotacao.DataSource = dt;
                                gridCotacao.DataBind();
                            }
                            else
                            {
                                gridCotacao.DataSource = dt;
                                gridCotacao.DataBind();
                            }

                        }


                    }

                }
                catch (Exception)
                {

                    throw;
                }

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


            }

            Session.Remove("vrfrete");
            Session.Remove("condpagt");


            BindGrid();


        }

        public static string imgStatus(string value)
        {
            if (value == "A")
            {
                return "../Images/act_green.gif";
            }
            else
            {
                return "../Images/act_red.jpg";
            }
        }

        protected void gridCotacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label labelstatus = (Label)e.Row.FindControl("lblStatus"); 
                DateTime finaliza = Convert.ToDateTime(DateTime.Parse(e.Row.Cells[11].Text).ToShortDateString());
                DateTime hoje = DateTime.Today;
                string status = Convert.ToString(e.Row.Cells[10].Text);
                string status_for = Convert.ToString(e.Row.Cells[5].Text);

                if ((hoje < finaliza) && (status == "A"))
                {
                labelstatus.Text = "<i class=\"fad fa-smile-wink fa-4x\"></i>";
                }
                else
                {
                    if ((hoje == finaliza) && (status_for != "E"))
                    {
                        labelstatus.Text = "<i class=\"fad fa-surprise fa-4x\"></i>";
                    }
                    else
                    {
                        if ((hoje > finaliza) || (status_for == "E"))
                        {
                            labelstatus.Text = "<i class=\"fad fa-sad-tear fa-4x\"></i>";
                        }
                    }
                }
            }

        }

        protected void gridCotacao_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gridCotacao.PageIndex = e.NewPageIndex;

            BindGrid();

        }
    }
}