namespace _17DH110151_LyQuyen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CongTyPHs",
                c => new
                    {
                        MaCT = c.Int(nullable: false, identity: true),
                        TenCT = c.String(),
                    })
                .PrimaryKey(t => t.MaCT);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MaSach = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        NgayMua = c.DateTime(nullable: false),
                        MaKH = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH)
                .ForeignKey("dbo.Saches", t => t.MaSach, cascadeDelete: true)
                .Index(t => t.MaSach)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        TenKH = c.String(),
                        DiaChi = c.String(),
                        DT = c.Int(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        MaSach = c.Int(nullable: false, identity: true),
                        TenSach = c.String(),
                        MaTL = c.Int(nullable: false),
                        MaTG = c.Int(nullable: false),
                        NguoiDich = c.String(),
                        MaNXB = c.Int(nullable: false),
                        MaCT = c.Int(nullable: false),
                        NgonNgu = c.String(),
                        TrongLuong = c.Int(nullable: false),
                        KichThuoc = c.String(),
                        SoTrang = c.Int(nullable: false),
                        LoaiBia = c.String(),
                        NgayXB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaSach)
                .ForeignKey("dbo.CongTyPHs", t => t.MaCT, cascadeDelete: true)
                .ForeignKey("dbo.NhaXuatBans", t => t.MaNXB, cascadeDelete: true)
                .ForeignKey("dbo.TacGias", t => t.MaTG, cascadeDelete: true)
                .ForeignKey("dbo.TheLoais", t => t.MaTL, cascadeDelete: true)
                .Index(t => t.MaTL)
                .Index(t => t.MaTG)
                .Index(t => t.MaNXB)
                .Index(t => t.MaCT);
            
            CreateTable(
                "dbo.NhaXuatBans",
                c => new
                    {
                        MaNXB = c.Int(nullable: false, identity: true),
                        TenNXB = c.String(),
                    })
                .PrimaryKey(t => t.MaNXB);
            
            CreateTable(
                "dbo.TacGias",
                c => new
                    {
                        MaTG = c.Int(nullable: false, identity: true),
                        TenTG = c.String(),
                    })
                .PrimaryKey(t => t.MaTG);
            
            CreateTable(
                "dbo.TheLoais",
                c => new
                    {
                        MaTL = c.Int(nullable: false, identity: true),
                        TenTL = c.String(),
                    })
                .PrimaryKey(t => t.MaTL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GioHangs", "MaSach", "dbo.Saches");
            DropForeignKey("dbo.Saches", "MaTL", "dbo.TheLoais");
            DropForeignKey("dbo.Saches", "MaTG", "dbo.TacGias");
            DropForeignKey("dbo.Saches", "MaNXB", "dbo.NhaXuatBans");
            DropForeignKey("dbo.Saches", "MaCT", "dbo.CongTyPHs");
            DropForeignKey("dbo.GioHangs", "MaKH", "dbo.KhachHangs");
            DropIndex("dbo.Saches", new[] { "MaCT" });
            DropIndex("dbo.Saches", new[] { "MaNXB" });
            DropIndex("dbo.Saches", new[] { "MaTG" });
            DropIndex("dbo.Saches", new[] { "MaTL" });
            DropIndex("dbo.GioHangs", new[] { "MaKH" });
            DropIndex("dbo.GioHangs", new[] { "MaSach" });
            DropTable("dbo.TheLoais");
            DropTable("dbo.TacGias");
            DropTable("dbo.NhaXuatBans");
            DropTable("dbo.Saches");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.GioHangs");
            DropTable("dbo.CongTyPHs");
        }
    }
}
