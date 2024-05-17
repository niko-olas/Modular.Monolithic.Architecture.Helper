using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modular.Monolithic.Architecture.Helper.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);

        /// <inheritdoc />
        public bool Equals(ValueObject other) => !(other is null) && GetValues().SequenceEqual(other.GetValues());

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetValues().SequenceEqual(other.GetValues());
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return GetValues()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Gets the atomic values of the value object.
        /// </summary>
        /// <returns>The collection of objects representing the value object values.</returns>
        protected abstract IEnumerable<object> GetValues();
    }
}
