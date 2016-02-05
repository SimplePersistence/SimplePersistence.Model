namespace SimplePersistence.UnitTests.Model
{
#if !DNXCORE50 && !DNX451
    using Fact = NUnit.Framework.TestAttribute;
#else
    using Xunit;
#endif

    public class ImplementationDefinitionTests
    {
        [Fact]
        public void AllPropertiesMustBeVirtual()
        {
            
        }
    }
}
