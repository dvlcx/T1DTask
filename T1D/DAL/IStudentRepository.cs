using T1D.Models;

namespace T1D.DAL;

public interface IStudentRepository
{
    Task<Student> AddAsync(Student student);
}