namespace SimplePersistence.Model
{
    /// <summary>
    /// Represents an entity with a unique identifier
    /// </summary>
    /// <typeparam name="TIdentity">The unique identifier type</typeparam>
    public abstract class Entity<TIdentity> : IEntity<TIdentity>
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public virtual TIdentity Id { get; set; }
    }

    /// <summary>
    /// Represents an entity without any unique identifier
    /// </summary>
    public abstract class Entity : IEntity
    {

    }
}
