namespace PhotoGallery
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
        }
        private async void OnAddClicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            await GoToAsync(nameof(AddContactPage));
        }
        private async void OnEditClicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            if (MainPage.SelectedContact == null)
            {
                await DisplayAlert("Błąd", "Wybierz kontakt", "OK");
                return;
            }
            await GoToAsync(nameof(EditContactPage), new Dictionary<string, object>
            {
                ["Contact"] = MainPage.SelectedContact
            });
        }
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            if (MainPage.SelectedContact == null)
            {
                await DisplayAlert("Błąd", "Wybierz kontakt", "OK");
                return;
            }
            bool answer = await DisplayAlert(
                "Usuń kontakt",
                $"Czy usunąć {MainPage.SelectedContact.FullName}?",
                "Tak", "Nie");
            if (answer)
                MainPage.DeleteSelectedContact();
        }
    }
}