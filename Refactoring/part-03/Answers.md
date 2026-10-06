# Part 03 — Answers

---

## BlockedUsers

- Time complexity before: O(n × m)
- Time (ms) before: 23 ms
- What did you change?

I replaced the `List<int>` used for blocked user IDs with a `HashSet<int>`. The code performs many membership checks, so `HashSet.Contains` is more appropriate than `List.Contains`.

- Time complexity after: O(n + m) average
- Time (ms) after: 0 ms

---

## Students

- What was the problem?

`GetAllStudents` eagerly created a list containing 1,000,000 `Student` objects even though the caller only needed the first three students. This caused unnecessary memory allocation and work.

- What did you change?

I changed `GetAllStudents` to return `IEnumerable<Student>` and used `yield return`. Students are now created lazily as they are requested, so when the loop stops after three students, the remaining students are never created.