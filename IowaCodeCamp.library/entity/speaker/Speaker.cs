namespace IowaCodeCamp.library.entity.speaker
{
    public class Speaker
    {
        public string name { get; set; }
        public string title { get; set; }
        public string bio { get; set; }
        public string img { get; set; }
        public string web { get; set; }
        public string location { get; set; }

        public string fullImageUri 
        {
            get { return "http://iowacodecamp.com/public/images/speakers/" + img; }
        }
    }
}
