namespace SchoolForum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bhjknm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMessagesVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CategoryName = c.String(),
                        MessageId = c.Int(nullable: false),
                        MessageTitle = c.String(),
                        MessageDetails = c.String(),
                        PostedBy = c.String(),
                        PostDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoryMessagesVMs");
        }
    }
}
