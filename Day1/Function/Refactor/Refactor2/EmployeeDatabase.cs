public class EmployeeDatabase
{
    private readonly IDbConnection _db;
    private readonly EmployeeValidation _validation;

    public EmployeeDatabase(IDbConnection dbConnection, EmployeeValidation validation)
    {
        _db = dbConnection;
        _validation = validation;
    }

    public Employee GetEmployee(int id)
    {
        Employee employee = _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id",
            new { Id = id });

        if (employee == null)
            throw new InvalidDataException("Employee not found.");

        _validation.ValidateEmployee(employee);

        return employee;
    }

    public void SaveEmployee(Employee emp)
    {
        _validation.ValidateEmployee(emp);

        _db.Execute(
            "UPDATE Employees SET Name = @Name WHERE Id = @Id",
            new { emp.Name, emp.Id });
    }

    public void DeleteEmployee(int id)
    {
        Employee emp = _db.QueryFirstOrDefault<Employee>(
            "SELECT * FROM Employees WHERE Id = @Id",
            new { Id = id });

        if (emp == null)
            throw new InvalidDataException("Employee not found.");

        _validation.ValidateDeleteEmployee(emp);

        _db.Execute(
            "DELETE FROM Employees WHERE Id = @Id",
            new { Id = id });
    }
}
