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
                var removeFrontCruft = json.Substring(73, json.Length - 73);
                var addedFrontBracket = "{" + removeFrontCruft;
                simpleJson = addedFrontBracket.Substring(0, addedFrontBracket.Length - 5);
            }
            catch (Exception exception)
            {
                simpleJson = "";
            }

            return simpleJson;
        }
    }
}
