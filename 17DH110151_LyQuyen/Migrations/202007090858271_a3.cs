namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHangs", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "Role", c => c.String());
            AlterColumn("dbo.KhachHangs", "Password", c => c.String());
            AlterColumn("dbo.KhachHangs", "Username", c => c.String());
        }
    }
}
