using System.Net.Http.Json;
using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;
using PieShopHRM.Models;
using PieShopHRM.Services;

namespace PieShopHRM.Pages;

public partial class EmployeeOverview
{
    /* Possible way to implement
    [Inject]
    public HttpClient HttpClient { get; set;}
    */

    [Inject]
    IEmployeeDataService? EmployeeDataService { get; set; }

    public List<Employee>? Employees { get; set; } = default!;

    //used to refresh List of Employees and Employee Data after Employee is edited
    [SupplyParameterFromQuery(Name = "refreshneeded")]
    public bool refreshneeded { get; set; } = false;

    private Employee? _selectedEmployee;

    private string Title = "Employee Overview";


    /*
    protected override void OnInitialized()
    {
        //this used mock local data
        Employees = MockDataService.Employees;
  
    }
    */
    protected override async Task OnInitializedAsync()
    {
        //var data = await HttpClient.GetFromJsonAsync<List<Employee>>("http://localhost:7039/api/employee");
        Employees = (await EmployeeDataService.GetAllEmployees(refreshneeded)).ToList();
    }

    public void ShowQuickViewPopup(Employee selectedEmployee)
    {
        _selectedEmployee = selectedEmployee;
    }
}
