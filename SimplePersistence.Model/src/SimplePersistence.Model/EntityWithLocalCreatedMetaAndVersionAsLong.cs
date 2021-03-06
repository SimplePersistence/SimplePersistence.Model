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
    using System;

    /// <summary>
    /// Represents an entity that has an unique identifier, local created metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    public abstract class EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity, TCreatedBy>
        : Entity<TIdentity>, IHaveLocalCreatedMeta<TCreatedBy>, IHaveVersionAsLong
    {
        private DateTime _createdOn;

        #region Implementation of IHaveLocalCreatedMeta<TCreatedBy>

        /// <summary>
        /// The <see cref="DateTime"/> when it was created
        /// </summary>
        public virtual DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which first created this entity
        /// </summary>
        public virtual TCreatedBy CreatedBy { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> 
        /// to <see cref="DateTime.Now"/>
        /// </summary>
        protected EntityWithLocalCreatedMetaAndVersionAsLong()
        {
            _createdOn = DateTime.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> 
        /// to <see cref="DateTime.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            _createdOn = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveLocalCreatedMeta{T}.CreatedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity>
        : EntityWithLocalCreatedMetaAndVersionAsLong<TIdentity, string>, IHaveLocalCreatedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedMetaAndVersionAsLong()
        {
            
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id"></param>
        protected EntityWithLocalCreatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            
        }
    }
}
