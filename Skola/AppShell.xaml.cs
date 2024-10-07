namespace Skola;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AddTeacherPage), typeof(Views.AddTeacherPage));
        Routing.RegisterRoute(nameof(Views.AddStudentPage), typeof(Views.AddStudentPage));
        Routing.RegisterRoute(nameof(Views.AddMaintenancePage), typeof(Views.AddMaintenancePage));
        Routing.RegisterRoute(nameof(Views.AddHelpPage), typeof(Views.AddHelpPage));
    }
}