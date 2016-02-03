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
        /// Sets the given <see cref="IHaveDeletedMeta{TDeletedBy}"/> in the deleted state, and sets
        /// the <see cref="IHaveUpdatedMeta{TUpdatedBy}"/> information
        /// </summary>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <param name="on">The <see cref="DateTimeOffset"/> when it was deleted. If null <see cref="DateTimeOffset.Now"/> will be used</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The deleted by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T UpdatedAndDeletedBy<T, TBy>(this T entity, TBy @by = default(TBy), DateTimeOffset? @on = null)
            where T : IHaveDeletedMeta<TBy>, IHaveUpdatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.DeletedOn = entity.UpdatedOn = @on ?? DateTimeOffset.Now;
            entity.DeletedBy = entity.UpdatedBy = @by;
            return entity;
        }

#endif

        /// <summary>
        /// Sets the given <see cref="IHaveLocalDeletedMeta{TDeletedBy}"/> in the deleted state, and sets
        /// the <see cref="IHaveLocalUpdatedMeta{TUpdatedBy}"/> information
        /// </summary>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who deleted the entity</param>
        /// <param name="on">The <see cref="DateTime"/> when it was deleted. If null <see cref="DateTime.UtcNow"/> will be used</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The deleted by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
#if NET20
        public static T UpdatedAndDeletedLocallyBy<T, TBy>(T entity, TBy @by = default(TBy), DateTime? @on = null)
#else
        public static T UpdatedAndDeletedLocallyBy<T, TBy>(this T entity, TBy @by = default(TBy), DateTime? @on = null)
#endif
            where T : IHaveLocalDeletedMeta<TBy>, IHaveLocalUpdatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.DeletedOn = entity.UpdatedOn = @on ?? DateTime.UtcNow;
            entity.DeletedBy = entity.UpdatedBy = @by;
            return entity;
        }
    }
}
