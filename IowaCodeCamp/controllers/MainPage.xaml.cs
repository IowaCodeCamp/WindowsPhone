using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IowaCodeCamp.library.entity.session;
using Microsoft.Phone.Controls;
using IowaCodeCamp.library.service;
using IowaCodeCamp.library.presentation;

namespace IowaCodeCamp.controllers
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
                Dispatcher.BeginInvoke(() => ShowNoInternetDialog());
            }
            else
            {
                Dispatcher.BeginInvoke(() => SetItemSourceForSessionListBox(sessions));
            }
        }

        private void ShowNoInternetDialog()
        {
            MessageBox.Show("This application requires some form of internet connectivity to function");
        }

        private void SetItemSourceForSessionListBox(IEnumerable<Session> sessions)
        {
            var sessionByTime = from s in sessions
                                group s by s.time
                                into c
                                orderby c.Key descending 
                                select new Group<Session>(c.Key, c);

            sessionList.ItemsSource = sessionByTime;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (sender as LongListSelector);
            if (listbox != null)
            {
                var selectedSession = listbox.SelectedItem as Session;
                var app = (App)Application.Current;
                app.selectedSession = selectedSession;

                NavigationService.Navigate(new Uri("/controllers/SessionDetails.xaml", UriKind.Relative));
            }
        }
    }
}