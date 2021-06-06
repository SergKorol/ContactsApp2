using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactsApp.Classes;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDatabase();
        }

        private void ReadDatabase()
        {
            
            using SQLiteConnection connection = new SQLiteConnection(App.dbPath);
            connection.CreateTable<Contact>();
            contacts = (connection.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();

            if (contacts != null)
            {
                
                // contacts.ForEach(contact => Contacts.ItemsSource = contact);
                Contacts.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            var filteredList = contacts.Where(c => searchTextBox != null && c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            Contacts.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectedChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = Contacts.SelectedItem as Contact;
            if (selectedContact is null)
            {
                return;
            }

            var newContactWindow = new ContactDetailWindow(selectedContact);
            newContactWindow.ShowDialog();
            ReadDatabase();
        }
    }
}