using BethanysPieShopHRM.Shared.Domain;

namespace PieShopHRM.Services;

public interface IEmployeeDataService
{
    Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired);

    Task<Employee> GetEmployeeDetails(int employeeId);

    Task<Employee> AddEmployee(Employee employee);

    Task<Employee> UpdateEmployee(Employee employee);

    Task DeleteEmployee(int employeeId);
    
}