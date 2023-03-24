using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_Application.Models;
namespace Web_Application.Configurations
{
    public class BillDetailsConfiguration : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            //builder.ToTable("HoaDon"); // Đặt tên bảng
            builder.HasKey(p => p.Id); // Set khóa chính
            // Cấu hình cho thuộc tính
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(p => p.Price).HasColumnType("int").
                IsRequired(); // int not null
            builder.HasOne(p => p.Bill).WithMany(c => c.Details)
                .HasForeignKey(l => l.IdHD);
        }
    }
}
