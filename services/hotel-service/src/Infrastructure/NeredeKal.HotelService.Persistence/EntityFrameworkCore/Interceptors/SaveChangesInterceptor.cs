
using Microsoft.EntityFrameworkCore.Diagnostics;
using NeredeKal.HotelService.Domain.Constants;
using NeredeKal.SharedKernel.Entities;
using NeredeKal.SharedKernel.Entities.Abstracts;
using System.Security.AccessControl;

namespace NeredeKal.HotelService.Persistence.EntityFrameworkCore.Interceptors
{
    public sealed class SaveChangesInterceptor : Microsoft.EntityFrameworkCore.Diagnostics.SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var entries = context.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                switch (entry.State)
                {
                    case Microsoft.EntityFrameworkCore.EntityState.Added:
                        if (entity.GetType().BaseType!.IsGenericType &&
    (entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(CreationAuditedEntity<>) ||
     entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(FullAuditedEntity<>) ||
     entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(AggregateRoot<>)))
                        {
                            entity.GetType().GetProperty(DomainConstants.CreationTime)!.SetValue(entity, DateTime.UtcNow);
                        }
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Modified:
                        if (entity.GetType().BaseType!.IsGenericType &&
    (entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(FullAuditedEntity<>) ||
     entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(AggregateRoot<>)))
                        {
                            entity.GetType().GetProperty(DomainConstants.LastModificationTime)!.SetValue(entity, DateTime.UtcNow);
                        }
                        break;
                    case Microsoft.EntityFrameworkCore.EntityState.Deleted:
                        if (entity.GetType().BaseType!.IsGenericType &&
    (entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(FullAuditedEntity<>) ||
     entity.GetType().BaseType!.GetGenericTypeDefinition() == typeof(AggregateRoot<>)) ||
     entity is ISoftDelete)
                        {
                            entity.GetType().GetProperty(DomainConstants.IsDeleted)!.SetValue(entity, true);
                            entity.GetType().GetProperty(DomainConstants.DeletionTime)!.SetValue(entity, DateTime.UtcNow);
                            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                        break;
                }

            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
