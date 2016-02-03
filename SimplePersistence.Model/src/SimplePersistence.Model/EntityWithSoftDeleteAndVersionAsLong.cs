namespace SimplePersistence.Model
{
    /// <summary>
    /// Represents an entity that has an unique identifier, soft delete and version info, 
    /// using a long for the <see cref="IHaveVersion{T}.Version"/>.
    /// </summary>
    /// <typeparam name="TIdentity">The identifier type</typeparam>
    public abstract class EntityWithSoftDeleteAndVersionAsLong<TIdentity>
        : Entity<TIdentity>, IHaveSoftDelete, IHaveVersion<long>
    {
        #region Implementation of IHaveSoftDelete

        /// <summary>
        /// Is the entity deleted?
        /// </summary>
        public virtual bool Deleted { get; set; }

        #endregion

        #region Implementation of IHaveVersion<TVersion>

        /// <summary>
        /// The entity version
        /// </summary>
        public virtual long Version { get; set; }

        #endregion
    }
}