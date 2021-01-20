namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "Role", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "Role", c => c.String(nullable: false));
        }
    }
}
