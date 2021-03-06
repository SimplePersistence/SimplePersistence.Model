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
namespace SimplePersistence.Model
{
    /// <summary>
    /// Represents an entity that has an unique identifier, soft delete and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithSoftDeleteAndVersionAsLong<TIdentity>
        : Entity<TIdentity>, IHaveSoftDelete, IHaveVersionAsLong
    {
        #region Implementation of IHaveSoftDelete

        /// <summary>
        /// Is the entity deleted?
        /// </summary>
        public virtual bool Deleted { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithSoftDeleteAndVersionAsLong()
        {
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithSoftDeleteAndVersionAsLong(TIdentity id) : base(id)
        {
        }
    }
}