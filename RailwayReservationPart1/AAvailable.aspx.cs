using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;

namespace RailwayReservationPart1
{
    public partial class AAvailable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["un"].ToString() == "")
            //{
            //    Response.Redirect("ALogin.aspx");
            //}
            TextBox1.Text=Session["train_num"].ToString();
            TextBox4.Text = Session["train_name"].ToString();

            if (GridView1.Rows.Count==0)
            {
                //GridView1.Visible = false;
                Button2.Visible = true;
                Label2.Visible = false;
            }
            else if(GridView1.Rows.Count>=0 && GridView1.Rows.Count<4)
            {
                Button2.Visible = true;
                Label2.Visible = true;
                //GridView1.Visible = true;

            }
            else
            {
                Button1.Visible = false;
                Button2.Visible = false;
                Label3.Visible = false;
                Label4.Visible = false;
                DropDownList1.Visible = false;
                TextBox3.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedItem.Text == "-----" || TextBox3.Text=="")
            {
                Label6.Text = "Empty values not allowed.";
            }
            else
            {
                Label6.Text = "";
                SqlConnection myconn = new SqlConnection();
                myconn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = myconn;
                cmd.CommandText = "insert into Seat_Availability values('"+TextBox1.Text+"','"+TextBox4.Text+"','"+DropDownList1.SelectedItem.Text+"','"+TextBox3.Text+"')";
                
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Button1.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            TextBox3.Visible = true;
            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myconn;
            cmd.CommandText = "select Type from Seat_Availability where Train_ID='" + TextBox1.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsPubs = new DataSet();
            try
            {
                myconn.Open();
                adapter.Fill(dsPubs, "Seat_Availability");
                foreach (DataRow row in dsPubs.Tables["Seat_Availability"].Rows)
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = row["Type"].ToString();
                    DropDownList1.Items.Remove(newItem);
                }
            }
            catch
            {

            }
            DropDownList1.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("ATrain.aspx");
        }

        protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            Response.Redirect("AAvailable.aspx");
        }
    }
}