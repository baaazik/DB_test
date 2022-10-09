using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Study\\7_semester\\Введение в разработку ПО\\lab1\\DB_test\\DB_test\\DB_test\\DbLab1.mdf\";Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from People", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source = People.sdf");
            cnn.Open();
            SqlCommand cmd = new SqlCommand(
                "insert into People (Lastname, Firstname, Middlename) values ('Сидоров', 'Петр', 'Сидорович')", cnn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter("select * from People", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source = People.sdf");
            cnn.Open();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand(
                "delete from People where id = " + id, cnn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter("select * from People", cnn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cnn.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

     }
}
