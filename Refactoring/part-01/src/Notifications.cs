namespace RefactoringLab;

public interface INotificationChannel
{
    void Send(
        string to,
        string message,
        DateTime? sendAt = null);
}

public class EmailNotificationChannel : INotificationChannel
{
    public void Send(
        string to,
        string message,
        DateTime? sendAt = null)
    {
        if (sendAt.HasValue)
        {
            Console.WriteLine(
                $"[email scheduled {sendAt.Value:g}] {to}: {message}");
            return;
        }

        Console.WriteLine($"[email] {to}: {message}");
    }
}

public class SmsNotificationChannel : INotificationChannel
{
    public void Send(
        string to,
        string message,
        DateTime? sendAt = null)
    {
        if (sendAt.HasValue)
        {
            Console.WriteLine(
                $"[sms scheduled {sendAt.Value:g}] {to}: {message}");
            return;
        }

        Console.WriteLine($"[sms] {to}: {message}");
    }
}

public class Notification
{
    private readonly INotificationChannel _channel;
    private readonly bool _isUrgent;
    private readonly DateTime? _sendAt;

    public Notification(
        INotificationChannel channel,
        bool isUrgent = false,
        DateTime? sendAt = null)
    {
        _channel = channel;
        _isUrgent = isUrgent;
        _sendAt = sendAt;
    }

    public void Send(string to, string message)
    {
        var finalMessage = _isUrgent
            ? $"[URGENT] {message}"
            : message;

        _channel.Send(to, finalMessage, _sendAt);
    }
}

public class PushNotificationChannel : INotificationChannel
{
    public void Send(
        string to,
        string message,
        DateTime? sendAt = null)
    {
        if (sendAt.HasValue)
        {
            Console.WriteLine(
                $"[push scheduled {sendAt.Value:g}] {to}: {message}");
            return;
        }

        Console.WriteLine($"[push] {to}: {message}");
    }
}