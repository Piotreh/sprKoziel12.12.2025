using System.Collections.ObjectModel;

namespace PhotoGallery
{
    public partial class MainPage : ContentPage
    {
        public static ObservableCollection<Contact> Contacts { get; set; } =
            new ObservableCollection<Contact>
            {
                new Contact { Firstname="Zygmunt", LastName="Kanam", Phone="+48 123 456 789", Photo="zdj1.png"},
                new Contact { Firstname="Anastazja", LastName="Marka", Phone="+48 987 654 321", Photo="zdj2.png"},
                new Contact { Firstname="Taduesz", LastName="Zygmunt", Phone="+48 555 666 777", Photo="zdj3.png"}
            };
        public static Contact SelectedContact { get; set; }
        public MainPage()
        {
            InitializeComponent();
            ContactsList.ItemsSource = Contacts;
        }
        private void OnCheckBoxChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox cb && cb.BindingContext is Contact contact)
            {
                foreach (var c in Contacts)
                    if (c != contact) c.IsSelected = false;
                SelectedContact = e.Value ? contact : null;
            }
        }
        public static void DeleteSelectedContact()
        {
            if (SelectedContact != null)
            {
                Contacts.Remove(SelectedContact);
                SelectedContact = null;
            }
        }
    }
}