# Part 02 — Answers

---

## Reports

- What was the problem?

`CsvReportExporter`, `JsonReportExporter`, and `TextReportExporter` duplicated the same export workflow: load the data, validate it, format it, and save it. The only step that actually changed between exporters was the formatting logic.

- What did you change?

I created an abstract `ReportExporter` base class that contains the common `Export` workflow and the shared `Load`, `Validate`, and `Save` steps. I made `Format` an abstract method that each concrete exporter overrides with its own formatting logic.

- Why did you choose that approach?

I used the Template Method pattern because the exporters follow the same algorithm in the same order while only one step varies. This removes duplication while keeping the workflow defined in one place.

---

## Enrollment

- What was the problem?

`Program.cs` had to know about `PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, and `EmailService`, and it also had to know the correct order in which to call them to complete an enrollment.

- What did you change?

I created an `EnrollmentFacade` that coordinates the enrollment workflow. `Program.cs` now creates the facade and calls `Enroll`, while the facade handles charging the student, reserving the seat, creating the invoice, and sending the confirmation email.

- Why did you choose that approach?

I used the Facade pattern to provide a simple entry point to the enrollment subsystem and hide the coordination of its individual services from the caller.