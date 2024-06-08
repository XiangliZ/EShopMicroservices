﻿
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ordering.Infrastructure.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        { 
            return; 
        }

        foreach(var entry in context.ChangeTracker.Entries<IEntity>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "mehmet";
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }

            if(entry.State == EntityState.Added || entry.State ==EntityState.Modified)
            {
                entry.Entity.LastModifiedBy = "mehmet";
                entry.Entity.LastModified = DateTime.UtcNow;
            }
        }
    }
}