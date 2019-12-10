﻿using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        Contact pickedcontact = null;


        public MainPage()
        {
            this.InitializeComponent();
            Connection connection = new Connection();
            connection.Connect();
            //   contacts = new ObservableCollection<Contact>();

        }

        private void ShowPane(object sender, RoutedEventArgs e)
        {
            if (SplitViewPanel_Menu.IsPaneOpen == false)
            {
                SplitViewPanel_Menu.IsPaneOpen = true;
                ButtonShowPane.Content = "\uE00E";
            }
            else
            {
                SplitViewPanel_Menu.IsPaneOpen = false;
                ButtonShowPane.Content = "\uE00F";
            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ListView listView = (ListView)sender;
                var pickeditem = listView.SelectedItem;
                pickedcontact = (Contact)pickeditem;
                PickedName.Text = pickedcontact.name;
                PickedSurname.Text = pickedcontact.surname;
            }
            catch (Exception ex)
            {

            }
        }

        private void Click_AddContact(object sender, RoutedEventArgs e)
        {
            Contact con = new Contact("nam11", "surname2");
            contacts.Add(con);
            Contact con2 = new Contact("xxxxxxxx", "ddddddd");
            contacts.Add(con2);
        }
    }
}
