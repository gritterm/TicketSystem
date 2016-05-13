namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndAddressAddition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPurchaseLine", "TicketPurchase_ID", "dbo.TicketPurchase");
            DropIndex("dbo.TicketPurchaseLine", new[] { "TicketPurchase_ID" });
            DropColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_ID");
            RenameColumn(table: "dbo.TicketPurchaseLine", name: "TicketPurchase_ID", newName: "Ticket_Purchase_ID");
            DropPrimaryKey("dbo.TicketPurchase");
            AddColumn("dbo.TicketPurchase", "Ticket_Purchase_ID", c => c.Int(nullable: false));
            AddColumn("dbo.TicketPurchase", "Customer_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TicketPurchase", "Ticket_Purchase_ID");
            CreateIndex("dbo.TicketPurchaseLine", "Ticket_Purchase_ID");
            AddForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase", "Ticket_Purchase_ID", cascadeDelete: true);
            DropColumn("dbo.TicketPurchase", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketPurchase", "ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", "dbo.TicketPurchase");
            DropIndex("dbo.TicketPurchaseLine", new[] { "Ticket_Purchase_ID" });
            DropPrimaryKey("dbo.TicketPurchase");
            AlterColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", c => c.Int());
            DropColumn("dbo.TicketPurchase", "Customer_ID");
            DropColumn("dbo.TicketPurchase", "Ticket_Purchase_ID");
            AddPrimaryKey("dbo.TicketPurchase", "ID");
            RenameColumn(table: "dbo.TicketPurchaseLine", name: "Ticket_Purchase_ID", newName: "TicketPurchase_ID");
            AddColumn("dbo.TicketPurchaseLine", "Ticket_Purchase_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.TicketPurchaseLine", "TicketPurchase_ID");
            AddForeignKey("dbo.TicketPurchaseLine", "TicketPurchase_ID", "dbo.TicketPurchase", "ID");
        }
    }
}
