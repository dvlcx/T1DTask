using System.Runtime.InteropServices;

namespace T1D.Models;

public class Student
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}