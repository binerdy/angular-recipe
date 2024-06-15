using System.Reflection;

namespace Common
{
    public class RavenSettings
    {
        public string DatabaseName { get; set; } = string.Empty;

        public string[] Urls { get; set; } = [];

        public string Pfx { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public TimeSpan RequestTimeout { get; set; }

        public int MaxHttpCacheSizeInMb { get; set; }

        public IReadOnlyCollection<Assembly> IndexAssemblies { get; set; } = [];
    }
}
