var studentStore = new Store<Student>();

studentStore.Add(new Student { Id = 1, Name = "Mohamed" });
studentStore.Add(new Student { Id = 2, Name = "Ahmed" });
studentStore.Add(new Student { Id = 3, Name = "Ali" });
studentStore.Add(new Student { Id = 4, Name = "Omar" });
studentStore.Add(new Student { Id = 5, Name = "Sara" });

var courseStore = new Store<Course>();

courseStore.Add(new Course
{
    Id = 1,
    Title = "C#",
    Price = 1500m
});

courseStore.Add(new Course
{
    Id = 2,
    Title = "SQL",
    Price = 1200m
});

courseStore.Add(new Course
{
    Id = 3,
    Title = "ASP.NET Core",
    Price = 2000m
});


Console.WriteLine("=== Get By Id ===");

var student = studentStore.GetById(3);

if (student != null)
    Console.WriteLine(
        $"Student: {student.Id} - {student.Name}");

var course = courseStore.GetById(2);

if (course != null)
    Console.WriteLine(
        $"Course: {course.Id} - {course.Title}");


Console.WriteLine();
Console.WriteLine("=== Duplicate Id ===");

try
{
    studentStore.Add(
        new Student { Id = 1, Name = "Duplicate" });
}
catch (InvalidOperationException ex)
{
    Console.WriteLine(ex.Message);
}


Console.WriteLine();
Console.WriteLine("=== Page 2, Size 2 ===");

foreach (var item in studentStore.GetAll().Values.Page(2, 2))
{
    Console.WriteLine(
        $"{item.Id} - {item.Name}");
}


Console.WriteLine();
Console.WriteLine("=== FindById on List<Course> ===");

var courses = new List<Course>
{
    new Course { Id = 10, Title = "Git", Price = 500m },
    new Course { Id = 20, Title = "Docker", Price = 1000m }
};

var foundCourse = courses.FindById(20);

if (foundCourse != null)
{
    Console.WriteLine(
        $"{foundCourse.Id} - {foundCourse.Title}");
}


// must NOT compile
// var invalidStore = new Store<string>();