using hangfire_template.Models;
using Microsoft.EntityFrameworkCore;

namespace hangfire_template.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // --- Model-model untuk OpenProject & Trello Integration ---
    public virtual DbSet<TWorkPackage> TWorkPackages { get; set; }
    public virtual DbSet<TlkpUserMapping> TlkpUserMappings { get; set; }
    public virtual DbSet<TSyncLog> TSyncLogs { get; set; }
    public virtual DbSet<TProject> TProjects { get; set; }
    public virtual DbSet<TStatus> TStatuses { get; set; }
    public virtual DbSet<TUser> TUsers { get; set; }
    public virtual DbSet<TComment> TComments { get; set; }
    public virtual DbSet<TChecklist> TChecklists { get; set; }
    public virtual DbSet<TChecklistItem> TChecklistItems { get; set; }
    public virtual DbSet<TTimeEntry> TTimeEntries { get; set; }

    // --- Model-model lama (legacy tables) ---
    public DbSet<TempListDataRejectPortal>? TempListDataRejectPortal { get; set; }
    public DbSet<Master_ttfbgc4008888>? Master_ttfbgc4008888 { get; set; }
    public DbSet<Master_ttfbgc1608888>? Master_ttfbgc1608888 { get; set; }
    public DbSet<Master_ttfbgc1208888>? Master_ttfbgc1208888 { get; set; }
    public DbSet<Master_ttdpur4028888>? Master_ttdpur4028888 { get; set; }
    public DbSet<Master_ttdpur4008888>? Master_ttdpur4008888 { get; set; }
    public DbSet<Master_ttdpur2028888>? Master_ttdpur2028888 { get; set; }
    public DbSet<Master_ttdpur2008888>? Master_ttdpur2008888 { get; set; }
    public DbSet<TempDashboardLineChartSalesOrder>? TempDashboardLineChartSalesOrder { get; set; }
    public DbSet<ListSPCTPAD_ttxmsl4298888>? ListSPCTPAD_ttxmsl4298888 { get; set; }
    public DbSet<ListSPCTPAD_ttxmsl4288888>? ListSPCTPAD_ttxmsl4288888 { get; set; }
    public DbSet<ListSPCTPAD_twhwmd2158888>? ListSPCTPAD_twhwmd2158888 { get; set; }
    public DbSet<ListSPCTPAD_twhinh5218888>? ListSPCTPAD_twhinh5218888 { get; set; }
    public DbSet<ListSPCTPAD_twhinr1108888>? ListSPCTPAD_twhinr1108888 { get; set; }
    public DbSet<ListSPCTPAD_ttcibd0018888>? ListSPCTPAD_ttcibd0018888 { get; set; }
    public DbSet<ListSPCTPAD_ttdpur2018888>? ListSPCTPAD_ttdpur2018888 { get; set; }
    public DbSet<TempListDataRejectPortalDBSQL>? TempListDataRejectPortalDBSQL { get; set; }
    public DbSet<TempListBudget>? TempListBudget { get; set; }
    public DbSet<TempListCustomer>? TempListCustomer { get; set; }
    public DbSet<Table_SPT_STOCK>? Table_SPT_STOCK { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Konfigurasi untuk decimal precision
        modelBuilder.Entity<TempDashboardLineChartSalesOrder>(entity =>
        {
            entity.Property(p => p.delivered_uninvoice).HasPrecision(18, 3);
            entity.Property(p => p.delivered_invoiced).HasPrecision(18, 3);
            entity.Property(p => p.undelivered).HasPrecision(18, 3);
            entity.Property(p => p.cancel_so).HasPrecision(18, 3);
            entity.Property(p => p.avg_value).HasPrecision(18, 3);
        });

        modelBuilder.Entity<TempListBudget>(entity =>
        {
            entity.Property(p => p.budget_amount).HasPrecision(30, 7);
            entity.Property(p => p.order_amount).HasPrecision(30, 7);
        });

        modelBuilder.Entity<TempListDataRejectPortalDBSQL>(entity =>
        {
            entity.Property(p => p.qoor).HasPrecision(18, 3);
        });

        // Konfigurasi untuk Work Package relationships
        modelBuilder.Entity<TWorkPackage>(entity =>
        {
            entity.HasOne(w => w.Project)
                .WithMany()
                .HasForeignKey(w => w.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(w => w.Status)
                .WithMany()
                .HasForeignKey(w => w.StatusId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(w => w.Assignee)
                .WithMany()
                .HasForeignKey(w => w.AssigneeId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(w => w.Comments)
                .WithOne(c => c.WorkPackage)
                .HasForeignKey(c => c.WorkPackageId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(w => w.Checklists)
                .WithOne(c => c.WorkPackage)
                .HasForeignKey(c => c.WorkPackageId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Checklist items relationship
        modelBuilder.Entity<TChecklist>(entity =>
        {
            entity.HasMany(c => c.Items)
                .WithOne(i => i.Checklist)
                .HasForeignKey(i => i.ChecklistId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
