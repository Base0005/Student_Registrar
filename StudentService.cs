namespace Registrar.Services;
using MySql.Data.MySqlClient;
using System;
using Dapper;
    public class StudentService
    {
        private string ConnectionString = "Server=localhost;Database=Registrar;Uid=root;Pwd=;Charset=utf8;Port=3306;SslMode=none";

        public async Task<List<Student>> DisplayStudent()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Student";
                var students = await connection.QueryAsync<Student>(query);
                return students.ToList();
            }
        }
    }


    public class CurrentStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
    }

