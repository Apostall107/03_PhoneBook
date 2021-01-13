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

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)/MSSQLLocalDB;AttachDbFilename=C:/Users/Apostall107/Documents/PhoneBookDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {

            First_Name_txt.Clear();
            Last_Name_txt.Clear();
            Email_txt.Clear();
            PhNum_txt.Clear();
            Categoty_box.SelectedIndex = -1;

            First_Name_txt.Focus();//place cursor on 1st name textbox

        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            connection.Open();//SqlDataAdapter has no need in opening/closing con

            SqlCommand cmd = new SqlCommand($"INSERT INTO  DB_PhineBook(First Name, Last Name, E-Mail,Ph.Num, Category)" +
                $" VALUES ( {First_Name_txt.Text} , {Last_Name_txt.Text} , {Email_txt.Text} , {PhNum_txt.Text} , {Categoty_box.Text} )" );
            cmd.ExecuteNonQuery();


            connection.Close();//SqlDataAdapter has no need in opening/closing con

            

        }
    }
}
