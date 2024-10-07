namespace Skola.Views;

public partial class AddStudentPage : ContentPage
{
    public string ItemId
    {
        set { LoadStudent(value); }
    }
    public AddStudentPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.students.txt";
        LoadStudent(Path.Combine(appDataPath, randomFileName));
    }
    private async void SaveStudent_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Employee student)
            File.WriteAllText(student.Filename, StudentName.Text);

        await Shell.Current.GoToAsync("..");
    }
    private void LoadStudent(string fileName)
    {
        Models.Employee studentModel = new Models.Employee();
        studentModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            studentModel.Name = File.ReadAllText(fileName);
        }

        BindingContext = studentModel;
    }
}