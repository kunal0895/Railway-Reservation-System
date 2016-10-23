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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["log_customer"] = "";
            //TextBox1.Text = "";
            //TextBox2.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select count(*) from Customer,Person where Customer_Uname=Username and Customer_Uname='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'";
                
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                if(count > 0 )
                {
                    Session["log_customer"] = TextBox1.Text;
                    Response.Redirect("Account.aspx");
                }
                else
                {
                    Label2.Text = "Enter correct username and password.";
                    TextBox1.Text = "";
                } 
                con.Close();
            }
            catch (Exception edf)
            {
                Label2.Text = edf.Message;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}