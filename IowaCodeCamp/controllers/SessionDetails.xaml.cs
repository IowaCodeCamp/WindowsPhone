using System;
using System.Windows;
using IowaCodeCamp.library.presentation;
using Microsoft.Phone.Controls;

namespace IowaCodeCamp.controllers
{
    public partial class SessionDetails : PhoneApplicationPage
    {
        private readonly ImageLookupController imageLookupController;

        public SessionDetails() : this (new ImageLookupController()) {}

        public SessionDetails(ImageLookupController imageLookupController)
        {
            InitializeComponent();

            this.imageLookupController = imageLookupController;

            SetSessionDetails();
        }

        public void SetSessionDetails()
        {
            var app = (App)Application.Current;
            var session = app.selectedSession;

            loadSessionName.Text = session.session;
            loadSessionTime.Text = session.time;
            loadSessionDesc.Text = session.desc;
            loadSessionRoom.Text = "XRB 300";
            
            loadSpeakerName.Text = session.speakerName;
            this.Dispatcher.BeginInvoke(() => imageLookupController.SetImageFromUri(session.speaker.fullImageUri, loadImg));
        }

        private void ViewSpeakerInfo_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}