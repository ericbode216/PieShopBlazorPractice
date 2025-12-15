using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components;

public partial class QuickViewPopup
{
    [Parameter]
    public Employee? Employee { get; set; } = default!;

    private Employee? _employee;

    protected override void OnParametersSet()
    {
        _employee = Employee;
    }
    public void Close()
    {
        _employee = null;
    }
}