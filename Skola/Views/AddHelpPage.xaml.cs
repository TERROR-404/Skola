namespace Skola.Views;

public partial class AddHelpPage : ContentPage
{
    public string ItemId
    {
        set { LoadHelp(value); }
    }
    public AddHelpPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.helps.txt";
        LoadHelp(Path.Combine(appDataPath, randomFileName));
    }
    private async void SaveHelp_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Employee help)
            File.WriteAllText(help.Filename, HelpName.Text);

        await Shell.Current.GoToAsync("..");
    }
    private void LoadHelp(string fileName)
    {
        Models.Employee helpModel = new Models.Employee();
        helpModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            helpModel.Name = File.ReadAllText(fileName);
        }

        BindingContext = helpModel;
    }
}