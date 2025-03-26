public class EmployeeService
{
    private readonly EmployeeRepository _repo;

    public EmployeeService(EmployeeRepository repo)
    {
        _repo = repo;
    }

    public Employee GetEmployee(int id)
    {
        return _repo.GetEmployee(id);
    }

    public void UpdateEmployee(Employee emp)
    {
        _repo.SaveEmployee(emp);
    }

    public void RemoveEmployee(int id)
    {
        _repo.DeleteEmployee(id);
    }
}
