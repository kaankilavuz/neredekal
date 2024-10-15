namespace NeredeKal.SharedKernel.Entities
{
    public abstract class BaseEntity<TKey>
        where TKey : struct
    {
        public TKey Id { get; protected set; }

        protected virtual string Check(string value,
            string property,
            int maxLength = int.MaxValue)
        {
            if (string.IsNullOrEmpty(value))
                throw new System.ArgumentNullException(property);

            if (value.Length > maxLength)
                throw new System.ArgumentOutOfRangeException(property);

            return value;
        }
    }
}
