namespace SimplePersistence.UnitTests.Model
{
    using SimplePersistence.Model;

#if !DNXCORE50 && !DNX451

    using NUnit.Framework;
    using Fact = NUnit.Framework.TestAttribute;

#else

    using Xunit;
    using System.Reflection;
    using System.Linq;

#endif

    public class ImplementationDefinitionTests
    {


        [Fact]
        public void AllPropertiesMustBeVirtual()
        {
#if DNXCORE50 || DNX451

            var typeForIEntity = typeof (IEntity).GetTypeInfo();
            var assembly = typeForIEntity.Assembly;

            var typesToTest =
                assembly.GetExportedTypes()
                    .Select(e => e.GetTypeInfo())
                    .Where(e => e.IsClass && typeForIEntity.IsAssignableFrom(e));

            foreach (var type in typesToTest)
            {
                Assert.True(type.IsAbstract, $"Type {type.FullName} is not abstract");
                foreach (var property in type.DeclaredProperties)
                {
                    Assert.True(
                        property.GetMethod.IsVirtual, 
                        $"Getter {type.FullName}.{property.Name} is not virtual");
                    Assert.True(
                        property.SetMethod.IsVirtual, 
                        $"Setter {type.FullName}.{property.Name} is not virtual");
                }
            }
        
#else

            var typeForIEntity = typeof (IEntity);
            var assembly = typeForIEntity.Assembly;

            foreach (var type in assembly.GetExportedTypes())
            {
                if (type.IsClass && typeForIEntity.IsAssignableFrom(type))
                {
                    Assert.True(type.IsAbstract, $"Type {type.FullName} is not abstract");
                    foreach (var property in type.GetProperties())
                    {
                        Assert.True(
                            property.GetGetMethod().IsVirtual,
                            $"Getter {type.FullName}.{property.Name} is not virtual");
                        Assert.True(
                            property.GetSetMethod().IsVirtual,
                            $"Setter {type.FullName}.{property.Name} is not virtual");
                    }
                }
            }

#endif
        }
    }
}
