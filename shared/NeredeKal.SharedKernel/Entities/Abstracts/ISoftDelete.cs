using System;

namespace NeredeKal.SharedKernel.Entities.Abstracts
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        DateTime? DeletionTime { get; }
    }
}

