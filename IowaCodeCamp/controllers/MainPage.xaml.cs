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
        private readonly SessionOrganizer sessionOrganizer;
        private readonly SpecialSessionIdentifier specialSessionIdentifier;

        public MainPage() : this(new SessionOrganizer(), new SpecialSessionIdentifier()) {}

        public MainPage(SessionOrganizer sessionOrganizer, SpecialSessionIdentifier specialSessionIdentifier)
        {
            InitializeComponent();

            this.sessionOrganizer = sessionOrganizer;
            this.specialSessionIdentifier = specialSessionIdentifier;
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
            sessionList.ItemsSource = sessionOrganizer.SortAndGroupSessionsByTime(sessions);
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (sender as LongListSelector);
            if (listbox == null) return;

            var selectedSession = listbox.SelectedItem as Session;
            var app = (App)Application.Current;

            if (specialSessionIdentifier.SessionNameRequiresSpecialTreatment(selectedSession.session))
            {
                return;
            }

            app.selectedSession = selectedSession;
            NavigationService.Navigate(new Uri("/controllers/SessionDetails.xaml", UriKind.Relative));
        }
    }
}