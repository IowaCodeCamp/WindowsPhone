using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IowaCodeCamp.library.entity.session
{
    public class SessionOrganizer
    {
        public IEnumerable SortAndGroupSessionsByTime(IEnumerable<Session> sessions)
        {
            var sessionByTime = from s in sessions
                                orderby s.sortFriendlyStartTime.TimeOfDay
                                group s by s.time
                                    into c
                                    select new Group<Session>(c.Key, c);

            return sessionByTime;
        }
    }
}
