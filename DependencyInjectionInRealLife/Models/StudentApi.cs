using System;
using Models.Interface;

namespace Models
{
    public class StudentApi
    {
        private static IStudentRepository _studentRepository;

        public StudentApi(IStudentRepository repository)
        {
            _studentRepository = repository;
        }

        public void Execute()
        {
            try
            {
                _studentRepository.GetAllUsers().ForEach(student =>
                {
                    Console.WriteLine(student.Id);
                    Console.WriteLine(student.Name);
                    Console.WriteLine(student.CreatedOn);
                });
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
