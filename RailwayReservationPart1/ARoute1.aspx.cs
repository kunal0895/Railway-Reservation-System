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
    public partial class ARoute1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox3.Text = Session["train_num"].ToString();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String source = TextBox1.Text;
            String dest = TextBox2.Text;

            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myconn;
            cmd.CommandText = "select Station_ID,Station_Name from Station_Table1 where Station_ID1 > (select Station_ID1 from Station_Table where Station_Name1 = @Station_Name) and Station_ID1 < (select Station_ID1 from Station_Table1 where Station_Name1 = @Station_Name1";
            cmd.Parameters.AddWithValue("@Station_Name",source);
            cmd.Parameters.AddWithValue("@Station_Name1", dest);
            
             
            try
            {
                myconn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Response.Redirect("AAvailable.aspx");
                myconn.Close();
            }
            catch
            {

            }
        }

    }
}