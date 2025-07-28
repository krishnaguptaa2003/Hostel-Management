using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hostelproject
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='D:\C# Files\hostelproject\hostelproject.mdf';Integrated Security = True");
        void FillStudDGV()
        {
            con.Open();
            string MYquery = "Select * from StudentTable";
            SqlDataAdapter da = new SqlDataAdapter(MYquery, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            StudDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mainpage form1 = new Mainpage();
            form1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Student_Load(object sender, EventArgs e)
        {
            FillStudDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO StudentTable(StudentID,StudentName,FatherName,MotherName,Address,College,RoomNum,StudentStatus)" + "VALUES(@StudentID,@StudentName,@FatherName,@MotherName,@Address,@College,@RoomNum,@StudentStatus);";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query, con);

            cmd1.Parameters.AddWithValue("@StudentID", txtStudID.Text);
            cmd1.Parameters.AddWithValue("@StudentName", txtStudName.Text);
            cmd1.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
            cmd1.Parameters.AddWithValue("@MotherName", txtMotherName.Text);
            cmd1.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd1.Parameters.AddWithValue("@College", txtCollege.Text);
            cmd1.Parameters.AddWithValue("@RoomNum", StudRoomCMB.Text);
            cmd1.Parameters.AddWithValue("@StudentStatus", StudStatusCMB.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Student Successfully Added");
            con.Close();
            FillStudDGV();

            string queary = "Select * From StudentTable";

            SqlDataAdapter apd = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            apd.Fill(ds);
            StudDGV.DataSource = ds.Tables[0];
            StudDGV.AllowUserToAddRows = false;
        }

        private void StudDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtStudID.Text = StudDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Krish\source\repos\hostelproject\hostelproject.mdf;Integrated Security=True");
            string query = "DELETE FROM StudentTable WHERE StudentID = @StudentID ";
            SqlCommand cmd1 = new SqlCommand(query, con);

            cmd1.Parameters.AddWithValue("StudentID", txtStudID.Text);
            con.Open();

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Room Successfully Deleted");
            con.Close();
            FillStudDGV();
            ;
            string queary = "Select * From StudentTable";

            SqlDataAdapter apd = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            apd.Fill(ds);
            StudDGV.DataSource = ds.Tables[0];
            StudDGV.AllowUserToAddRows = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = StudDGV.SelectedRows[0].Cells[0].Value.ToString();

            string query5 = "UPDATE StudentTable SET StudentID = " + id + ", StudentName = @StudentName, FatherName = @FatherName, MotherName = @MotherName, Address = @Address, College = @College, RoomNum = @RoomNum, Studentstatus = @StudentStatus WHERE StudentID =  " + id;
            SqlCommand cmd1 = new SqlCommand(query5, con);

            cmd1.Parameters.AddWithValue("@StudentID", txtStudID.Text);
            cmd1.Parameters.AddWithValue("@StudentName", txtStudName.Text);
            cmd1.Parameters.AddWithValue("@FatherName", txtFatherName.Text);
            cmd1.Parameters.AddWithValue("@MotherName", txtMotherName.Text);
            cmd1.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd1.Parameters.AddWithValue("@College", txtCollege.Text);
            cmd1.Parameters.AddWithValue("@RoomNum", StudRoomCMB.Text);
            cmd1.Parameters.AddWithValue("@StudentStatus", StudStatusCMB.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Student Successfully Updated");
            con.Close();
            FillStudDGV();

            string queary = "Select * From StudentTable";

            SqlDataAdapter apd1 = new SqlDataAdapter(queary, con);
            DataSet ds2 = new DataSet();
            apd1.Fill(ds2);
            StudDGV.DataSource = ds2.Tables[0];
            StudDGV.AllowUserToAddRows = false;
        }
    }
}
