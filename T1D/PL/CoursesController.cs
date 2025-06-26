using Microsoft.AspNetCore.Mvc;
using T1D.DAL;
using T1D.Extensions;
using T1D.Models;
using T1D.Models.DTO;

namespace T1D.PL;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : Controller
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    
    
    public CoursesController(ICourseRepository courseRepository, IStudentRepository studentRepository)
    {
        this._courseRepository = courseRepository;
        this._studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _courseRepository.GetAllWithStudentsAsync();
        var courseDtos = courses.Select(c => c.ToDto()).ToList();
        
        return Ok(courseDtos);
    }
    
    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(CourseCreateDto courseDto)
    {
        var course = new Course
        {
            Id = Guid.NewGuid(),
            Name = courseDto.Name
        };

        await _courseRepository.AddAsync(course);
        return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, new { id = course.Id });
    }

    [HttpPost("{id}/students")]
    public async Task<ActionResult<Student>> AddStudentToCourse(Guid id, StudentCreateDto studentDto)
    {
        var courseExists = await _courseRepository.ExistsAsync(id);
        if (!courseExists)
        {
            return NotFound();
        }

        var student = new Student
        {
            Id = Guid.NewGuid(),
            FullName = studentDto.FullName,
            CourseId = id
        };

        await _studentRepository.AddAsync(student);

        return Ok(new { id = student.Id });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        var courseExists = await _courseRepository.ExistsAsync(id);
        if (!courseExists)
        {
            return NotFound();
        }

        await _courseRepository.DeleteAsync(id);

        return NoContent();
    }
}