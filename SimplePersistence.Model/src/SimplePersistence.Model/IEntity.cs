namespace SimplePersistence.Model
{
    /// <summary>
    /// Represents an entity with a unique identifier
    /// </summary>
    /// <typeparam name="TIdentity">The unique identifier type</typeparam>
    public interface IEntity<TIdentity> : IEntity
    {
        TIdentity Id { get; set; }
    }

    /// <summary>
    /// Represents an entity
    /// </summary>
    public interface IEntity
    {

    }
}
