using System;
using System.IO;
using System.Net;
using IowaCodeCamp.library.service;

namespace IowaCodeCamp.library.webservice
{
    public class SessionWebService
    {
        private readonly SessionService service;

        public SessionWebService(SessionService service)
        {
            this.service = service;
        }

        public void GetListOfSessions()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://toranbillups.com/content/examples/icc.html");
            request.Method = "GET";

            request.BeginGetResponse(new AsyncCallback(GetResponse), request);
        }

        private void GetResponse(IAsyncResult asyncResult)
        {
            var json = ReadResponse(asyncResult);

            service.CallBackWithListOfSessions(json);
        }

        private string ReadResponse(IAsyncResult result)
        {
            var request = (HttpWebRequest)result.AsyncState;
            var response = request.EndGetResponse(result);
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
