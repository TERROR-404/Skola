namespace Skola.Views
{
    public partial class MaintenancePage : ContentPage
    {
        public MaintenancePage()
        {
            InitializeComponent();

            BindingContext = new Models.AllMaintenance();
        }
        protected override void OnAppearing()
        {
            ((Models.AllMaintenance)BindingContext).LoadMaintenances();
        }
        private async void AddMaintenance_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddMaintenancePage));
        }
        private void DeleteMaintenance_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var deleteMaintenance = button.CommandParameter as Models.Employee;
                if (File.Exists(deleteMaintenance.Filename))
                    File.Delete(deleteMaintenance.Filename);
                OnAppearing();
            }
        }
    }
}