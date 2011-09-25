namespace IowaCodeCamp.library.entity.session
{
    public class SpecialSessionIdentifier
    {
        public bool SessionNameRequiresSpecialTreatment(string sessionName)
        {
            if (sessionName == "Breakfast")
                return true;

            if (sessionName == "Welcome and announcements")
                return true;

            if (sessionName == "Break")
                return true;

            if (sessionName == "Lunch")
                return true;

            if (sessionName == "Closing and Prizes")
                return true;

            return false;
        }
    }
}
