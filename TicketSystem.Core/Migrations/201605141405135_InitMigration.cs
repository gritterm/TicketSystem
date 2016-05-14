namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Address_ID = c.Int(nullable: false, identity: true),
                        Address_1 = c.String(maxLength: 100),
                        Address_2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        GeographicalRegion = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Address_ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false, identity: true),
                        Customer_Name = c.String(maxLength: 100),
                        Billing_Address_ID = c.Int(),
                        Shipping_Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Customer_ID)
                .ForeignKey("dbo.Address", t => t.Billing_Address_ID)
                .ForeignKey("dbo.Address", t => t.Shipping_Address_ID)
                .Index(t => t.Billing_Address_ID)
                .Index(t => t.Shipping_Address_ID);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Event_ID = c.Int(nullable: false, identity: true),
                        Event_Type_ID = c.Int(nullable: false),
                        Venue_ID = c.Int(nullable: false),
                        Event_Name = c.String(maxLength: 150),
                        Event_Date = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Event_ID)
                .ForeignKey("dbo.EventType", t => t.Event_Type_ID, cascadeDelete: true)
                .ForeignKey("dbo.Venue", t => t.Venue_ID, cascadeDelete: true)
                .Index(t => t.Event_Type_ID)
                .Index(t => t.Venue_ID);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        Event_Type_ID = c.Int(nullable: false, identity: true),
                        Event_Type_Name = c.String(),
                    })
                .PrimaryKey(t => t.Event_Type_ID);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Venue_ID = c.Int(nullable: false, identity: true),
                        Address_ID = c.Int(),
                        Venue_Name = c.String(),
                    })
                .PrimaryKey(t => t.Venue_ID)
                .ForeignKey("dbo.Address", t => t.Address_ID)
                .Index(t => t.Address_ID);
            
            CreateTable(
                "dbo.RefreshToken",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false),
                        ExpiresUtc = c.DateTime(nullable: false),
                        ProtectedTicket = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.TicketPurchaseLine",
                c => new
                    {
                        Ticket_Purchase_Line_ID = c.Int(nullable: false, identity: true),
                        Ticket_Purchase_ID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Event_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Ticket_Purchase_Line_ID)
                .ForeignKey("dbo.Event", t => t.Event_ID)
                .ForeignKey("dbo.TicketPurchase", t => t.Ticket_Purchase_ID, cascadeDelete: true)
                .Index(t => t.Ticket_Purchase_ID)
                .Index(t => t.Event_ID);
            
            CreateTable(
                "dbo.TicketPurchase",
                c => new
                    {
                        Ticket_Purchase_ID = c.Int(nullable: false, identity: true),
                        Customer_ID = c.Int(),
                        Customer_Name = c.String(),
                        Total = c.Int(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Ticket_Purchase_ID)
                .ForeignKey("dbo.Customer", t => t.Customer_ID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.TicketReceipt",
                c => new
                    {
                        Ticket_Receipt_ID = c.Int(nullable: false, identity: true),
                        Ticket_Quantity = c.Int(nullable: false),
                        Venue_ID = c.Int(),
                        Event_ID = c.Int(),
                        Vendor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Ticket_Receipt_ID)
                .ForeignKey("dbo.Event", t => t.Event_ID)
                .ForeignKey("dbo.Vendor", t => t.Vendor_ID)
                .ForeignKey("dbo.Venue", t => t.Venue_ID)
                .Index(t => t.Venue_ID)
                .Index(t => t.Event_ID)
                .Index(t => t.Vendor_ID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        Vendor_ID = c.Int(nullable: false, identity: true),
                        Vendor_Name = c.String(maxLength: 100),
                        Buy_From_Address_ID = c.Int(),
                        Pay_To_Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Vendor_ID)
                .ForeignKey("dbo.Address", t => t.Buy_From_Address_ID)
                .ForeignKey("dbo.Address", t => t.Pay_To_Address_ID)
                .Index(t => t.Buy_From_Address_ID)
                .Index(t => t.Pay_To_Address_ID);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUser", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserLogin", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserClaim", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.TicketReceipt", "Venue_ID", "dbo.Venue");
            DropForeignKey("dbo.TicketReceipt", "Vendor_ID", "dbo.Vendor");
            DropForeignKey("dbo.Vendor", "Pay_To_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Vendor", "Buy_From_Address_ID", "dbo.Address");
            DropForeignKey("dbo.TicketReceipt", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase");
            DropForeignKey("dbo.TicketPurchase", "Customer_ID", "dbo.Customer");
            DropForeignKey("dbo.TicketPurchaseLine", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Event", "Venue_ID", "dbo.Venue");
            DropForeignKey("dbo.Venue", "Address_ID", "dbo.Address");
            DropForeignKey("dbo.Event", "Event_Type_ID", "dbo.EventType");
            DropForeignKey("dbo.Customer", "Shipping_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Billing_Address_ID", "dbo.Address");
            DropIndex("dbo.IdentityUserLogin", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Vendor", new[] { "Pay_To_Address_ID" });
            DropIndex("dbo.Vendor", new[] { "Buy_From_Address_ID" });
            DropIndex("dbo.TicketReceipt", new[] { "Vendor_ID" });
            DropIndex("dbo.TicketReceipt", new[] { "Event_ID" });
            DropIndex("dbo.TicketReceipt", new[] { "Venue_ID" });
            DropIndex("dbo.TicketPurchase", new[] { "Customer_ID" });
            DropIndex("dbo.TicketPurchaseLine", new[] { "Event_ID" });
            DropIndex("dbo.TicketPurchaseLine", new[] { "Ticket_Purchase_ID" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Venue", new[] { "Address_ID" });
            DropIndex("dbo.Event", new[] { "Venue_ID" });
            DropIndex("dbo.Event", new[] { "Event_Type_ID" });
            DropIndex("dbo.Customer", new[] { "Shipping_Address_ID" });
            DropIndex("dbo.Customer", new[] { "Billing_Address_ID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.Vendor");
            DropTable("dbo.TicketReceipt");
            DropTable("dbo.TicketPurchase");
            DropTable("dbo.TicketPurchaseLine");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.RefreshToken");
            DropTable("dbo.Venue");
            DropTable("dbo.EventType");
            DropTable("dbo.Event");
            DropTable("dbo.Customer");
            DropTable("dbo.Client");
            DropTable("dbo.Address");
        }
    }
}
