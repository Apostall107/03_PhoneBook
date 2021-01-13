using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _03_PhoneBook
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection("Data Source=.;AttachDbFilename=DB_PhoneBook.mdf;Integrated Security=True");

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




    }
}
