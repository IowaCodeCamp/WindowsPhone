using System.Collections.Generic;
using IowaCodeCamp.library.entity.session;

namespace IowaCodeCamp.library.presentation
{
    public interface ISessionListController
    {
        void ControllerCallBackWithSessions(IEnumerable<Session> sessions);
    }
}
