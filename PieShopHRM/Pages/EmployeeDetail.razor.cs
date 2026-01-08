using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Shared.Model;
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

    public List<Marker> MapMarkers { get; set; } = new List<Marker>();

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

        if(Employee.Longitude.HasValue && Employee.Latitude.HasValue)
        {
            MapMarkers = new List<Marker>
            {
                new Marker
                {
                    Description = $"{Employee.FirstName} {Employee.LastName}",
                    ShowPopup = false,
                    X = Employee.Longitude.Value,
                    Y = Employee.Latitude.Value,
                },
            };
        }

    }
}