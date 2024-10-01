namespace Skola.Views;

public partial class AddTeacherPage : ContentPage
{
	public AddTeacherPage()
	{
		InitializeComponent();
	}
    private async void SaveTeacher_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Teacher teacher)
            File.WriteAllText(teacher.Filename, teacher.Name + " " + teacher.Surname);

        await Shell.Current.GoToAsync("..");
    }
}