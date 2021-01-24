using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _17DH110151_LyQuyen.Models
{
    public class CSDL:DbContext
    {
        public CSDL()
        {
            //SqlConnectionStringBuilder s = new SqlConnectionStringBuilder();
            //s.DataSource = ".";
            //s.InitialCatalog = "LyQuyenx";
            //s.IntegratedSecurity = true;
            //Database.Connection.ConnectionString = s.ConnectionString;
            Database.Connection.ConnectionString = "workstation id=dbsachquyen.mssql.somee.com;packet size=4096;user id=quyenly151_SQLLogin_1;pwd=yllavkxfgq;data source=dbsachquyen.mssql.somee.com;persist security info=False;initial catalog=dbsachquyen";

        }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<TacGia> TacGias { get; set; }
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<CongTyPH> CongTyPHs { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
    }

    public class TheLoai
    {
        [Key]
        public int MaTL { get; set; }
        public string TenTL { get; set; }
    }

    public class CongTyPH
    {
        [Key]
        public int MaCT { get; set; }
        public string TenCT { get; set; }
    }

    public class NhaXuatBan
    {
        [Key]
        public int MaNXB { get; set; }
        public string TenNXB { get; set; }
    }

    public class TacGia
    {
        [Key]
        public int MaTG { get; set; }
        public string TenTG { get; set; }
    }

    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public int DT { get; set; }
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
       
        public string Role { get; set; }
    }

    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public int MaTL { get; set; }
        public virtual TheLoai TheLoai { get; set; }
        public int MaTG { get; set; }
        public virtual TacGia TacGia { get; set; }
        public string NguoiDich { get; set; }
        public int MaNXB { get; set; }
        public virtual NhaXuatBan NhaXuatBan { get; set; }
        public int MaCT { get; set; }
        public virtual CongTyPH CongTyPH { get; set; }
        public string NgonNgu { get; set; }
        public int TrongLuong { get; set; }
        public string KichThuoc { get; set; }
        public int SoTrang { get; set; }
        public string LoaiBia { get; set; }
        public string ItemImageName { get; set; }
        public DateTime NgayXB { get; set; }
        public string NoiDung { get; set; }
        [Range(1000, 5000000000, ErrorMessage = "Please enter correct value")]
        public int Gia { get; set; }
    }
    
    public class GioHang
    {
        [Key]
        public int ID { get; set; }
        public int MaSach { get; set; }
        public virtual Sach Sach { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayMua { get; set; }
        public Nullable<int> MaKH { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public GioHang() { }
        public GioHang(Sach sach, int SoLuong)
        {
            this.Sach = sach;
            this.SoLuong = SoLuong;
        }
        public GioHang(Sach sach, int SoLuong, DateTime ngayMua, KhachHang khachHang)
        {
            this.Sach = sach;
            this.SoLuong = SoLuong;
            this.NgayMua = ngayMua;
            this.KhachHang = khachHang;
        }
    }
}