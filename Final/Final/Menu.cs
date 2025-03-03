namespace Final;

class Menu
{
    private const int ChieuDaiKeNgang = 45;

    public LopHoc LopHoc { get; set; }

    public Menu()
    {
        LopHoc = new LopHoc();
    }

    private void XuatTieuDeChucNang(ChucNang chucNang)
    {
        if (chucNang == ChucNang.ThoatChuongTrinh)
            return;

        
        TienIch.XuatKeNgang(ChieuDaiKeNgang);

        switch (chucNang)
        {
            case ChucNang.NhapSinhVienTuBanPhim:
                Console.WriteLine("Nhap sinh vien tu ban phim");
                break;

            case ChucNang.NhapDanhSachSinhVienMacDinh:
                Console.WriteLine("Nhap danh sinh vien mac dinh");
                break;

            case ChucNang.HienThiDanhSachSinhVien:
                Console.WriteLine("Hien thi danh sinh vien");
                break;
            
            case ChucNang.TinhDiemTrungBinhCong:
                Console.WriteLine("Tinh diem trung binh cong");
                break;
            
            case ChucNang.TimSinhVienTheoMaSo:
                Console.WriteLine("Tim sinh vien theo ma so");
                break;
            
            case ChucNang.TimDanhSachSinhVienTheoTen:
                Console.WriteLine("Tim danh sinh vien theo ten");
                break;
            
            case ChucNang.TimDanhSachSinhVienKhongDat:
                Console.WriteLine("Tim danh sinh vien khong dat");
                break;
            
            case ChucNang.XoaSinhVienTheoMaSo:
                Console.WriteLine("Xoa sinh vien theo ma so");
                break;

            default:
                Console.WriteLine("Chuc nang khong hop le");
                break;
        }

        TienIch.XuatKeNgang(ChieuDaiKeNgang);
    }

    public void XuatMenu()
    {
        TienIch.XuatKeNgang(ChieuDaiKeNgang);
        Console.WriteLine("CHUONG TRINH QUAN LY LOP HOC 👨‍🎓");
        TienIch.XuatKeNgang(ChieuDaiKeNgang);

        Console.WriteLine($"So luong sinh vien trong lop: {LopHoc.SoLuongSinhVien}");
        TienIch.XuatKeNgang(ChieuDaiKeNgang);

        Console.WriteLine("Danh sach chuc nang:");
        
        Console.WriteLine($"{(int)ChucNang.ThoatChuongTrinh}: Thoat chuong trinh");
        Console.WriteLine($"{(int)ChucNang.NhapSinhVienTuBanPhim}: Nhap sinh vien tu ban phim");
        Console.WriteLine($"{(int)ChucNang.NhapDanhSachSinhVienMacDinh}: Nhap danh sach sinh vien mac dinh");
        Console.WriteLine($"{(int)ChucNang.HienThiDanhSachSinhVien}: Hien thi danh sinh vien");
        Console.WriteLine($"{(int)ChucNang.TinhDiemTrungBinhCong}: Tinh diem trung binh cong");
        Console.WriteLine($"{(int)ChucNang.TimSinhVienTheoMaSo}: Tim sinh vien theo ma so");
        Console.WriteLine($"{(int)ChucNang.TimDanhSachSinhVienTheoTen}: Tim danh sinh vien theo ten");
        Console.WriteLine($"{(int)ChucNang.TimDanhSachSinhVienKhongDat}: Tim danh sinh vien khong dat");
        Console.WriteLine($"{(int)ChucNang.XoaSinhVienTheoMaSo}: Xoa sinh vien theo ma so");
        
        TienIch.XuatKeNgang(ChieuDaiKeNgang);
    }


    public ChucNang ChonMenu()
    {
        int menu;

        while (true)
        {
            Console.Write("Chon chuc nang can thuc hien: #");
            var input = Console.ReadLine();

            try
            {
                menu = Convert.ToInt32(input);
                break;
            }
            catch (Exception)
            {
                Console.WriteLine("Chuc nang da chon khong hop le!");
            }
        }

        return (ChucNang)menu;
    }

