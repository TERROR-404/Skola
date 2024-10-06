namespace Skola.Views
{
    public partial class TeachersPage : ContentPage
    {
        public TeachersPage()
        {
            InitializeComponent();

            BindingContext = new Models.AllTeachers();
        }
        protected override void OnAppearing()
        {
            ((Models.AllTeachers)BindingContext).LoadTeachers();
        }
        private async void AddTeacher_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddTeacherPage));
        }
        private async void teachersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                var teacher = (Models.Teacher)e.CurrentSelection[0];

                await Shell.Current.GoToAsync($"{nameof(AddTeacherPage)}?{nameof(AddTeacherPage.ItemId)}={teacher.Filename}");

                teachersCollection.SelectedItem = null;
            }
        }
        private void DeleteTeacher_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var deleteTeacher = button.CommandParameter as Models.Teacher;
                if (File.Exists(deleteTeacher.Filename))
                    File.Delete(deleteTeacher.Filename);
                OnAppearing();
            }
        }
    }
}