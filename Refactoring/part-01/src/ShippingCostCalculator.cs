namespace RefactoringLab;

public interface IShippingCarrier
{
    string Name { get; }
    decimal CalculateCost(decimal weightKg);
}

public class AramexShippingCarrier : IShippingCarrier
{
    public string Name => "Aramex";

    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 12m;
    }
}

public class FedExShippingCarrier : IShippingCarrier
{
    public string Name => "FedEx";

    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 15m;
    }
}

public class DhlShippingCarrier : IShippingCarrier
{
    public string Name => "DHL";

    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 18m;
    }
}
public class UpsShippingCarrier : IShippingCarrier
{
    public string Name => "UPS";

    public decimal CalculateCost(decimal weightKg)
    {
        return weightKg * 20m;
    }
}

public class ShippingCostCalculator
{
    private readonly Dictionary<string, IShippingCarrier> _carriers;

    public ShippingCostCalculator(IEnumerable<IShippingCarrier> carriers)
    {
        _carriers = new Dictionary<string, IShippingCarrier>(
            StringComparer.OrdinalIgnoreCase);

        foreach (var carrier in carriers)
        {
            _carriers.Add(carrier.Name, carrier);
        }
    }

    public decimal Calculate(string carrier, decimal weightKg)
    {
        if (!_carriers.TryGetValue(carrier, out var shippingCarrier))
        {
            throw new ArgumentException($"Unknown carrier: {carrier}");
        }

        return shippingCarrier.CalculateCost(weightKg);
    }
}