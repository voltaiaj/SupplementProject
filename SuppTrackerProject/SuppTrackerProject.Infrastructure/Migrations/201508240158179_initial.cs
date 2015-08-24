namespace SuppTrackerProject.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplements",
                c => new
                    {
                        SupplementId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Manufacturer = c.String(nullable: false),
                        Servings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplementId);
            
            CreateTable(
                "dbo.SupplementUsers",
                c => new
                    {
                        SuppUserId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        SupplementId = c.Int(nullable: false),
                        ServingsPerDay = c.Double(nullable: false),
                        EmptyWeight = c.Double(nullable: false),
                        PartialWeight = c.Double(nullable: false),
                        FullWeight = c.Double(nullable: false),
                        NumberOfNew = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SuppUserId)
                .ForeignKey("dbo.Supplements", t => t.SupplementId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SupplementId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PasswordHash = c.String(maxLength: 4000),
                        SecurityStamp = c.String(maxLength: 4000),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Claim",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(maxLength: 4000),
                        ClaimValue = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClaimId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ExternalLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplementUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.ExternalLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Claim", "UserId", "dbo.User");
            DropForeignKey("dbo.SupplementUsers", "SupplementId", "dbo.Supplements");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.ExternalLogin", new[] { "UserId" });
            DropIndex("dbo.Claim", new[] { "UserId" });
            DropIndex("dbo.SupplementUsers", new[] { "SupplementId" });
            DropIndex("dbo.SupplementUsers", new[] { "UserId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.ExternalLogin");
            DropTable("dbo.Claim");
            DropTable("dbo.User");
            DropTable("dbo.SupplementUsers");
            DropTable("dbo.Supplements");
        }
    }
}
