using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DB_test
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public class Db : IDisposable
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Study\\7_semester\\Введение в разработку ПО\\lab1\\DB_test\\DB_test\\DB_test\\DbLab1.mdf\";Integrated Security=True";
        private SqlConnection cnn;

        public Db()
        {
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        /// <summary>
        /// Возвращает список всех людей в базе
        /// </summary>
        public List<Person> GetPeople()
        {
            var da = new SqlDataAdapter("select * from People", cnn);
            var ds = new DataSet();
            da.Fill(ds);
            var tablePeople = ds.Tables[0];

            var people = new List<Person>();
            
            foreach(DataRow row in tablePeople.Rows)
            {
                var newPerson = new Person(
                    (int)row["Id"], (string)row["Lastname"],
                    (string)row["Firstname"], (string)row["Middlename"]);
                people.Add(newPerson);
            }

            return people;
        }

        /// <summary>
        /// Добавляет новую запись о человеке в базу
        /// </summary>
        public void AddPerson(string Lastname, string Firstname, string Middlename)
        {
            var sql = $"insert into People (Lastname, Firstname, Middlename) values (N'{Lastname}', N'{Firstname}', N'{Middlename}')";
            ExecCommand(sql);
        }

        /// <summary>
        /// Удаляет человека из базы
        /// </summary>
        /// <param name="id">ID человека</param>
        public void DeletePerson(int id)
        {
            var sql = $"delete from People where id = {id}";
            ExecCommand(sql);
        }

        // Выполняет SQL запроч
        private void ExecCommand(string sql)
        {;
            var cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();

        }

        public void Dispose()
        {
            if (cnn != null)
                cnn.Close();
        }
    }
}
