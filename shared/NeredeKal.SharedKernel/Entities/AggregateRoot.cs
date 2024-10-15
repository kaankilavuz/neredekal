using NeredeKal.SharedKernel.Entities.Abstracts;
using System.Collections.Generic;

namespace NeredeKal.SharedKernel.Entities
{
    public abstract class AggregateRoot<TKey> : FullAuditedEntity<TKey>, IHasExtraProperties
        where TKey : struct
    {
        public IDictionary<string, object> ExtraProperties { get; protected set; }

        protected AggregateRoot()
        {
            ExtraProperties = new Dictionary<string, object>();
        }
    }
}
