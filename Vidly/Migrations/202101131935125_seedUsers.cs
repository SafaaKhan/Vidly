namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8bafdc38-cad1-4695-9312-3a1ff0de2b40', N'admin@vidly.com', 0, N'AAgC7Br25vT6oOdD/HXj8Kjak0T0hLLT8xJzpQto5xlhG8EAUsAnMxpUjBLY9gwr7w==', N'9c81f54b-0895-4294-8867-bf23facb5076', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'90def842-307f-4d9f-8aff-8bfa4ec9a4a4', N'guest@gmail.com', 0, N'AHsbtPxtcCv3xGtWWSZHNabWQy33J3FF+yI4bH5bRYfJqxIpduqU7zpsGP/kryCyxQ==', N'895020d4-f9bf-4d70-a97e-db62a8d8a24d', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2625b3d4-61dd-4269-8c82-e8c7c1195fc5', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8bafdc38-cad1-4695-9312-3a1ff0de2b40', N'2625b3d4-61dd-4269-8c82-e8c7c1195fc5')


");
        }
        
        public override void Down()
        {
        }
    }
}
