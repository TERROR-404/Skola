namespace Skola.Views
{
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
            if (BindingContext is Models.Teacher teacher)
                File.WriteAllText(teacher.Filename, TeacherName.Text);

            await Shell.Current.GoToAsync("..");
        }
        private void LoadTeacher(string fileName)
        {
            Models.Teacher noteModel = new Models.Teacher();
            noteModel.Filename = fileName;

            if (File.Exists(fileName))
            {
                noteModel.Name = File.ReadAllText(fileName);
            }

            BindingContext = noteModel;
        }
    }
}