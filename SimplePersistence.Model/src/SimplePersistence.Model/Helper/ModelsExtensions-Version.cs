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
namespace SimplePersistence.Model.Helper
{
    using System;

    /// <summary>
    /// Models extension methods
    /// </summary>
    public static partial class ModelsExtensions
    {
        /// <summary>
        /// Replaces the content of a given <see cref="IHaveVersion{TVersion}.Version"/> byte[] 
        /// with the given one.
        /// </summary>
        /// <typeparam name="TEntity">The entity type</typeparam>
        /// <param name="entity">The entity to be used</param>
        /// <param name="version">The version to be replaced with</param>
        /// <returns>The entity after changes</returns>
        /// <exception cref="ArgumentNullException">Thrown if any of the parameters are null</exception>
        /// <exception cref="ArgumentException">Thrown if the arrays length does not match</exception>
#if NET20
        public static TEntity ByteArrayVersion<TEntity>(TEntity entity, byte[] version)
#else
        public static TEntity ByteArrayVersion<TEntity>(this TEntity entity, byte[] version)
#endif
            where TEntity : IHaveVersion<byte[]>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (version == null) throw new ArgumentNullException(nameof(version));
            if (entity.Version.Length != version.Length)
                throw new ArgumentException(
                    $"Entity version length [{entity.Version.Length}] does not match with the recieved [{version.Length}]",
                    nameof(version));

            Array.Copy(version, entity.Version, entity.Version.Length);
            return entity;
        }
    }
}
