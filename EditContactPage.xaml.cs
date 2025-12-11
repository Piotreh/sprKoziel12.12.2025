namespace PhotoGallery;

[QueryProperty(nameof(Contact), "Contact")]
public partial class EditContactPage : ContentPage
{
    public Contact Contact { get; set; }
    public EditContactPage()
    {
        InitializeComponent();
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        if (Contact != null)
        {
            FirstEntry.Text = Contact.Firstname;
            LastEntry.Text = Contact.LastName;
            PhoneEntry.Text = Contact.Phone;
            PhotoEntry.Text = Contact.Photo;
        }
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        Contact.Firstname = FirstEntry.Text;
        Contact.LastName = LastEntry.Text;
        Contact.Phone = PhoneEntry.Text;
        Contact.Photo = string.IsNullOrWhiteSpace(PhotoEntry.Text) ? "zdj1.png" : PhotoEntry.Text;
        await Shell.Current.GoToAsync("..");
    }
    private async void OnCancelClicked(object sender, EventArgs e)
        => await Shell.Current.GoToAsync("..");
}
