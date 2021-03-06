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
    /// Represents an entity that has an unique identifier, local created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    /// <typeparam name="TUpdatedBy">The updated by type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedBy, TUpdatedBy>
        : Entity<TIdentity>, IHaveLocalCreatedMeta<TCreatedBy>, IHaveLocalUpdatedMeta<TUpdatedBy>, IHaveVersionAsLong
    {
        private DateTime _createdOn;
        private DateTime _updatedOn;

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

        #region Implementation of IHaveLocalUpdatedMeta<TUpdatedBy>

        /// <summary>
        /// The <see cref="DateTime"/> when it was last updated
        /// </summary>
        public virtual DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// The identifier (or entity) which last updated this entity
        /// </summary>
        public virtual TUpdatedBy UpdatedBy { get; set; }

        #endregion

        #region Implementation of IHaveVersionAsLong

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTime.Now"/>
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {
            _createdOn = _updatedOn = DateTime.Now;
        }

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTime.Now"/>
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            _createdOn = _updatedOn = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedAndUpdated">The created, updated and deleted by type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedAndUpdated>
        : EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, TCreatedAndUpdated, TCreatedAndUpdated>
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {
            
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {
            
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated metadata and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/> and a <see cref="string"/> as an 
    /// identifier for the <see cref="IHaveLocalCreatedMeta{T}.CreatedBy"/>,
    /// and <see cref="IHaveLocalUpdatedMeta{T}.UpdatedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity>
        : EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong<TIdentity, string, string>, IHaveLocalCreatedMeta, IHaveLocalUpdatedMeta
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong()
        {

        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The entity id</param>
        protected EntityWithLocalCreatedAndUpdatedMetaAndVersionAsLong(TIdentity id)
            : base(id)
        {

        }
    }
}
