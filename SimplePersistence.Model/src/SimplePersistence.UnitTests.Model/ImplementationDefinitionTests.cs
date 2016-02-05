#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 SimplePersistence
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
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
