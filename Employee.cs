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

namespace hostelproject
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename='D:\C# Files\hostelproject\hostelproject.mdf';Integrated Security = True");
        void FillEmpDGV()
        {
            con.Open();
            string MYquery = "Select * from EmployeeTable";
            SqlDataAdapter da = new SqlDataAdapter(MYquery, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            con.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Mainpage form1 = new Mainpage();
            form1.Show();
            this.Hide();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            FillEmpDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO EmployeeTable(EmployeeID,EmployeeName,EmpPhone,EmpAddress,EmpPosition,EmployeeStatus)" + "VALUES(@EmployeeID,@EmployeeName,@EmpPhone,@EmpAddress,@EmpPosition,@EmployeeStatus);";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query, con);

            cmd1.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text);
            cmd1.Parameters.AddWithValue("@EmployeeName", txtEmpName.Text);
            cmd1.Parameters.AddWithValue("@EmpPhone", txtPhone.Text);
            cmd1.Parameters.AddWithValue("@EmpAddress", txtAddress.Text);
            cmd1.Parameters.AddWithValue("@EmpPosition", cmbPosition.Text);
            cmd1.Parameters.AddWithValue("@EmployeeStatus", cmbEmpStatus.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Student Successfully Added");
            con.Close();
            FillEmpDGV();

            string queary = "Select * From EmployeeTable";

            SqlDataAdapter apd = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            apd.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            EmpDGV.AllowUserToAddRows = false;
        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpID.Text = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string id = EmpDGV.SelectedRows[0].Cells[0].Value.ToString();

            string query5 = "UPDATE EmployeeTable SET StudentID = " + id + ", EmployeeID = @EmployeeID, EmployeeName = @EmployeeName, EmpPhone = @EmpPhone, EmpAddress = @EmpAddress, EmpPosition = @EmpPosition, EmployeeStatus = @EmployeeStatus " + id;
            SqlCommand cmd1 = new SqlCommand(query5, con);

            cmd1.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text);
            cmd1.Parameters.AddWithValue("@EmployeeName", txtEmpName.Text);
            cmd1.Parameters.AddWithValue("@EmpPhone", txtPhone.Text);
            cmd1.Parameters.AddWithValue("@EmpAddress", txtAddress.Text);
            cmd1.Parameters.AddWithValue("@EmpPosition", cmbPosition.Text);
            cmd1.Parameters.AddWithValue("@EmployeeStatus", cmbEmpStatus.Text);

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Employee Successfully Updated");
            con.Close();
            FillEmpDGV();

            string queary = "Select * From EmployeeTable";

            SqlDataAdapter apd1 = new SqlDataAdapter(queary, con);
            DataSet ds2 = new DataSet();
            apd1.Fill(ds2);
            EmpDGV.DataSource = ds2.Tables[0];
            EmpDGV.AllowUserToAddRows = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Krish\source\repos\hostelproject\hostelproject.mdf;Integrated Security=True");
            string query = "DELETE FROM EmployeeTable WHERE EmployeeID = @EmployeeID ";
            SqlCommand cmd1 = new SqlCommand(query, con);

            cmd1.Parameters.AddWithValue("EmployeeID", txtEmpID.Text);
            con.Open();

            cmd1.ExecuteNonQuery();
            MessageBox.Show("Room Successfully Deleted");
            con.Close();
            FillEmpDGV();
            ;
            string queary = "Select * From EmployeeTable";

            SqlDataAdapter apd = new SqlDataAdapter(queary, con);
            DataSet ds = new DataSet();
            apd.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            EmpDGV.AllowUserToAddRows = false;
        }
    }
}
