﻿namespace SimplePersistence.Model
{
    using System;

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedBy">The created by type</typeparam>
    /// <typeparam name="TUpdatedBy">The updated by type</typeparam>
    /// <typeparam name="TDeletedBy">The deleted by type</typeparam>
    public abstract class EntityWithAllLocalMeta<TIdentity, TCreatedBy, TUpdatedBy, TDeletedBy>
        : Entity<TIdentity>, IHaveLocalCreatedMeta<TCreatedBy>, IHaveLocalUpdatedMeta<TUpdatedBy>, IHaveLocalDeletedMeta<TDeletedBy>
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

        #region Implementation of IHaveLocalDeletedMeta<TDeletedBy>

        /// <summary>
        /// The <see cref="DateTime"/> when it was soft deleted
        /// </summary>
        public virtual DateTime? DeletedOn { get; set; }

        /// <summary>
        /// The identifier (or entity) which soft deleted this entity
        /// </summary>
        public virtual TDeletedBy DeletedBy { get; set; }

        #endregion

        /// <summary>
        /// Creates a new instance and sets the <see cref="CreatedOn"/> and 
        /// <see cref="UpdatedOn"/> to <see cref="DateTime.Now"/>
        /// </summary>
        protected EntityWithAllLocalMeta()
        {
            _createdOn = _updatedOn = DateTime.Now;
        }
    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    /// <typeparam name="TCreatedUpdatedAndDeleted">The created, updated and deleted by type</typeparam>
    public abstract class EntityWithAllLocalMeta<TIdentity, TCreatedUpdatedAndDeleted>
        : EntityWithAllLocalMeta<TIdentity, TCreatedUpdatedAndDeleted, TCreatedUpdatedAndDeleted, TCreatedUpdatedAndDeleted>
    {

    }

    /// <summary>
    /// Represents an entity that has an unique identifier, created, updated and deleted metadata,
    /// using a <see cref="string"/> as an identifier for the <see cref="IHaveLocalCreatedMeta{T}.CreatedBy"/>,
    /// <see cref="IHaveLocalUpdatedMeta{T}.UpdatedBy"/> and <see cref="IHaveLocalDeletedMeta{T}.DeletedBy"/>
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithAllLocalMeta<TIdentity>
        : EntityWithAllLocalMeta<TIdentity, string, string, string>, IHaveLocalCreatedMeta, IHaveLocalUpdatedMeta, IHaveLocalDeletedMeta
    {

    }
}
