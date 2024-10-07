namespace Skola.Views
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();

            BindingContext = new Models.AllHelp();
        }
        protected override void OnAppearing()
        {
            ((Models.AllHelp)BindingContext).LoadHelp();
        }
        private async void AddHelp_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddHelpPage));
        }
        private void DeleteHelp_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var deleteHelp = button.CommandParameter as Models.Employee;
                if (File.Exists(deleteHelp.Filename))
                    File.Delete(deleteHelp.Filename);
                OnAppearing();
            }
        }
    }
}