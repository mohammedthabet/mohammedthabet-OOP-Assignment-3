public class StudentStore
{
    private readonly List<Student> _students = new();

    public void Add(Student student)
    {
        _students.Add(student);
    }

    public Student? GetById(int id)
    {
        foreach (var student in _students)
        {
            if (student.Id == id)
                return student;
        }

        return null;
    }

    public List<Student> GetAll()
    {
        return _students;
    }

    public void Remove(int id)
    {
        Student? studentToRemove = null;

        foreach (var student in _students)
        {
            if (student.Id == id)
            {
                studentToRemove = student;
                break;
            }
        }

        if (studentToRemove != null)
            _students.Remove(studentToRemove);
    }
}