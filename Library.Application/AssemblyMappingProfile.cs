using AutoMapper;
using Library.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public  class AssemblyMappingProfile: Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
           ApplyMappingsFromAssembly(assembly);
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type =>type.GetInterfaces()
                .Any(type => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this}); 
            }
        }
    }
}
