using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace RailwayReservationPart1
{
    public partial class ALogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["un"] = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(*) from Admin,Person where Admin_Uname=Username and Admin_Uname='"+TextBox1.Text+"' and Password='"+TextBox2.Text+"'";

                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    Session["un"] = TextBox1.Text;
                    Response.Redirect("AHome.aspx");
                }
                else
                {
                    Label1.Text = "Enter correct username and password.";
                    TextBox1.Text = "";
                }
                con.Close();
            }
            catch (Exception edf)
            {
                Label1.Text = edf.Message;
            }
        }
    }
}