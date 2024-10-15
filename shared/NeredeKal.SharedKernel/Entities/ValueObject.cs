using System;
using System.Collections.Generic;
using System.Linq;

namespace NeredeKal.SharedKernel.Entities
{
    public abstract class ValueObject
    {
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    return HashCode.Combine(current, obj != null ? obj.GetHashCode() : 0);
                });
        }
        protected abstract IEnumerable<object> GetEqualityComponents();
        protected virtual string Check(string value, string property, int maxLength = int.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(property);

            if (value.Length > maxLength)
                throw new ArgumentOutOfRangeException(property);

            return value;
        }
    }
}
