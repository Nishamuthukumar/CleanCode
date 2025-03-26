public class PatientVitalsService
{
    private readonly DateTime _currentDateTime;
    public PatientVitalsService(DateTime? currentDateTime = null)
    {
        _currentDateTime = currentDateTime ?? DateTime.Now;
    }
    public void RecordVitals(
        int patientId,
        Temperature temperature,
        BloodPressure bloodPressure,
        HeartRate heartRate,
        BloodType bloodType,
        int age,
        DateTime lastMealTime)
    {
        ValidatePostMealBloodPressure(bloodPressure.Diastolic, lastMealTime);
    }
    private void ValidatePostMealBloodPressure(int diastolic, DateTime lastMealTime)
    {
        if ((_currentDateTime - lastMealTime).TotalHours < 2 && diastolic > 90)
            TriggerAlert("Elevated postprandial blood pressure. Consider monitoring more closely.");
    }
    private void TriggerAlert(string message)
    {
        Console.WriteLine($"ALERT: {message}");
    }
}
