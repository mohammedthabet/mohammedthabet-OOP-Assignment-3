# Generics — Answers

## Step 2

### What is the same between the two stores?

Both `StudentStore` and `CourseStore` use a `List` to store items and implement the same four operations: `Add`, `GetById`, `GetAll`, and `Remove`. Both also search for an item by its `Id`.

### What is different?

The main difference is the type they store. `StudentStore` works with `Student` objects, while `CourseStore` works with `Course` objects. The entity classes also contain different properties besides their common `Id`.