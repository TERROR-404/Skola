namespace Skola.Views;

public partial class TeachersPage : ContentPage
{
	public TeachersPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.teachers.txt";

        LoadTeacher(Path.Combine(appDataPath, randomFileName));
    }
    private async void AddTeacher_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddTeacherPage));
    }

    private async void DeleteTeacher_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teacher teacher)
        {
            if (File.Exists(teacher.Filename))
                File.Delete(teacher.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void LoadTeacher(string fileName)
    {
        Models.Teacher teacherModel = new Models.Teacher();
        teacherModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            teacherModel.Name = File.ReadAllText(fileName).Split(' ')[0];
            teacherModel.Surname = File.ReadAllText(fileName).Split(' ')[1];
        }

        BindingContext = teacherModel;
    }
}