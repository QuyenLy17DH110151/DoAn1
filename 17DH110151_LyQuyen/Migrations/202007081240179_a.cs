namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "ItemImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Saches", "ItemImageName");
        }
    }
}
