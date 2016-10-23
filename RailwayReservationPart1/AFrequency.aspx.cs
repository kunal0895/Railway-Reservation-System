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
    public partial class AFrequency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Text = "";
            Label8.Text = "";
            Label2.Text = Session["train_num"].ToString();
            Label4.Text = Session["train_name"].ToString();
            if (GridView1.Rows.Count == 0)
            {
                Button1.Visible = false;
            }
            if (DropDownList1.SelectedItem.Text == "-----")
            {
                Button2.Visible = false;
            }
            else
            {
                Button2.Visible = true;
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dsPubs = new DataSet();
            try
            {
                con.Open();
                cmd.CommandText = "select Day from Train_Frequency where Train_Num='"+Session["train_num"].ToString() + "'";

                adapter.Fill(dsPubs, "Train_Frequency");
                foreach (DataRow row in dsPubs.Tables["Train_Frequency"].Rows)
                {
                    ListItem newItem = new ListItem();
                    newItem.Text = row["Day"].ToString();
                    DropDownList1.Items.Remove(newItem);
                }

            }
            catch (Exception edf)
            {
                Label5.Text = edf.Message;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataReader rdr;

            if (DropDownList1.SelectedItem.Text == "-----")
            {
                Label7.Text = "Please select proper day to insert.";
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.CommandText = "insert into Train_Frequency values('" + Session["train_num"].ToString() + "','" + DropDownList1.SelectedItem.Text + "')";
                    rdr = cmd.ExecuteReader();

                    con.Close();
                }
                catch (Exception edf)
                {
                    Label5.Text = edf.Message;
                }
                Response.Redirect("AFrequency.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            SqlDataReader rdr;
            if (GridView1.SelectedRow == null)
            {
                Label8.Text = "Please select a proper day to remove.";
            }
            else
            {
                try
                {
                    con.Open();

                    cmd.CommandText = "delete from Train_Frequency where Train_Num='" + Session["train_num"].ToString() + "' and Day='" + Session["day"].ToString() + "'";
                    rdr = cmd.ExecuteReader();

                    con.Close();
                }
                catch (Exception edf)
                {
                    Label6.Text = edf.Message;
                }
                ListItem newItem = new ListItem();
                newItem.Text = Session["day"].ToString();
                newItem.Value = Session["day"].ToString();
                DropDownList1.Items.Add(newItem);
                Response.Redirect("AFrequency.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label7.Text = "";
            Session["day"] = GridView1.SelectedRow.Cells[1].Text;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text == "-----")
            {
                Button2.Visible = false;
            }
            else
            {
                Button2.Visible = true;
            }
        }
    }
}