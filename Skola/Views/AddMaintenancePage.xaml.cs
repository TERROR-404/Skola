namespace Skola.Views;

public partial class AddMaintenancePage : ContentPage
{
    public string ItemId
    {
        set { LoadMaintenance(value); }
    }
    public AddMaintenancePage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.maintenances.txt";
        LoadMaintenance(Path.Combine(appDataPath, randomFileName));
    }
    private async void SaveMaintenance_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Employee maintenance)
            File.WriteAllText(maintenance.Filename, MaintenanceName.Text);

        await Shell.Current.GoToAsync("..");
    }
    private void LoadMaintenance(string fileName)
    {
        Models.Employee maintenanceModel = new Models.Employee();
        maintenanceModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            maintenanceModel.Name = File.ReadAllText(fileName);
        }

        BindingContext = maintenanceModel;
    }
}