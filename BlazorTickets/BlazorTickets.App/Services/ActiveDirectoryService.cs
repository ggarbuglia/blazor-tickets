using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.AccountManagement;

namespace BlazorTickets.App.Services
{
    public class ActiveDirectoryService
    {
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly string _domain;

        public ActiveDirectoryService(IConfiguration configuration, IMemoryCache cache)
        {
            _config = configuration;
            _cache  = cache;

            _domain = _config.GetValue<string>("ActiveDirectory:Domain");
        }

        [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "System.DirectoryServices usage.")]
        public UserPrincipal? GetUser(string? username)
        {
            if (username == null) throw new ArgumentException("username can not be null.");

            var cachedUser = _cache.Get<UserPrincipal>(username);
            if (cachedUser != null) return cachedUser;

            using var context = new PrincipalContext(ContextType.Domain, _domain);
            var user = UserPrincipal.FindByIdentity(context, username);
            if (user != null)
            {
                _cache.Set(username, user);
                cachedUser = user;
            }

            return cachedUser;
        }

        [SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "System.DirectoryServices usage.")]
        public List<(string Name, string Sid)>? GetGroups(string? username)
        {
            if (username == null) throw new ArgumentException("username can not be null.");

            using var context = new PrincipalContext(ContextType.Domain, _domain);
            var user = UserPrincipal.FindByIdentity(context, username);
            if (user == null) return null;

            return user.GetGroups().Select(g => (g.Name, Sid: g.Sid.ToString())).ToList();
        }
    }
}
