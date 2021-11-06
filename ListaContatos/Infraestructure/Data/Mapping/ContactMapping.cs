using ContactsList.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactsList.Infraestructure.Data.Mapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        /// <summary>
        /// Definição da tabela Contacts
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("TB_CONTACTS");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name);
            builder.Property(c => c.Email);
            builder.Property(c => c.phoneNumber);
        }
    }
}
