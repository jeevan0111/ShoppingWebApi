using System;
using Npgsql;
using ShoppingWebApi.Models;
using System.Data;

namespace ShoppingWebApi.DAL
{
	public class StudentDAL
	{
		private readonly IConfiguration _configuration;

		public StudentDAL(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public IEnumerable<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("get_all_studentss", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    NpgsqlDataReader myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        Student student = new Student();
                        student.Id = Convert.ToInt32(myReader["id"]);
                        student.StudentName = myReader["studentname"].ToString();
                        student.StudentGender = myReader["studentgender"].ToString();
                        student.Age = Convert.ToInt32(myReader["age"]);
                        student.Standard = myReader["standard"].ToString();
                        student.FatherName = myReader["fathername"].ToString();
                        students.Add(student);

                    }
                    myReader.Close();
                    connection.Close();
                }
            }
            return students;

        }
    }
}

