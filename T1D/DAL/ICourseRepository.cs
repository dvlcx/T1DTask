using T1D.Models;

namespace T1D.DAL;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<IEnumerable<Course>> GetAllWithStudentsAsync();
    Task<Course?> GetByIdAsync(Guid id);
    Task<Course> AddAsync(Course course);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}