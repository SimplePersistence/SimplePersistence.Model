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
namespace SimplePersistence.Model
{
    using System;

#if !NET20

    /// <summary>
    /// Represents an entity that has an unique identifier, deleted metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TDeletedBy">The deleted by type</typeparam>
    public abstract class EntityWithDeletedMetaAndVersionAsLong<TIdentity, TDeletedBy>
        :Entity<TIdentity>, IHaveDeletedMeta<TDeletedBy>, IHaveVersionAsLong
    {
        #region Implementation of IHaveDeletedMeta<TDeletedBy>

        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was soft deleted
        /// </summary>
        public virtual DateTimeOffset? DeletedOn { get; set; }

        /// <summary>
        /// The identifier (or entity) which soft deleted this entity
        /// </summary>
        public virtual TDeletedBy DeletedBy { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated, deleted metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveDeletedMeta{T}.DeletedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithDeletedMetaAndVersionAsLong<TIdentity>
        : EntityWithDeletedMetaAndVersionAsLong<TIdentity, string>, IHaveDeletedMeta
    {

    }

#endif
}
