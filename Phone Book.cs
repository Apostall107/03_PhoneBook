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

namespace _03_PhoneBook
{
    public partial class Form1 : Form
    {
        private static string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Apostall107\source\repos\PET\03_PhoneBook\PhoneBookDB.mdf;Integrated Security=True";
        SqlConnection connection = new SqlConnection(str);


        void ResetTextFields()
        {
            First_Name_txt.Clear();
            Last_Name_txt.Clear();
            Email_txt.Clear();
            PhNum_txt.Clear();
            Categoty_box.SelectedIndex = -1;

            First_Name_txt.Focus();

        }


        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from PhoneBookTable ", connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }


        public Form1()
        {
            InitializeComponent();
            Display();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {

            ResetTextFields();

        }




        private void Add_Button_Click(object sender, EventArgs e)
        {
            connection.Open();//SqlDataAdapter has no need in opening/closing con

            SqlCommand cmd;
            var cmdText = @"INSERT INTO  PhoneBookTable(FirstName, LastName, EMail , PhNum, Category )  
                             VALUES ('"
                          + First_Name_txt.Text
                          + "' , '"
                          + Last_Name_txt.Text
                          + "' , '"
                          + Email_txt.Text
                          + "','"
                          + PhNum_txt.Text
                          + "','"
                          + Categoty_box.Text
                          + "')";
            cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery(); ;


            connection.Close();//SqlDataAdapter has no need in opening/closing con

            MessageBox.Show("Succssfully added!");


            ResetTextFields();
            Display();

        }
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            connection.Open();//SqlDataAdapter has no need in opening/closing con

            SqlCommand cmd;
            var cmdText = @"DELETE FROM PhoneBookTable    WHERE  ( PhNum = '" + PhNum_txt.Text + "' ) ";
            cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery(); ;


            connection.Close();//SqlDataAdapter has no need in opening/closing con

            MessageBox.Show("Succssfully deleted!");


            ResetTextFields();
            Display();

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            First_Name_txt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Last_Name_txt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Email_txt.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PhNum_txt.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Categoty_box.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            connection.Open();//SqlDataAdapter has no need in opening/closing con

            SqlCommand cmd;
            var cmdText = @"UPDATE  PhoneBookTable
                          SET
                          FirstName =  '" + First_Name_txt.Text + "'," +
                          "LastName = '" + Last_Name_txt.Text + "'," +
                          "EMail = '" + Email_txt.Text + "'," +
                          "Category = '" + Categoty_box.Text + "' " +
                          "     WHERE  (PhNum =  '" + PhNum_txt.Text + "')";


            cmd = new SqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery(); ;


            connection.Close();//SqlDataAdapter has no need in opening/closing con

            MessageBox.Show("Succssfully updated!");


            ResetTextFields();
            Display();
        }

        private void Search_txt_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda;
            string str = @"Select * from PhoneBookTable 
                              WHERE (FirstName LIKE '%" + Search_txt.Text + "%')  " +
                              "or(LastName LIKE '%" + Search_txt.Text + "%')  " +
                              "or (EMail LIKE '%" + Search_txt.Text + "%')  " +
                              "or (PhNum LIKE '%" + Search_txt.Text + "%') " +
                              "or (Category LIKE '%" + Search_txt.Text + "%')";
            sda = new SqlDataAdapter(str, connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }


        }
    }
}
