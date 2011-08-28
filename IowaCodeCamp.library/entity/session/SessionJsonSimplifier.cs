using System;

namespace IowaCodeCamp.library.entity.session
{
    public class SessionJsonSimplifier
    {
        public string SimplifySessionJson(string json)
        {
            string simpleJson;
            try
            {
                var removeFrontCruft = json.Substring(32, json.Length - 32);
                var addedFrontBracket = "{" + removeFrontCruft;
                simpleJson = addedFrontBracket.Substring(0, addedFrontBracket.Length - 1);
            }
            catch (Exception exception)
            {
                simpleJson = "";
            }

            return simpleJson;
        }
    }
}
