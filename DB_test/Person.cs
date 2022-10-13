using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_test
{
    /// <summary>
    /// Класс человека из БД
    /// </summary>
    public class Person
    {
        public Person() {}

        public Person(string lastname, string firstname, string middlename, int id=0)
        {
            Id = id;
            Lastname = lastname;
            Firstname = firstname;
            Middlename = middlename;
        }

        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
    }
}
