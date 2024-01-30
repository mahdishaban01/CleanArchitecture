namespace HR_Management.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id= "05446344-f9cc-4566-bd2c-36791b4e28ed",
                    Email="admin@localhost.com",
                    NormalizedEmail="ADMIN@LOCALHOST.COM",
                    FirstName="Admin",
                    LastName="Adminian",
                    UserName= "admin@localhost.com",
                    NormalizedUserName= "ADMIN@LOCALHOST.COM",
                    PasswordHash=hasher.HashPassword(null,"P@ssword1"),
                    EmailConfirmed=true,
                },
                 new ApplicationUser
                 {
                     Id = "2ec9f480-7288-4d0f-a1cd-53cc89968b45",
                     Email = "user@localhost.com",
                     NormalizedEmail = "USER@LOCALHOST.COM",
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@localhost.com",
                     NormalizedUserName = "USER@LOCALHOST.COM",
                     PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                     EmailConfirmed = true,
                 }
                );
        }
    }
}
