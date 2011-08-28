using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IowaCodeCamp.library.entity.session;
using Microsoft.Phone.Controls;
using IowaCodeCamp.library.service;
using IowaCodeCamp.library.presentation;

namespace IowaCodeCamp
{
    public partial class MainPage : PhoneApplicationPage, ISessionListController
    {
        public MainPage()
        {
            InitializeComponent();
            var service = new SessionService(this);
            service.GetListOfSessions();
        }

        public void ControllerCallBackWithSessions(IEnumerable<Session> sessions)
        {
            if (sessions == null || sessions.ToList().Count < 1)
            {
                this.Dispatcher.BeginInvoke(() => ShowNoInternetDialog());
            }
            else
            {
                this.Dispatcher.BeginInvoke(() => SetItemSourceForSessionListBox(sessions));
            }
        }

        private void ShowNoInternetDialog()
        {
            MessageBox.Show("This application requires some form of internet connectivity to function");
        }

        private void SetItemSourceForSessionListBox(IEnumerable<Session> sessions)
        {
            SessionList.ItemsSource = sessions;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (sender as ListBox);
            if (listbox != null && listbox.SelectedIndex > -1)
            {
                var selectedSession = listbox.SelectedItem as Session;
                App app = (App)Application.Current;
                app.selectedSession = selectedSession;

                listbox.SelectedIndex = -1;

                NavigationService.Navigate(new Uri("/controllers/SessionDetails.xaml", UriKind.Relative));
            }
        }
    }
}