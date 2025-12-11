namespace PhotoGallery;

public partial class AddContactPage : ContentPage
{
    public AddContactPage()
    {
        InitializeComponent();
    }
    private async void OnAddClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(FirstEntry.Text) ||
            string.IsNullOrWhiteSpace(LastEntry.Text) ||
            string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            await DisplayAlert("B³¹d", "Wype³nij wszystkie pola", "OK");
            return;
        }
        MainPage.Contacts.Add(new Contact
        {
            Firstname = FirstEntry.Text,
            LastName = LastEntry.Text,
            Phone = PhoneEntry.Text,
            Photo = string.IsNullOrWhiteSpace(PhotoEntry.Text) ? "zdj1.png" : PhotoEntry.Text
        });
        await Shell.Current.GoToAsync("..");
    }
    private async void OnCancelClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
