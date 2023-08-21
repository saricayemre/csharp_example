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

namespace loginpage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void login()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            string query = "SELECT * FROM admin where username=@username AND password=@password";
            con = new SqlConnection("server=.; Initial Catalog=dbname;Integrated Security=SSPI");
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txt_username.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.","Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.","Hatalı Giriş",MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            con.Close();
        }



        private void txt_username_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            txt_password.Clear();
            //txt_password.PasswordChar = '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
