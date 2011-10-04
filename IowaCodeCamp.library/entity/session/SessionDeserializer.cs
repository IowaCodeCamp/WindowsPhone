using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IowaCodeCamp.library.entity.session
{
    public class SessionDeserializer
    {
        public IEnumerable<Session> ParseSessionJsonAndReturnListOfSessions(string json)
        {
            IEnumerable<Session> sessions;
            try
            {
                sessions = JsonConvert.DeserializeObject<SessionResults>(json).data;
            }
            catch (Exception exception)
            {
                sessions = new List<Session>();
            }

            return sessions;
        }
    }
}
