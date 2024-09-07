namespace MercadinhoWeb.Infra.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(300).IsRequired();
        builder.Property(x => x.Price).HasColumnName("pu").HasColumnType("decimal(10,2)").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("create_date").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("update_date");
        builder.Property(x => x.Status).HasColumnName("status");
        builder.Property(x => x.CategoryId).HasColumnName("category_id");
    }
}
