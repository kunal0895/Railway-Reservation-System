using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace RailwayReservationPart1
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select Customer_Uname,EMail_ID,Mobile_number,Gender from Customer,Person where Customer_Uname=Username and Customer_Uname=@cu";
                    if (Session["log_customer"].ToString() == "")
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cu", Session["log_customer"].ToString());
                        SqlDataReader rdr;
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Label1.Text = rdr["Customer_Uname"].ToString();
                            Label2.Text = rdr["EMail_ID"].ToString();
                            Label3.Text = rdr["Mobile_number"].ToString();
                            Label4.Text = rdr["Gender"].ToString();
                        }
                        con.Close();
                    }
                }
                catch (Exception edf)
                {
                    Label7.Text = edf.Message;
                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["log_customer"] = "";
            Response.Redirect("Login.aspx");
        }
    }
}