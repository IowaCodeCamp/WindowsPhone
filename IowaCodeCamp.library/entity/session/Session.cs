using IowaCodeCamp.library.entity.speaker;

namespace IowaCodeCamp.library.entity.session
{
    public class Session
    {
        public string session { get; set; }
        public string time { get; set; }
        public string desc { get; set; }
        public Speaker speaker { get; set; }
        public string speakerName
        {
            get { return speaker.name; }
        }
    }
}
