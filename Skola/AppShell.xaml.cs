namespace Skola;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.AddTeacherPage), typeof(Views.AddTeacherPage));
    }
}
