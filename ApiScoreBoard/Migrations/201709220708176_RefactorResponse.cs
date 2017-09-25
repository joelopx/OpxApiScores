namespace ApiScoreBoard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorResponse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ResponseModels", "Accept", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ResponseModels", "Accept");
        }
    }
}
