using System;

namespace Domain.ValueObjects
{
    public abstract class ValueObject<T> : IEquatable<ValueObject<T>>
        where T : ValueObject<T>
    {
        #region Methods

        /// <summary>
        /// Check the equality between this specific instance and another instance of value object class
        /// </summary>
        /// <param name="other">Another instance of value object class</param>
        /// <returns>Result of equality as boolean value</returns>
        protected abstract bool EqualsCore(T other);

        /// <summary>
        /// Get hash code of the specific value object class
        /// </summary>
        /// <returns>Value of the hash code as integer value</returns>
        protected abstract int GetHashCodeCore();

        /// <summary>
        /// Check the equality between this instance and another instance of value object class
        /// </summary>
        /// <param name="other">Another instance of value object class</param>
        /// <returns>Result of equality as boolean value</returns>
        public bool Equals(ValueObject<T> other) => !(other is null) && EqualsCore(other as T);

        /// <summary>
        /// Check the equality between this instance of value object and another instance object class
        /// </summary>
        /// <param name="obj">Another instance of object class</param>
        /// <returns>Result of equality as boolean value</returns>
        public override bool Equals(object obj) => Equals(obj as ValueObject<T>);

        /// <summary>
        /// Get hash code of the value object class
        /// </summary>
        /// <returns>Value of the hash code as integer value</returns>
        public override int GetHashCode() => GetHashCodeCore();

        /// <summary>
        /// Check the equality between two instances of value object class
        /// </summary>
        /// <param name="left">Left side instance of value object class</param>
        /// <param name="right">Right side instance of value object class</param>
        /// <returns>Result of equality as boolean value</returns>
        public static bool operator ==(ValueObject<T> left, ValueObject<T> right) =>
            !(left is null) && left.Equals(right);

        /// <summary>
        /// Check the difference between two instances of value object class
        /// </summary>
        /// <param name="left">Left side instance of value object class</param>
        /// <param name="right">Right side instance of value object class</param>
        /// <returns>Result of difference as boolean value</returns>
        public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);

        #endregion
    }
}