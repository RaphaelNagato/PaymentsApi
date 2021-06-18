using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessPayment.Models;
using System;

namespace ProcessPayment.Data.config
{
    class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.CreditCardNumber).IsRequired().HasMaxLength(16);
            builder.Property(p => p.CardHolder).IsRequired().HasMaxLength(25);
            builder.Property(p => p.ExpirationDate).IsRequired();
            builder.Property(p => p.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Status).HasConversion(
                s => s.ToString(),
                s => (PaymentState) Enum.Parse(typeof(PaymentState), s));

        }
    }
}
