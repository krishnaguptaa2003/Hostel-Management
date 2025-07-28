using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace hostelproject
{
    public partial class Rooms : Form
    {
        public Rooms()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='D:\C# Files\hostelproject\hostelproject.mdf';Integrated Security = True");
        void FillRoomDGV()
        {
            con.Open();
            string MYquery = "Select * from RoomTable";
            SqlDataAdapter da = new SqlDataAdapter(MYquery, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void Rooms_Load(object sender, EventArgs e)
        {
            FillRoomDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mainpage form = new Mainpage();
            form.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String roomstatus;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Fill the details");
            }
            else
            {
                if (RdbtnYes.Checked == true)
                   roomstatus = "Busy";
                else
                   roomstatus = "Free";

                con.Open();
                string query = "INSERT INTO RoomTable(SRno,RoomNum,Roomstatus,Booked)" + "VALUES(@SRno,@RoomNum,@Roomstatus,@Booked);";
                SqlCommand cmd1 = new SqlCommand(query, con);

                cmd1.Parameters.AddWithValue("@SRno", textBox1.Text);
                cmd1.Parameters.AddWithValue("@RoomNum",txtRoomNum.Text);
                cmd1.Parameters.AddWithValue("@Roomstatus",cmbRoomlist.Text);
                cmd1.Parameters.AddWithValue("@Booked",roomstatus);
               
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Room Successfully Added");
                con.Close();
                FillRoomDGV();

                string queary = "Select * From RoomTable";

                SqlDataAdapter apd = new SqlDataAdapter(queary, con);
                DataSet ds = new DataSet();
                apd.Fill(ds);
                RoomDGV.DataSource = ds.Tables[0];
                RoomDGV.AllowUserToAddRows = false;
            }
        }

        private void txtRoomNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String roomstatus1;
            if (txtRoomNum.Text == "")
            {
                MessageBox.Show("Enter the serial Number to update the list");
            }
            else
            {
                if (RdbtnYes.Checked == true)
                {
                    roomstatus1 = "Busy";
                }
                else
                {
                    roomstatus1 = "Free";
                }
                con.Open();

                string query5 = "UPDATE RoomTable SET SRno = @SRno, RoomNum = @RoomNum, Roomstatus = @Roomstatus, Booked = @Booked WHERE SRno = @SRno";
                SqlCommand cmd4 = new SqlCommand(query5, con);

                cmd4.Parameters.AddWithValue("@SRno", textBox1.Text);
                cmd4.Parameters.AddWithValue("@RoomNum", txtRoomNum.Text);
                cmd4.Parameters.AddWithValue("@Roomstatus", cmbRoomlist.Text);
                cmd4.Parameters.AddWithValue("@Booked", roomstatus1);

                cmd4.ExecuteNonQuery();
                MessageBox.Show("Room Successfully Updated");
                con.Close();
                FillRoomDGV();

                string queary = "Select * From RoomTable";

                SqlDataAdapter apd1 = new SqlDataAdapter(queary, con);
                DataSet ds2 = new DataSet();
                apd1.Fill(ds2);
                RoomDGV.DataSource = ds2.Tables[0];
                RoomDGV.AllowUserToAddRows = false;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Krish\source\repos\hostelproject\hostelproject.mdf;Integrated Security=True");
            string query = "DELETE FROM RoomTable WHERE SRno = @SRno ";
            SqlCommand cmd1 = new SqlCommand(query, con);

            cmd1.Parameters.AddWithValue("@SRno", textBox1.Text);
            con.Open(); 

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Room Successfully Deleted");
            con.Close();
            FillRoomDGV();
;
            string queary = "Select * From RoomTable";

            SqlDataAdapter apd = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            apd.Fill(ds);
            RoomDGV.DataSource = ds.Tables[0];
            RoomDGV.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = RoomDGV.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
