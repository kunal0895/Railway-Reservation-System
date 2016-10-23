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
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["log_customer"].ToString() != "")
                {
                    
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != TextBox2.Text)
            {
                String dateinString = TextBox3.Text.ToString();
                DateTime startDate = DateTime.Now;
                DateTime maxDate = startDate.AddDays(30);
                DateTime cDate = DateTime.Parse(dateinString);
                if (cDate > maxDate)
                {
                    Label2.Text = "Select a proper date";
                }
                else
                {
                    Label2.Text = "";
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DHIREN\documents\visual studio 2015\Projects\RailwayReservationPart1\RailwayReservationPart1\App_Data\Other25.mdf;Integrated Security=True";
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;

                        cmd.CommandText = "select S.Train_ID,Train_Name,D.Station_Name,D.Departure_Time,S.Station_Name,S.Arrival_Time,S.Date,S.Distance-D.Distance AS Distance from Train_Route as S,Train_Route as D,Train_Details where S.Train_ID = D.Train_ID and S.Train_ID=Train_num and D.Train_ID=Train_num and D.Value < S.Value and D.Station_Name = '" + TextBox1.Text + "' and S.Station_Name = '" + TextBox2.Text + "' and S.Date=@Date";
                        cmd.Parameters.AddWithValue("@Date", TextBox3.Text.ToString());

                        SqlDataReader rdr;
                        rdr = cmd.ExecuteReader();
                        GridView1.DataSource = rdr;
                        GridView1.DataBind();

                        con.Close();
                    }
                    catch (Exception edf)
                    {
                        Label2.Text = edf.Message;
                    }
                }
            }
            else
            {
                Label2.Text = "Source and Destination stations cannot be same.";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectTrain")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TextBox4.Text = GridView1.SelectedRow.Cells[1].Text;
            if (GridView1.SelectedIndex != -1)
            {
                Label7.Text = "";
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue!=null)
            {
                Label7.Text = "";
                Session["train_id1"] = GridView1.SelectedRow.Cells[1].Text;
                Label7.Text = "";
                Response.Redirect("Route.aspx");
            }
            else
            {
                Label7.Text = "Please select the Train.";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedItem.Text !="-----" && GridView1.SelectedValue != null)
            {
                Session["distance"] = GridView1.SelectedRow.Cells[8].Text;
                Session["type"] = DropDownList1.SelectedItem.Text;
                Session["train_id"] = GridView1.SelectedRow.Cells[1].Text;

                //For Book.aspx Page.
                Session["train_name"] = GridView1.SelectedRow.Cells[2].Text;
                Session["dep_station"] = GridView1.SelectedRow.Cells[3].Text;
                Session["dep_time"] = GridView1.SelectedRow.Cells[4].Text;
                Session["source_station"] = GridView1.SelectedRow.Cells[5].Text;
                Session["arr_time"] = GridView1.SelectedRow.Cells[6].Text;
                Session["date"] = GridView1.SelectedRow.Cells[7].Text;

                Label7.Text = "";
                Response.Redirect("Availability.aspx");
               
            }
            else if (GridView1.SelectedValue == null)
            {
                Label7.Text = "Please select the Train.";
            }

            else if (GridView1.SelectedValue!=null && DropDownList1.SelectedItem.Text == "-----")
            {
                Label7.Text = "Please select class.";
            }
            else
            {
                Label7.Text = "";
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            int rowcount = GridView1.Rows.Count;
            if(rowcount==0)
            {
                Label8.Text = "Sorry!!!No Trains are Available";
                GridView1.Visible = false;
                Button2.Visible = false;
                Button3.Visible = false;
                Label6.Visible = false;
                DropDownList1.Visible = false;
                Label3.Visible = false;
                Label7.Visible = false;

            }
            else
            {
                Label8.Text = "";
                GridView1.Visible = true;
                Button2.Visible = true;
                Button3.Visible = true;
                Label6.Visible = true;
                DropDownList1.Visible = true;
                Label3.Visible = true;
                Label7.Visible = true;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedItem.Text!="-----")
            {
                Label7.Text = "";
            }
        }
    }
}