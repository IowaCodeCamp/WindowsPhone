﻿using System;
using IowaCodeCamp.library.entity.speaker;

namespace IowaCodeCamp.library.entity.session
{
    public class Session
    {
        public string session { get; set; }
        public string time { get; set; }
        public string desc { get; set; }
        public string room { get; set; }
        public Speaker speaker { get; set; }

        public string speakerName
        {
            get { return speaker.name; }
        }

        public string formattedSessionName
        {
            get
            {
                if (session.Length < 38)
                    return session;

                var actualName = session.Substring(0, 38);
                return actualName.Trim() + "...";
            }
        }

        public DateTime sortFriendlyStartTime
        {
            get { 
                var postHour = time.IndexOf(":");
                var startTime = time.Substring(0, postHour + 6);
                var actualDate = "01/01/2011 " + startTime;
                return Convert.ToDateTime(actualDate);
            }
        }
    }
}
