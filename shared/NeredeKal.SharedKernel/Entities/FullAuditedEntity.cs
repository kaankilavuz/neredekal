using NeredeKal.SharedKernel.Entities.Abstracts;
using System;

namespace NeredeKal.SharedKernel.Entities
{
    public abstract class FullAuditedEntity<TKey> : CreationAuditedEntity<TKey>, ISoftDelete
        where TKey : struct
    {
        public DateTime? LastModificationTime { get; protected set; }
        public DateTime? DeletionTime { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
