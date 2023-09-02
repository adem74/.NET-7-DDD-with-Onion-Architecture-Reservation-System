using Dinner.Domain.Host.ValueObjects;
using Dinner.Domain.Menu;
using Dinner.Domain.Menu.Entities;
using Dinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinner.Infrastructure.Persistence.Configurations;

class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            x => x.MenuReviewIds,
            di =>
            {
                di.ToTable("MenuReviewIds");
                di.WithOwner().HasForeignKey("MenuId");
                di.HasKey("Id");
                di.Property(s => s.Value).HasColumnName("MenuReviewId").ValueGeneratedNever();
            }
        );
        builder.Metadata
            .FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            x => x.DinnerIds,
            di =>
            {
                di.ToTable("MenuDinnerIds");
                di.WithOwner().HasForeignKey("MenuId");
                di.HasKey("Id");
                di.Property(s => s.Value).HasColumnName("DinnerId").ValueGeneratedNever();
            }
        );
        builder.Metadata
            .FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(
            x => x.Sections,
            sb =>
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey("Id", "MenuId");
                sb.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value, value => MenuSectionId.Create(value));
                sb.Property(s => s.Name).HasMaxLength(100);
                sb.Property(s => s.Description).HasMaxLength(100);
                sb.OwnsMany(
                    s => s.Items,
                    mi =>
                    {
                        mi.ToTable("MenuItems");
                        mi.WithOwner().HasForeignKey("MenuSectionId", "MenuId");

                        mi.HasKey(nameof(MenuItem.Id), "MenuSectionId", "MenuId");
                        mi.Property(s => s.Name).HasMaxLength(100);
                        mi.Property(s => s.Description).HasMaxLength(100);
                        mi.Property(s => s.Id)
                            .HasColumnName("MenuItemId")
                            .ValueGeneratedNever()
                            .HasConversion(id => id.Value, value => MenuItemId.Create(value));
                    }
                );
                sb.Navigation(s => s.Items).Metadata.SetField("_items");
                sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
            }
        );
        builder.Metadata
            .FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");
        builder.HasKey(x => x.Id);
        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => MenuId.Create(value));
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.Property(x => x.Description).HasMaxLength(100);
        builder.OwnsOne(x => x.AverageRating);
        builder
            .Property(x => x.HostId)
            .HasConversion(id => id.Value, value => HostId.Create(value));
    }
}
