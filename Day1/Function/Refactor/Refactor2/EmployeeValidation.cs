public class EmployeeValidation
{
    public void ValidateEmployee(Employee emp)
    {
        if (emp.ID < 50)
            throw new InvalidDataException("Employee ID starts from 50; 1 to 49 are reserved for promoters, investors, etc. Data can't be shared in HRMS due to security issues.");

        if (emp.Name.Length > 150)
            throw new InvalidDataException("Name too long");
    }

    public void ValidateDeleteEmployee(Employee emp)
    {
        if (emp.ID == 1)
            throw new InvalidDataException("Chairman can't be removed.");
    }
}
