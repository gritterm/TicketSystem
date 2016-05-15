namespace TicketSystem.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "Customer_Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Customer_Name", c => c.String(maxLength: 100));
        }
    }
}
