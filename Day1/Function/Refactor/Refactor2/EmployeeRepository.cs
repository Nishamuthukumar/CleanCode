public class EmployeeRepository
{
    private readonly EmployeeDatabase _db;

    public EmployeeRepository(EmployeeDatabase db)
    {
        _db = db;
    }

    public Employee GetEmployee(int id)
    {
        return _db.GetEmployee(id);
    }

    public void SaveEmployee(Employee emp)
    {
        _db.SaveEmployee(emp);
    }

    public void DeleteEmployee(int id)
    {
        _db.DeleteEmployee(id);
    }
}
