public class BloodPressure
{
    public int Systolic { get; }
    public int Diastolic { get; }
    private const int MinSystolic = 70;
    private const int MaxSystolic = 200;
    private const int MinDiastolic = 40;
    private const int MaxDiastolic = 120;
    public BloodPressure(int systolic, int diastolic)
    {
        if (systolic < MinSystolic || systolic > MaxSystolic)
            throw new ArgumentException($"Systolic BP must be between {MinSystolic} and {MaxSystolic}.");
        if (diastolic < MinDiastolic || diastolic > MaxDiastolic)
            throw new ArgumentException($"Diastolic BP must be between {MinDiastolic} and {MaxDiastolic}.");
        if (diastolic > systolic)
            throw new ArgumentException("Diastolic cannot exceed systolic.");
        Systolic = systolic;
        Diastolic = diastolic;
    }
}
