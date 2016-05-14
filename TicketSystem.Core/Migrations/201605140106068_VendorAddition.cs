namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VendorAddition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address");
            DropIndex("dbo.Customer", new[] { "Billing_Address_Address_ID" });
            DropIndex("dbo.Customer", new[] { "Shipping_Address_Address_ID" });
            RenameColumn(table: "dbo.Customer", name: "Billing_Address_Address_ID", newName: "Billing_Address_ID");
            RenameColumn(table: "dbo.Customer", name: "Shipping_Address_Address_ID", newName: "Shipping_Address_ID");
            AlterColumn("dbo.Customer", "Billing_Address_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "Shipping_Address_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "Billing_Address_ID");
            CreateIndex("dbo.Customer", "Shipping_Address_ID");
            AddForeignKey("dbo.Customer", "Billing_Address_ID", "dbo.Address", "Address_ID", cascadeDelete: true);
            AddForeignKey("dbo.Customer", "Shipping_Address_ID", "dbo.Address", "Address_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Shipping_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Billing_Address_ID", "dbo.Address");
            DropIndex("dbo.Customer", new[] { "Shipping_Address_ID" });
            DropIndex("dbo.Customer", new[] { "Billing_Address_ID" });
            AlterColumn("dbo.Customer", "Shipping_Address_ID", c => c.Int());
            AlterColumn("dbo.Customer", "Billing_Address_ID", c => c.Int());
            RenameColumn(table: "dbo.Customer", name: "Shipping_Address_ID", newName: "Shipping_Address_Address_ID");
            RenameColumn(table: "dbo.Customer", name: "Billing_Address_ID", newName: "Billing_Address_Address_ID");
            CreateIndex("dbo.Customer", "Shipping_Address_Address_ID");
            CreateIndex("dbo.Customer", "Billing_Address_Address_ID");
            AddForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address", "Address_ID");
            AddForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address", "Address_ID");
        }
    }
}
