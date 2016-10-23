using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RailwayReservationPart1
{
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["log_customer"].ToString() == "")
                {
                   
                }
            }
            catch
            {
                Response.Redirect("Login.aspx");
            }
            if (GridView1.Rows.Count == 0)
            {
                Label1.Text = "No Bookings yet.";
                Button1.Visible = false;
                Button3.Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex != -1)
            {
                Label2.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Label2.Text = "";
                Session["pnr_number"] = GridView1.SelectedRow.Cells[1].Text;
                Response.Redirect("Ticket.aspx");
            }
            else
            {
                Label2.Text = "Please select a booking.";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedValue != null)
            {
                Label2.Text = "";
                //Session["pnr_number"] = GridView1.SelectedRow.Cells[1].Text;
                //Response.Redirect("Cancel.aspx");
            }
            else
            {
                Label2.Text = "Please select a booking.";
            }
        }
    }
}