# Part 01 — Answers

---

## ShippingCostCalculator

- What was the problem?

`ShippingCostCalculator` used a switch statement with hard-coded carrier names and rates. Adding a new carrier required modifying the existing calculator, which violated the Open/Closed Principle.

- What did you change?

I created an `IShippingCarrier` interface and moved each carrier's calculation logic into its own implementation. `ShippingCostCalculator` now receives the available carriers through constructor injection and looks them up by name. A new carrier can now be added without modifying the calculator.

---

## OrderProcessor

- What was the problem?

`OrderProcessor` created `SqlOrderRepository` and `SmtpEmailSender` directly inside `Process`, which made it tightly coupled to those concrete implementations.

- What did you change?

I introduced `IOrderRepository` and `IEmailSender` abstractions and injected them through the `OrderProcessor` constructor. `SqlOrderRepository` and `SmtpEmailSender` implement those interfaces, while `Program.cs` is responsible for creating and wiring the dependencies.

---

## Notifications

- What was the problem?

The notification design used inheritance for every combination of channel and behavior, such as urgent email and urgent scheduled email. Adding more channels or behaviors would require more subclasses and cause the inheritance tree to keep growing.

- What did you change?

I replaced the inheritance hierarchy with composition. `Notification` receives an `INotificationChannel`, while urgency and scheduling are configured independently. Email, SMS, and new channels can therefore be urgent, scheduled, or both without creating a separate class for every combination.

---

## Proof

- New carrier file(s): `src/ShippingCostCalculator.cs` — `UpsShippingCarrier`
- New notification channel file(s): `src/Notifications.cs` — `PushNotificationChannel`
- Existing classes left unchanged? (yes/no): yes