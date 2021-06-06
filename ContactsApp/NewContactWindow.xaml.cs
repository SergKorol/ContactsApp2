using System.Windows;
using ContactsApp.Classes;
using SQLite;

namespace ContactsApp
{
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text, Email = emailTextBox.Text, Phone = phoneTextBox.Text
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.dbPath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            Close();
        }
    }
}