﻿#region License
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

#if !NET20

        /// <summary>
        /// Checks who created the <see cref="IHaveCreatedMeta{TCreatedBy}"/> instance.
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <param name="by">Who created the entity</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static bool WasCreatedBy<T, TBy>(this T entity, TBy by)
            where T : IHaveCreatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.CreatedBy.Equals(by);
        }

#endif

        /// <summary>
        /// Checks who created the <see cref="IHaveLocalCreatedMeta{TCreatedBy}"/> instance.
        /// </summary>
        /// <param name="entity">The entity to check</param>
        /// <param name="by">Who created the entity</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
#if NET20
        public static bool WasCreatedLocallyBy<T, TBy>(T entity, TBy by)
#else
        public static bool WasCreatedLocallyBy<T, TBy>(this T entity, TBy by)
#endif
            where T : IHaveLocalCreatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return entity.CreatedBy.Equals(by);
        }
    }
}
