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

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Study\\7_semester\\Введение в разработку ПО\\lab1\\DB_test\\DB_test\\DB_test\\DbLab1.mdf\";Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            Reload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var sql = "insert into People (Lastname, Firstname, Middlename) values ('Сидоров', 'Петр', 'Сидорович')";
            ExecCommand(sql);
            Reload();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = gridClients.CurrentRow.Cells[0].Value.ToString();
            var sql = $"delete from People where id = {id}";
            ExecCommand(sql);
            Reload();
        }

        // Устанавливает подключение к БД
        private SqlConnection Connect()
        {
            var cnn = new SqlConnection(connectionString);
            cnn.Open();
            return cnn;
        }

        // Загрузить данные и отобразить их в таблице
        private void Reload()
        {
            var cnn = Connect();
            var da = new SqlDataAdapter("select * from People", cnn);
            var ds = new DataSet();
            da.Fill(ds);
            gridClients.DataSource = ds.Tables[0];
            cnn.Close();
        }

        // Выполняет SQL запроч
        private void ExecCommand(string sql)
        {
            var cnn = Connect();
            var cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }
    }
}
