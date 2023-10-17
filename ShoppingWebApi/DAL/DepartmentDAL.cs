using System;
using System.Data;
using System.Drawing;
using Npgsql;
using ShoppingWebApi.Models;

namespace ShoppingWebApi.DAL
{
	public class DepartmentDAL
	{

		private readonly IConfiguration _configuration;

		public DepartmentDAL(IConfiguration configuration)
		{
            _configuration = configuration;
		}

		public IEnumerable<Department> GetAllDepartments()
		{
			List<Department> departments = new List <Department>();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");

            using (NpgsqlConnection connection= new NpgsqlConnection(sqlDataSource))
			{
				connection.Open();
				using (NpgsqlCommand command = new NpgsqlCommand("get_all_departments", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					NpgsqlDataReader myReader = command.ExecuteReader();
					while (myReader.Read())
					{
						Department department = new Department();
						department.DepartmentId = Convert.ToInt32( myReader["departmentid"]);
						department.DepartmentName =  myReader["departmentname"].ToString();
						departments.Add(department );

                    }
                    myReader.Close();
                    connection.Close();
                }
			}
			return departments;

		}

	}
}

