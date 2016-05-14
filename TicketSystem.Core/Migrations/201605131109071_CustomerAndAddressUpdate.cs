namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndAddressUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Address_ID = c.Int(nullable: false),
                        Address_1 = c.String(maxLength: 100),
                        Address_2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        GeographicalRegion = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Address_ID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Customer_ID = c.Int(nullable: false),
                        Customer_Name = c.String(maxLength: 100),
                        Billing_Address_Address_ID = c.Int(),
                        Shipping_Address_Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Customer_ID)
                .ForeignKey("dbo.Address", t => t.Billing_Address_Address_ID)
                .ForeignKey("dbo.Address", t => t.Shipping_Address_Address_ID)
                .Index(t => t.Billing_Address_Address_ID)
                .Index(t => t.Shipping_Address_Address_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address");
            DropIndex("dbo.Customer", new[] { "Shipping_Address_Address_ID" });
            DropIndex("dbo.Customer", new[] { "Billing_Address_Address_ID" });
            DropTable("dbo.Customer");
            DropTable("dbo.Address");
        }
    }
}
