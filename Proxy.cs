using System;
using System.Collections.Generic;

namespace Proxy_Pattern
{
    public class Proxy : ISubject
    {
        private RealSubject RealSubject;
        private Dictionary<string, string> Cache;
        private DateTime LastCacheTime;
        private readonly TimeSpan CacheExpiration;
        private readonly string UserRole;
        private Dictionary<string, List<string>> Permissions;

        public Proxy(string userRole)
        {
            RealSubject = new RealSubject();
            Cache = new Dictionary<string, string>();
            LastCacheTime = DateTime.MinValue;
            CacheExpiration = TimeSpan.FromMinutes(1);
            UserRole = userRole;
            Permissions = new Dictionary<string, List<string>>
            {
                { "Admin", new List<string> { "Request1", "Request2", "Request3" } },
                { "Guest", new List<string> { "Request1" } },
                { "Manager", new List<string> { "Request2", "Request3" } }
            };
        }

        private bool HasPermission(string request)
        {
            if (Permissions.ContainsKey(UserRole))
            {
                return Permissions[UserRole].Contains(request);
            }
            return false;
        }

        public string Request(string request)
        {
            if (!HasPermission(request))
            {
                return "Access Denied: You don't have permission to make this request.";
            }

            if (Cache.ContainsKey(request) && DateTime.Now - LastCacheTime < CacheExpiration)
            {
                Console.WriteLine("Proxy: Returning cached response.");
                return Cache[request];
            }

            Console.WriteLine("Proxy: Delegating request to RealSubject.");
            try
            {
                string response = RealSubject.Request(request);
                Cache[request] = response;
                LastCacheTime = DateTime.Now;
                return response;
            }
            catch (Exception ex)
            {
                return $"Error while processing request: {ex.Message}";
            }
        }

    }
}
