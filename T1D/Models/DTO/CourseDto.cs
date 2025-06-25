namespace T1D.Models.DTO;

public class CourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<StudentDto> Students { get; set; } = new();
}
