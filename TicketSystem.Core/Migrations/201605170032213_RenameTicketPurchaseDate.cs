namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTicketPurchaseDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketPurchase", "Ticket_Purchase_Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.TicketPurchase", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketPurchase", "Date", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.TicketPurchase", "Ticket_Purchase_Date");
        }
    }
}
