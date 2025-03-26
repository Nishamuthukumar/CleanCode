public class Temperature
{
    public double Value { get; }
    private const double MinTemperature = 34;
    private const double MaxTemperature = 42;
    public Temperature(double value)
    {
        if (value < MinTemperature || value > MaxTemperature)
            throw new ArgumentException($"Temperature must be between {MinTemperature} and {MaxTemperature}.");
        Value = value;
    }
}
