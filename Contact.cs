using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotoGallery
{
    public class Contact : INotifyPropertyChanged
    {
        private string firstname, lastName, phone, photo;
        private bool isSelected;
        public string Firstname
        {
            get => firstname;
            set { firstname = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); }
        }
        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(); OnPropertyChanged(nameof(FullName)); }
        }
        public string Phone
        {
            get => phone;
            set { phone = value; OnPropertyChanged(); }
        }
        public string Photo
        {
            get => photo;
            set { photo = value; OnPropertyChanged(); }
        }
        public bool IsSelected
        {
            get => isSelected;
            set { isSelected = value; OnPropertyChanged(); }
        }
        public string FullName => $"{Firstname} {LastName}";
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}