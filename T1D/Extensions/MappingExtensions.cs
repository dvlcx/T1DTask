using T1D.Models;
using T1D.Models.DTO;

namespace T1D.Extensions;

public static class MappingExtensions
{
    public static CourseDto ToDto(this Course course)
    {
        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            Students = course.Students?.Select(s => s.ToDto()).ToList() ?? new()
        };
    }

    public static StudentDto ToDto(this Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            FullName = student.FullName
        };
    }
}