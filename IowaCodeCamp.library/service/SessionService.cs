using IowaCodeCamp.library.presentation;
using IowaCodeCamp.library.webservice;
using IowaCodeCamp.library.entity.session;

namespace IowaCodeCamp.library.service
{
    public class SessionService
    {
        private readonly ISessionListController controller;
        private readonly SessionWebService webService;
        private readonly SessionJsonSimplifier sessionJsonSimplifier;
        private readonly SessionDeserializer sessionDeserializer;

        public SessionService(ISessionListController controller) : this(controller, new SessionJsonSimplifier(), new SessionDeserializer()) { }

        public SessionService(ISessionListController controller, SessionJsonSimplifier sessionJsonSimplifier, SessionDeserializer sessionDeserializer)
        {
            this.controller = controller;
            this.sessionJsonSimplifier = sessionJsonSimplifier;
            this.sessionDeserializer = sessionDeserializer;
            this.webService = new SessionWebService(this);
        }

        public void GetListOfSessions()
        {
            webService.GetListOfSessions();
        }

        public void CallBackWithListOfSessions(string json)
        {
            var simpleJson = sessionJsonSimplifier.SimplifySessionJson(json);
            var sessions = sessionDeserializer.ParseSessionJsonAndReturnListOfSessions(simpleJson);

            controller.ControllerCallBackWithSessions(sessions);
        }
    }
}
