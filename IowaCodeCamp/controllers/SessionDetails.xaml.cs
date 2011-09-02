using System.Windows;
using IowaCodeCamp.library.entity.session;
using Microsoft.Phone.Controls;

namespace IowaCodeCamp.controllers
{
    public partial class SessionDetails : PhoneApplicationPage
    {
        public SessionDetails()
        {
            InitializeComponent();

            var app = (App)Application.Current;
            var selectedSession = app.selectedSession;
        }
    }
}