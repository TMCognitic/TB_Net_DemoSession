using DemoSession.Models.Sessions;
using System.Text.Json;

namespace DemoSession.Infrastructure
{
    public class SessionManager
    {
        private readonly ISession _session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            ArgumentNullException.ThrowIfNull(httpContextAccessor);
            ArgumentNullException.ThrowIfNull(httpContextAccessor.HttpContext);

            _session = httpContextAccessor.HttpContext.Session;
        }

        public SessionUser? User
        {
            get 
            {
                if (!_session.Keys.Contains(nameof(User)))
                    return null;

                return JsonSerializer.Deserialize<SessionUser>(_session.GetString(nameof(User))!, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });}
            set 
            {
                if (value is null)
                    throw new InvalidOperationException();

                _session.SetString(nameof(User), JsonSerializer.Serialize(value)); 
            }
        }
    }
}
