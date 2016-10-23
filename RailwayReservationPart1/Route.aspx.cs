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
    public partial class Route_Avail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = Session["train_id1"].ToString();
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            
            try
            {
                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                String train_id1 = Session["train_id1"].ToString();
                cmd.CommandText = "select Train_ID,Station_Name,Arrival_Time,Departure_Time,Date,Distance from Train_Route where Train_ID = @Train_ID";
                cmd.Parameters.AddWithValue("@Train_ID", train_id1);

                SqlDataReader rdr;
                rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();

                con1.Close();
            }

            catch (Exception ed)
            {
                Label2.Text = ed.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx");
        }
    }
}