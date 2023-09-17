using Fitness.DB;

namespace Fitness.Views;

public partial class App : Application
{
    public App(AppShell appShell)
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU3ODMxNkAzMjMyMmUzMDJlMzBCb0ZmWlQ4aEhiT0l0ZGYwR1h2T0RyQy93R3Q2dnBETWhFWFdSUGhCa3JnPQ==");
        InitializeComponent();

        MainPage = appShell;
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnResume()
    {
        base.OnResume();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
    }
}
