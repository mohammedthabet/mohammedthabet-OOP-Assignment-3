using RefactoringLab;

// Shipping
var shipping = new ShippingCostCalculator(
    new IShippingCarrier[]
    {
        new AramexShippingCarrier(),
        new FedExShippingCarrier(),
        new DhlShippingCarrier(),
        new UpsShippingCarrier()
    });

Console.WriteLine($"Aramex 2kg → {shipping.Calculate("Aramex", 2)}");
Console.WriteLine($"FedEx 2kg  → {shipping.Calculate("FedEx", 2)}");
Console.WriteLine($"UPS 2kg    → {shipping.Calculate("UPS", 2)}");

Console.WriteLine();

// Order processing
var repository = new SqlOrderRepository();
var emailSender = new SmtpEmailSender();

var processor = new OrderProcessor(
    repository,
    emailSender);

processor.Process(
    1001,
    "customer@example.com");

Console.WriteLine();

// Urgent + Scheduled Email
var urgentScheduledEmail = new Notification(
    new EmailNotificationChannel(),
    isUrgent: true,
    sendAt: DateTime.Today.AddHours(18));

urgentScheduledEmail.Send(
    "customer@example.com",
    "Your order ships tomorrow");

// Urgent SMS
var urgentSms = new Notification(
    new SmsNotificationChannel(),
    isUrgent: true);

urgentSms.Send(
    "+201000000000",
    "OTP 4821");

// New channel: Urgent + Scheduled Push
var urgentScheduledPush = new Notification(
    new PushNotificationChannel(),
    isUrgent: true,
    sendAt: DateTime.Today.AddHours(20));

urgentScheduledPush.Send(
    "device-123",
    "Your order is out for delivery");