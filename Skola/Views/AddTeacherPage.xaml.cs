namespace Skola.Views;

public partial class AddTeacherPage : ContentPage
{
    public string ItemId
    {
        set { LoadTeacher(value); }
    }
    public AddTeacherPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.teachers.txt";
        LoadTeacher(Path.Combine(appDataPath, randomFileName));
    }
    private async void SaveTeacher_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Employee teacher)
            File.WriteAllText(teacher.Filename, TeacherName.Text);

        await Shell.Current.GoToAsync("..");
    }
    private void LoadTeacher(string fileName)
    {
        Models.Employee teacherModel = new Models.Employee();
        teacherModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            teacherModel.Name = File.ReadAllText(fileName);
        }

        BindingContext = teacherModel;
    }
}