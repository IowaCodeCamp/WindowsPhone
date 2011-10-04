using System.Windows;
using IowaCodeCamp.library.presentation;
using Microsoft.Phone.Controls;

namespace IowaCodeCamp.controllers
{
    public partial class SpeakerDetails : PhoneApplicationPage
    {
        private readonly ImageLookupController imageLookupController;

        public SpeakerDetails() : this (new ImageLookupController()) {}

        public SpeakerDetails(ImageLookupController imageLookupController)
        {
            InitializeComponent();

            this.imageLookupController = imageLookupController;

            SetSessionDetails();
        }

        public void SetSessionDetails()
        {
            var app = (App)Application.Current;
            var session = app.selectedSession;

            loadSpeakerName.Text = session.speaker.name;
            loadSpeakerDesc.Text = session.speaker.bio;
            loadWebsite.Text = session.speaker.web;
            loadLocation.Text = session.speaker.location;

            this.Dispatcher.BeginInvoke(() => imageLookupController.SetImageFromUri(session.speaker.fullImageUri, loadImg));
        }
    }
}