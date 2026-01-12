using Microsoft.AspNetCore.Components;

namespace PieShopHRM.Components;

public partial class InboxCounter
{
    public int MessageCount;
    [Inject]
    ApplicationState ApplicationState { get; set; }

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(10);
        ApplicationState.NumberOfMessages = MessageCount;
    }
}