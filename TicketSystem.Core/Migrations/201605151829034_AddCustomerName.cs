namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Customer_Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Customer_Email");
        }
    }
}