    public void XuLyChucNang(ChucNang chucNang)
    {
        XuatTieuDeChucNang(chucNang);

        switch (chucNang)
        {
            case ChucNang.ThoatChuongTrinh:
                TienIch.XuatKeNgang(ChieuDaiKeNgang);
                Console.WriteLine("Cam on da su dung chuong trinh");
                TienIch.XuatKeNgang(ChieuDaiKeNgang);
                
                break;

            case ChucNang.NhapSinhVienTuBanPhim:
                var sinhVien = LopHoc.NhapSinhVienTuBanPhim();
                LopHoc.ThemSinhVien(sinhVien);
                Console.WriteLine();
                Console.WriteLine("Da them sinh vien vao lop hoc");
                break;

            case ChucNang.NhapDanhSachSinhVienMacDinh:
                LopHoc.NhapDanhSachSinhVienMacDinh();
                Console.WriteLine("Da nhap danh sach sinh vien mac dinh");
                break;

            case ChucNang.HienThiDanhSachSinhVien:
                LopHoc.HienThiDanhSachSinhVien();
                break;
            
            case ChucNang.TinhDiemTrungBinhCong:
                var diemTrungBinh = LopHoc.TinhDiemTrungBinh();
                Console.WriteLine($"Diem trung binh cua lop: {Math.Round(diemTrungBinh, 2)}");
                break;
            
            case ChucNang.TimSinhVienTheoMaSo:
                Console.Write("Nhap ma so sinh vien can tim: #");
                var maSoSinhVienCanTim = Console.ReadLine();
                if (string.IsNullOrEmpty(maSoSinhVienCanTim))
                {
                    Console.WriteLine("Ma so sinh vien khong hop le");
                    break;
                }
                
                var ketQua = LopHoc.TimSinhVienTheoMaSo(maSoSinhVienCanTim);
                if (ketQua is null)
                    Console.WriteLine($"Khong tim thay sinh vien co ma so \"{maSoSinhVienCanTim}\"");
                else
                    Console.WriteLine(ketQua);
                
                break;
            
            case ChucNang.TimDanhSachSinhVienTheoTen:
                Console.Write("Nhap ten sinh vien can tim: #");
                var tenSinhVien = Console.ReadLine();
                if (string.IsNullOrEmpty(tenSinhVien))
                {
                    Console.WriteLine("Ten sinh vien khong hop le");
                    break;
                }
                
                var danhSachTheoTen = LopHoc.TimDanhSachSinhVienTheoTen(tenSinhVien);
                if (danhSachTheoTen.Count == 0)
                    Console.WriteLine($"Khong tim thay sinh vien co ten \"{tenSinhVien}\"");
                else 
                    LopHoc.HienThiDanhSachSinhVien(danhSachTheoTen);
                
                break;
            
            case ChucNang.TimDanhSachSinhVienKhongDat:
                var danhSachTheoDiem = LopHoc.TimDanhSachSinhVienKhongDat();
                
                if (danhSachTheoDiem.Count == 0)
                    Console.WriteLine("Toan bo sinh vien deu dat diem chuan");
                else 
                    LopHoc.HienThiDanhSachSinhVien(danhSachTheoDiem);
                
                break;
            
            case ChucNang.XoaSinhVienTheoMaSo:
                Console.Write("Nhap ma so sinh vien can xoa: #");
                var maSoSinhVienCanXoa = Console.ReadLine();
                if (string.IsNullOrEmpty(maSoSinhVienCanXoa))
                {
                    Console.WriteLine("Ma so sinh vien khong hop le");
                    break;
                }
                
                LopHoc.XoaSinhVienTheoMaSo(maSoSinhVienCanXoa);
                Console.WriteLine($"Da xoa sinh vien co ma so \"{maSoSinhVienCanXoa}\"");
                Console.WriteLine("Danh sach lop hoc moi");
                LopHoc.HienThiDanhSachSinhVien();
                
                break;

            default:
                Console.WriteLine("Chuc nang da chon khong hop le!");
                break;
        }

        if (chucNang != ChucNang.ThoatChuongTrinh)
        {
            TienIch.XuatKeNgang(ChieuDaiKeNgang);
            Console.Write("Vui long nhan phim \"Enter\" de tiep tuc >> ");
            Console.ReadKey();
        }
    }
}