namespace SimplePersistence.Model
{
#if !NET20

    using System;

    /// <summary>
    /// Metadata information about the entity creation
    /// </summary>
    /// <typeparam name="TCreatedBy">The identifier or entity type</typeparam>
    public interface IHaveCreatedMeta<TCreatedBy>
    {
        /// <summary>
        /// The <see cref="DateTimeOffset"/> when it was created
        /// </summary>
        DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// The identifier (or entity) which first created this entity
        /// </summary>
        TCreatedBy CreatedBy { get; set; }
    }

#endif

}
