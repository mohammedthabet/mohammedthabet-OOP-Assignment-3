namespace RefactoringLab.Part02.Enrollment;

public class EnrollmentFacade
{
    private readonly PaymentGateway _payment;
    private readonly SeatInventory _seats;
    private readonly InvoiceGenerator _invoices;
    private readonly EmailService _email;

    public EnrollmentFacade(
        PaymentGateway payment,
        SeatInventory seats,
        InvoiceGenerator invoices,
        EmailService email)
    {
        _payment = payment;
        _seats = seats;
        _invoices = invoices;
        _email = email;
    }

    public void Enroll(
        string studentId,
        string courseId,
        decimal amount)
    {
        _payment.Charge(studentId, amount);
        _seats.Reserve(courseId, studentId);

        var invoiceId = _invoices.Create(
            studentId,
            amount);

        _email.Send(
            studentId,
            "Enrollment confirmed",
            $"Invoice {invoiceId} for {courseId}");
    }
}