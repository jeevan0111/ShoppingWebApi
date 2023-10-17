using System;
namespace ShoppingWebApi.Models
{
	public class Student
	{
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentGender { get; set; } = string.Empty;
        public int Age { get; set; } 
        public string Standard { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
    }
}

