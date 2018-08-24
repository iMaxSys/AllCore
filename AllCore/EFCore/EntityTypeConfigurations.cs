
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using AllCore.Models;


namespace AllCore.EFCore
{
    /*
     * 
     * Add-Migration v1.0.0
       Update-Database v1.0.0
     
     延迟加载需要引用Microsoft.EntityFrameworkCore.Proxies,导航属性virtual修饰
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
        }
        注意:需要注意循环引用

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

     ================================================================================================

     FluentAPI:
     Has:
     With:
     级联删除:
     使用Code First则会在数据库中设定外接的级联删除模式
     (内存操作&DB First:仅当使用 EF Core 删除主体且将依赖实体加载到内存中（即对于跟踪的依赖项）时才应用 EF Core 模型中配置的删除行为)
     1. DeleteBehavior.Restrict
     删除前检查依赖实体,如果存在外键依赖则不可删除DeleteBehavior.Restrict
     2. DeleteBehavior.Cascade
     删除依赖实体

    */
    public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.ToTable("catalog");
        }
    }

    public class GoodsConfiguration : IEntityTypeConfiguration<Goods>
    {
        public void Configure(EntityTypeBuilder<Goods> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CatalogId).HasColumnName("catalog_id");
            builder.Property(x => x.ActivityItemId).HasColumnName("activity_item_id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).HasColumnName("price").IsRequired().HasColumnType("decimal(10,2)");
            builder.HasOne(x => x.Catalog).WithMany(y => y.Goods).HasForeignKey(k => k.CatalogId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("goods");
        }
    }

    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.ToTable("member");
        }
    }

    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.MemberId).HasColumnName("member_id").IsRequired();
            builder.Property(x => x.GoodsId).HasColumnName("goods_id").IsRequired();
            builder.HasOne(x => x.Member).WithMany(y => y.Carts).HasForeignKey(k => k.MemberId);
            builder.HasOne(x => x.Goods).WithMany().HasForeignKey(k => k.GoodsId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("cart");
        }
    }

    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Start).HasColumnName("start").IsRequired();
            builder.Property(x => x.End).HasColumnName("end").IsRequired();
            builder.Property(x => x.Status).HasColumnName("status").IsRequired().HasDefaultValue(1);
            builder.ToTable("activity");
        }
    }

    public class ActivityItemConfiguration : IEntityTypeConfiguration<ActivityItem>
    {
        public void Configure(EntityTypeBuilder<ActivityItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.ActivityId).HasColumnName("activity_id").IsRequired();
            builder.Property(x => x.GoodsId).HasColumnName("goods_id").IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").IsRequired().HasColumnType("decimal(10,2)");
            builder.HasOne(x => x.Activity).WithMany(y => y.Items).HasForeignKey(k => k.ActivityId).OnDelete(DeleteBehavior.Restrict);
            //one to zero or one
            builder.HasOne(x => x.Goods).WithOne(y => y.ActivityItem).HasForeignKey<ActivityItem>(k => k.GoodsId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("activity_item");
        }
    }
}