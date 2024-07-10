using System.Reflection;
using Api.Mappings.Interfaces;

namespace Api.Extensions
{
    public static class MapsterExtension
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => !x.IsInterface && !x.IsAbstract && typeof(IMapping).IsAssignableFrom(x))
                .Select(x => (IMapping)Activator.CreateInstance(x)).ToList()
                .ForEach(x => x?.AddMappings());

            return services;
        }
    }
}