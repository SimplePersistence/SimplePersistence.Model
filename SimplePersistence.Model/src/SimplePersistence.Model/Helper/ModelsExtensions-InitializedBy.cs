﻿namespace SimplePersistence.Model.Helper
{
    using System;

    /// <summary>
    /// Models extension methods
    /// </summary>
    public static partial class ModelsExtensions
    {

#if !NET20

        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveCreatedMeta{TCreatedBy}"/> and <see cref="IHaveUpdatedMeta{TUpdatedBy}"/>
        /// </summary>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <param name="on">The <see cref="DateTimeOffset"/> when it was created. If null <see cref="DateTimeOffset.Now"/> will be used</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T InitializedBy<T, TBy>(this T entity, TBy @by = default(TBy), DateTimeOffset? @on = null)
            where T : IHaveCreatedMeta<TBy>, IHaveUpdatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedOn = entity.UpdatedOn = @on ?? DateTimeOffset.Now;
            entity.CreatedBy = entity.UpdatedBy = @by;
            return entity;
        }

#endif

        /// <summary>
        /// Fills all metadata of a given <see cref="IHaveLocalCreatedMeta{TCreatedBy}"/> and <see cref="IHaveLocalUpdatedMeta{TUpdatedBy}"/>
        /// </summary>
        /// <param name="entity">The entity to fill</param>
        /// <param name="by">Who created the entity</param>
        /// <param name="on">The <see cref="DateTime"/> when it was created. If null <see cref="DateTime.UtcNow"/> will be used</param>
        /// <typeparam name="T">The entity type</typeparam>
        /// <typeparam name="TBy">The created by type</typeparam>
        /// <returns>The received entity after changes</returns>
        /// <exception cref="ArgumentNullException"/>
        public static T InitializedBy<T, TBy>(this T entity, TBy @by = default(TBy), DateTime? @on = null)
            where T : IHaveLocalCreatedMeta<TBy>, IHaveLocalUpdatedMeta<TBy>
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            entity.CreatedOn = entity.UpdatedOn = @on ?? DateTime.UtcNow;
            entity.CreatedBy = entity.UpdatedBy = @by;
            return entity;
        }
    }
}
