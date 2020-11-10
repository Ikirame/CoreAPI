using System;

namespace Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        #region Fields

        public Guid Id { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Check the equality between this instance and another instance of entity class
        /// </summary>
        /// <param name="other">Another instance of entity class</param>
        /// <returns>Result of equality as boolean value</returns>
        public bool Equals(Entity other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return ReferenceEquals(this, other) || Id == other.Id;
        }

        /// <summary>
        /// Check the equality between this instance of entity class and another instance object class
        /// </summary>
        /// <param name="obj">Another instance of object class</param>
        /// <returns>Result of equality as boolean value</returns>
        public override bool Equals(object obj) => Equals(obj as Entity);

        /// <summary>
        /// Get hash code of the entity class
        /// </summary>
        /// <returns>Value of the hash code as integer value</returns>
        public override int GetHashCode() => Id.GetHashCode();

        /// <summary>
        /// Check the equality between two instances of entity class
        /// </summary>
        /// <param name="left">Left side instance of entity class</param>
        /// <param name="right">Right side instance of entity class</param>
        /// <returns>Result of equality as boolean value</returns>
        public static bool operator ==(Entity left, Entity right) => !(left is null) && left.Equals(right);

        /// <summary>
        /// Check the difference between two instances of entity class
        /// </summary>
        /// <param name="left">Left side instance of entity class</param>
        /// <param name="right">Right side instance of entity class</param>
        /// <returns>Result of difference as boolean value</returns>
        public static bool operator !=(Entity left, Entity right) => !(left == right);

        #endregion
    }
}