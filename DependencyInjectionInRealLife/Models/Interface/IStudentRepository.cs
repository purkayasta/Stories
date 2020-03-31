using Models.Models;
using System.Collections.Generic;

namespace Models.Interface
{
    public interface IStudentRepository
    {
        int GetRandomNumbers();
        List<Student> GetAllUsers();
    }
}
