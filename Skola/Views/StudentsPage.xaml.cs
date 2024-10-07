namespace Skola.Views
{
    public partial class StudentsPage : ContentPage
    {
        public StudentsPage()
        {
            InitializeComponent();

            BindingContext = new Models.AllStudents();
        }
        protected override void OnAppearing()
        {
            ((Models.AllStudents)BindingContext).LoadStudents();
        }
        private async void AddStudent_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddStudentPage));
        }
        private void DeleteStudent_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var deleteStudent= button.CommandParameter as Models.Employee;
                if (File.Exists(deleteStudent.Filename))
                    File.Delete(deleteStudent.Filename);
                OnAppearing();
            }
        }
    }
}