public class HeartRate
{
    public int Value { get; }
    private const int MinHeartRate = 40;
    public HeartRate(int value, int age)
    {
        int maxHeartRate = 220 - age;
        if (value < MinHeartRate || value > maxHeartRate * 1.2)
            throw new ArgumentException($"Heart rate must be between {MinHeartRate} and {maxHeartRate * 1.2} for age {age}.");
        Value = value;
    }
}
