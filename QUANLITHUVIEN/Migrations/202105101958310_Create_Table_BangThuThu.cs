namespace QUANLITHUVIEN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_BangThuThu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangThuThus",
                c => new
                    {
                        MaThuThu = c.String(nullable: false, maxLength: 128),
                        TenThuThu = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaThuThu);
            
            CreateTable(
                "dbo.DangKyDacBiets",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 128),
                        SoDangKy = c.String(),
                        NgayVaoSo = c.String(),
                        MaKho = c.String(),
                    })
                .PrimaryKey(t => t.MaSach);
            
            CreateTable(
                "dbo.DocGias",
                c => new
                    {
                        SoThe = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        NgaySinh = c.String(),
                        GioiTinh = c.String(),
                        ChoOHienTai = c.String(),
                        NgayCapThe = c.String(),
                        HanDungThe = c.String(),
                    })
                .PrimaryKey(t => t.SoThe);
            
            CreateTable(
                "dbo.KhoSachs",
                c => new
                    {
                        MaKho = c.String(nullable: false, maxLength: 128),
                        TenKho = c.String(),
                        GhiChu = c.String(),
                    })
                .PrimaryKey(t => t.MaKho);
            
            CreateTable(
                "dbo.MuonTras",
                c => new
                    {
                        SoThuTu = c.String(nullable: false, maxLength: 128),
                        SoThe = c.String(),
                        NgayMuon = c.String(),
                        NgayTra = c.String(),
                        NgayPhaiTra = c.String(),
                        MaSach = c.String(),
                        MaThuThu = c.String(),
                    })
                .PrimaryKey(t => t.SoThuTu);
            
            CreateTable(
                "dbo.NhaXBs",
                c => new
                    {
                        MaNhaXB = c.String(nullable: false, maxLength: 128),
                        TenNhaXB = c.String(),
                        DiaChi = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaXB);
            
            CreateTable(
                "dbo.Sachs",
                c => new
                    {
                        MaSach = c.String(nullable: false, maxLength: 128),
                        TenSach = c.String(),
                        TenTacGia = c.String(),
                        MaNhaXB = c.String(),
                        TenNhaXB = c.String(),
                        NgonNgu = c.String(),
                        MaKho = c.String(),
                    })
                .PrimaryKey(t => t.MaSach);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sachs");
            DropTable("dbo.NhaXBs");
            DropTable("dbo.MuonTras");
            DropTable("dbo.KhoSachs");
            DropTable("dbo.DocGias");
            DropTable("dbo.DangKyDacBiets");
            DropTable("dbo.BangThuThus");
        }
    }
}
