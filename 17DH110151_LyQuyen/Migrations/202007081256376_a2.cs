namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "Gia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Saches", "Gia");
        }
    }
}
