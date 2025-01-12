﻿using System;

namespace NeredeKal.SharedKernel.Entities
{
    public abstract class CreationAuditedEntity<TKey> : BaseEntity<TKey>
        where TKey : struct
    {
        public DateTime CreationTime { get; protected set; }
    }
}
