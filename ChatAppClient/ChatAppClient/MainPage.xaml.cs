using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ChatAppClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Contact> contacts = new List<Contact>();
        Contact pickedcontact = null;

        List<Contact> Contacts { get => contacts; set => contacts = value; }
        public MainPage()
        {
            this.InitializeComponent();
            Start();
        }

        void Start()
        {
            
        }

        private void ShowPane(object sender, RoutedEventArgs e)
        {

            if (SplitViewPanel_Menu.IsPaneOpen == false)
            {
                SplitViewPanel_Menu.IsPaneOpen = true;
                Button_ShowMenu.Content = "\uE00E";
            }
            else
            {
                SplitViewPanel_Menu.IsPaneOpen = false;
                Button_ShowMenu.Content = "\uE00F";
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            Connection connection = new Connection();
            connection.Connect();
            Contact contact1 = new Contact("name1", "surname1");
            Contact contact2 = new Contact("marcin", "nowak");
            contacts.Add(contact1);
            contacts.Add(contact2);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListView listView = (ListView)sender;
                var pickeditem = listView.SelectedItem;
                pickedcontact = (Contact)pickeditem;
            }
            catch (Exception ex)
            {

            }
            this.UpdateLayout();
        }

        private void ListView_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
