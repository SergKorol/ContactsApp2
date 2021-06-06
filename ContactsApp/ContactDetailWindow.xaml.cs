using System.Windows;
using ContactsApp.Classes;
using SQLite;

namespace ContactsApp
{
    public partial class ContactDetailWindow : Window
    {
        private Contact _contact;
        public ContactDetailWindow(Contact contact)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            _contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            _contact.Name = nameTextBox.Text;
            _contact.Email = emailTextBox.Text;
            _contact.Phone = phoneTextBox.Text;
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            }
            Close();
        }
    }
}