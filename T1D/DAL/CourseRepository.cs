using Microsoft.EntityFrameworkCore;
using T1D.Models;

namespace T1D.DAL;

public class CourseRepository :  ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses.Include(c => c.Students).ToListAsync();
    }
    
    public async Task<IEnumerable<Course>> GetAllWithStudentsAsync()
    {
        return await _context.Courses
            .Include(c => c.Students)
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(Guid id)
    {
        return await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Course> AddAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course;
    }

    public async Task DeleteAsync(Guid id)
    {
        var course = await GetByIdAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _context.Courses.AnyAsync(c => c.Id == id);
    }
}