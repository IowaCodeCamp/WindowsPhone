using System;
using System.Net;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace IowaCodeCamp.library.presentation
{
    public class ImageLookupController
    {
        public object SetImageFromUri(string uri, Image img)
        {
            var wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(uri), img);

            return null;
        }

        void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                try
                {
                    var img = (Image)e.UserState;
                    var image = new BitmapImage();
                    image.SetSource(e.Result);

                    img.Source = image;
                }
                catch (Exception ex)
                {
                    //gulp!!!
                }
            }
        }
    }
}
