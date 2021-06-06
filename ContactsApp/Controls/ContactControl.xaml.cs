using System.Windows;
using System.Windows.Controls;
using ContactsApp.Classes;

namespace ContactsApp.Controls
{
    public partial class ContactControl : UserControl
    {
		public Contact Contact
		{
			get => (Contact)GetValue(ContactProperty);
			set => SetValue(ContactProperty, value);
		}

		// Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ContactProperty =
			DependencyProperty.Register("Contact", typeof(Contact), typeof(ContactControl), new PropertyMetadata(new Contact(), SetText));

		private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is ContactControl control)
			{
				control.NameTextBlock.Text = (e.NewValue as Contact)?.Name;
				control.EmailTextBlock.Text = (e.NewValue as Contact)?.Email;
				control.PhoneTextBlock.Text = (e.NewValue as Contact)?.Phone;
			}
		}

		public ContactControl()
        {
            InitializeComponent();
        }
    }
}