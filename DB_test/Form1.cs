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
        private List<Person> people;

        public Form1()
        {
            InitializeComponent();

            people = new List<Person>();

            using (var db = new Db())
            {
                Reload(db);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var db = new Db())
            {
                db.AddPerson("Сидоров", "Петр", "Сидорович");
                Reload(db);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idx = gridClients.CurrentCell.RowIndex;
            int id = people[idx].Id;
            
            using (var db = new Db())
            {
                db.DeletePerson(id);
                Reload(db);
            }
        }

        // Загрузить данные и отобразить их в таблице
        private void Reload(Db db)
        {
            people = db.GetPeople();
            gridClients.DataSource = people;
        }
    }
}
