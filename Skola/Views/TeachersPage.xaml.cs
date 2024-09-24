namespace Skola.Views;

public partial class TeachersPage : ContentPage
{
	public TeachersPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.employees.txt";

        LoadTeacher(Path.Combine(appDataPath, randomFileName));
    }
    private async void AddTeacher_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teachers teacher)
            File.WriteAllText(teacher.Filename, teacher.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteTeacher_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teachers teacher)
        {
            if (File.Exists(teacher.Filename))
                File.Delete(teacher.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void LoadTeacher(string fileName)
    {
        Models.Teachers teacherModel = new Models.Teachers();
        teacherModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            teacherModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = teacherModel;
    }
}