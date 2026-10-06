var store = new StudentStore();

store.Add(new Student { Id = 1, Name = "Mohamed" });
store.Add(new Student { Id = 2, Name = "Ahmed" });

var student = store.GetById(2);

if (student != null)
    Console.WriteLine($"{student.Id}: {student.Name}");

store.Remove(1);

Console.WriteLine($"Students count: {store.GetAll().Count}");

var courseStore = new CourseStore();

courseStore.Add(new Course
{
    Id = 1,
    Title = "C#",
    Price = 1500m
});

var course = courseStore.GetById(1);

if (course != null)
    Console.WriteLine($"{course.Id}: {course.Title} - {course.Price}");