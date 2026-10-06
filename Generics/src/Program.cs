var store = new StudentStore();

store.Add(new Student { Id = 1, Name = "Mohamed" });
store.Add(new Student { Id = 2, Name = "Ahmed" });

var student = store.GetById(2);

if (student != null)
    Console.WriteLine($"{student.Id}: {student.Name}");

store.Remove(1);

Console.WriteLine($"Students count: {store.GetAll().Count}");