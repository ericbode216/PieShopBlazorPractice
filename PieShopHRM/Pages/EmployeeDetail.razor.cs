using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Models;
using PieShopHRM.Services;

namespace PieShopHRM.Pages;

public partial class EmployeeDetail
{
    [Inject]
    IEmployeeDataService? EmployeeDataService { get; set; }

    [Parameter]
    public string EmployeeId { get; set; }

    public Employee? Employee { get; set; } = new Employee();

    /*
    protected override Task OnInitializedAsync()
    {
       Employee = MockDataService.Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));

       return base.OnInitializedAsync();
    }
    */
    protected async override Task OnInitializedAsync()
    {
        Employee = (await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId)));
        

    }
}