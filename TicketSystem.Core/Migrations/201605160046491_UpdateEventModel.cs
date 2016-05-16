namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Venue_Name", c => c.String(maxLength: 150));
            AddColumn("dbo.Event", "Event_Type_Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.EventType", "Event_Type_Name", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EventType", "Event_Type_Name", c => c.String());
            DropColumn("dbo.Event", "Event_Type_Name");
            DropColumn("dbo.Event", "Venue_Name");
        }
    }
}
