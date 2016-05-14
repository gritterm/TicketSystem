namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVenueAndSwitchToIdentities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.TicketPurchaseLine", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.Event", "Event_Type_ID", "dbo.EventType");
            DropForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase");
            DropPrimaryKey("dbo.Address");
            DropPrimaryKey("dbo.Customer");
            DropPrimaryKey("dbo.Event");
            DropPrimaryKey("dbo.EventType");
            DropPrimaryKey("dbo.TicketPurchaseLine");
            DropPrimaryKey("dbo.TicketPurchase");
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        Venue_ID = c.Int(nullable: false, identity: true),
                        Address_ID = c.Int(nullable: false),
                        Venue_Name = c.String(),
                    })
                .PrimaryKey(t => t.Venue_ID)
                .ForeignKey("dbo.Address", t => t.Address_ID, cascadeDelete: true)
                .Index(t => t.Address_ID);
            
            AddColumn("dbo.Event", "Venue_ID", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Event_Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Address", "Address_ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customer", "Customer_ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Event", "Event_ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Event", "Event_Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.EventType", "Event_Type_ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_Line_ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TicketPurchase", "Ticket_Purchase_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Address", "Address_ID");
            AddPrimaryKey("dbo.Customer", "Customer_ID");
            AddPrimaryKey("dbo.Event", "Event_ID");
            AddPrimaryKey("dbo.EventType", "Event_Type_ID");
            AddPrimaryKey("dbo.TicketPurchaseLine", "Ticket_Purchase_Line_ID");
            AddPrimaryKey("dbo.TicketPurchase", "Ticket_Purchase_ID");
            CreateIndex("dbo.Event", "Venue_ID");
            AddForeignKey("dbo.Event", "Venue_ID", "dbo.Venue", "Venue_ID", cascadeDelete: true);
            AddForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address", "Address_ID");
            AddForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address", "Address_ID");
            AddForeignKey("dbo.TicketPurchaseLine", "Event_ID", "dbo.Event", "Event_ID", cascadeDelete: true);
            AddForeignKey("dbo.Event", "Event_Type_ID", "dbo.EventType", "Event_Type_ID", cascadeDelete: true);
            AddForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase", "Ticket_Purchase_ID", cascadeDelete: true);
            DropColumn("dbo.Event", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "Location", c => c.String());
            DropForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase");
            DropForeignKey("dbo.Event", "Event_Type_ID", "dbo.EventType");
            DropForeignKey("dbo.TicketPurchaseLine", "Event_ID", "dbo.Event");
            DropForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address");
            DropForeignKey("dbo.Event", "Venue_ID", "dbo.Venue");
            DropForeignKey("dbo.Venue", "Address_ID", "dbo.Address");
            DropIndex("dbo.Venue", new[] { "Address_ID" });
            DropIndex("dbo.Event", new[] { "Venue_ID" });
            DropPrimaryKey("dbo.TicketPurchase");
            DropPrimaryKey("dbo.TicketPurchaseLine");
            DropPrimaryKey("dbo.EventType");
            DropPrimaryKey("dbo.Event");
            DropPrimaryKey("dbo.Customer");
            DropPrimaryKey("dbo.Address");
            AlterColumn("dbo.TicketPurchase", "Ticket_Purchase_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_Line_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.EventType", "Event_Type_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "Event_Name", c => c.String());
            AlterColumn("dbo.Event", "Event_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "Customer_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Address", "Address_ID", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "Event_Date");
            DropColumn("dbo.Event", "Venue_ID");
            DropTable("dbo.Venue");
            AddPrimaryKey("dbo.TicketPurchase", "Ticket_Purchase_ID");
            AddPrimaryKey("dbo.TicketPurchaseLine", "Ticket_Purchase_Line_ID");
            AddPrimaryKey("dbo.EventType", "Event_Type_ID");
            AddPrimaryKey("dbo.Event", "Event_ID");
            AddPrimaryKey("dbo.Customer", "Customer_ID");
            AddPrimaryKey("dbo.Address", "Address_ID");
            AddForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase", "Ticket_Purchase_ID", cascadeDelete: true);
            AddForeignKey("dbo.Event", "Event_Type_ID", "dbo.EventType", "Event_Type_ID", cascadeDelete: true);
            AddForeignKey("dbo.TicketPurchaseLine", "Event_ID", "dbo.Event", "Event_ID", cascadeDelete: true);
            AddForeignKey("dbo.Customer", "Shipping_Address_Address_ID", "dbo.Address", "Address_ID");
            AddForeignKey("dbo.Customer", "Billing_Address_Address_ID", "dbo.Address", "Address_ID");
        }
    }
}
