using Models.Interface;
using Models.Models;
using System;
using System.Collections.Generic;

namespace Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private const int MinValue = 1;

        public List<Student> GetAllUsers()
        {
            return new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Pritom",
                    CreatedOn = DateTime.Now
                },
                new Student
                {
                    Id = 2,
                    Name = "Purkayasta",
                    CreatedOn = DateTime.Now
                }
            };
        }

        public int GetRandomNumbers()
        {
            return new Random().Next(MinValue, 13);
        }
    }
}
