using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_Application.Models;
namespace Web_Application.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p=> p.Description).
                HasMaxLength(1000).IsFixedLength().IsUnicode();// nvarchar(1000)
        }
    }
}
