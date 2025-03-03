using System.Globalization;

namespace Final;

class LopHoc
{
    private List<SinhVien> DanhSachSinhVien { get; set; }

    public int SoLuongSinhVien
    {
        get => DanhSachSinhVien.Count;
    }

    public LopHoc()
    {
        DanhSachSinhVien = new List<SinhVien>();
    }

    public void ThemSinhVien(SinhVien sinhVien)
    {
        DanhSachSinhVien.Add(sinhVien);
    }

    public SinhVien NhapSinhVienTuBanPhim()
    {
        SinhVien sinhVien;
        
        while (true)
        {
            Console.Write("Nhap ma so sinh vien >> ");
            var maSinhVienInput = Console.ReadLine();
            if (string.IsNullOrEmpty(maSinhVienInput))
            {
                Console.WriteLine("Ma so sinh vien khong hop le");
                continue;
            }

            Console.Write("Nhap ho va ten sinh vien >> ");
            var hoVaTenInput = Console.ReadLine();
            if (string.IsNullOrEmpty(hoVaTenInput))
            {
                Console.WriteLine("Ho va ten sinh vien khong hop le");
                continue;
            }

            Console.Write("Nhap ngay sinh DD/MM/YYYY >> ");
            var ngaySinhInput = Console.ReadLine();

            if (string.IsNullOrEmpty(ngaySinhInput))
            {
                Console.WriteLine("Ngay sinh khong hop le");
                continue;
            }

            DateTime ngaySinh;
            try
            {
                ngaySinh = DateTime.ParseExact(ngaySinhInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.WriteLine("Ngay sinh khong hop le");
                continue;
            }

            Console.Write("Nhap diem so trung binh >> ");
            var diemTrungBinhInput = Console.ReadLine();
            
            if (string.IsNullOrEmpty(diemTrungBinhInput))
            {
                Console.WriteLine("Diem trung binh khong hop le");
                continue;
            }

            double diemTrungBinh;
            try
            {
                diemTrungBinh = Convert.ToDouble(diemTrungBinhInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Diem trung binh khong hop le");
                continue;
            }

            sinhVien = new SinhVien(diemTrungBinh, hoVaTenInput, maSinhVienInput, ngaySinh);
            break;
        }

        return sinhVien;
    }

    public void NhapDanhSachSinhVienMacDinh()
    {
        DanhSachSinhVien.Add(new SinhVien(8.5, "Nguyen Trong Hieu", "1812756", new DateTime(2000, 3, 11)));
        DanhSachSinhVien.Add(new SinhVien(7.9, "Le Minh Hoang", "1912345", new DateTime(2001, 5, 22)));
        DanhSachSinhVien.Add(new SinhVien(8.3, "Tran Van Binh", "1912346", new DateTime(2000, 8, 15)));
        DanhSachSinhVien.Add(new SinhVien(6.5, "Pham Thi Lan", "1912347", new DateTime(2002, 1, 30)));
        DanhSachSinhVien.Add(new SinhVien(9.0, "Nguyen Van An", "1912348", new DateTime(1999, 12, 10)));
        DanhSachSinhVien.Add(new SinhVien(7.2, "Do Thi Mai", "1912349", new DateTime(2001, 7, 5)));
        DanhSachSinhVien.Add(new SinhVien(8.8, "Hoang Tuan Kiet", "1912350", new DateTime(2000, 4, 18)));
        DanhSachSinhVien.Add(new SinhVien(6.9, "Bui Thanh Tam", "1912351", new DateTime(2002, 9, 25)));
        DanhSachSinhVien.Add(new SinhVien(7.6, "Dang Van Son", "1912352", new DateTime(2001, 11, 3)));
        DanhSachSinhVien.Add(new SinhVien(9.2, "Nguyen Thi Hong", "1912353", new DateTime(2000, 6, 20)));
        DanhSachSinhVien.Add(new SinhVien(8.1, "Le Van Dung", "1912354", new DateTime(1999, 3, 14)));
        DanhSachSinhVien.Add(new SinhVien(7.4, "Trinh Minh Chau", "1912355", new DateTime(2002, 10, 8)));
    }

    public void HienThiDanhSachSinhVien()
    {
        HienThiDanhSachSinhVien(DanhSachSinhVien);
    }

    public void HienThiDanhSachSinhVien(List<SinhVien> danhSachSinhVien)
    {
        int chieuDai = 5 + 8 + 30 + 12 + 17 + 16;

        TienIch.XuatKeNgang('-', chieuDai);
        Console.WriteLine("| {0, 5} | {1,8} | {2,-30} | {3,12} | {4,17} |", "STT", "Ma so", "Ho va ten", "Ngay sinh",
            "Diem trung binh");
        TienIch.XuatKeNgang('-', chieuDai);

        int soThuTu = 1;
        foreach (var sinhVien in danhSachSinhVien)
        {
            Console.WriteLine("| {0, 5} | {1,8} | {2,-30} | {3,12} | {4,17} |", soThuTu, sinhVien.MaSinhVien,
                sinhVien.HoVaTen,
                sinhVien.NgaySinh.ToString("dd/MM/yyyy"), sinhVien.DiemTrungBinh);

            soThuTu++;
        }

        TienIch.XuatKeNgang('-', chieuDai);
    }

    public double TinhDiemTrungBinh()
    {
        double tong = 0;

        foreach (var sinhVien in DanhSachSinhVien)
        {
            tong += sinhVien.DiemTrungBinh;
        }

        return tong / SoLuongSinhVien;
    }

    public SinhVien? TimSinhVienTheoMaSo(string maSoSinhVien)
    {
        foreach (var sinhVien in DanhSachSinhVien)
        {
            if (sinhVien.MaSinhVien == maSoSinhVien)
                return sinhVien;
        }

        return null;
    }

    public List<SinhVien> TimDanhSachSinhVienTheoTen(string tenSinhVien)
    {
        var danhSachSinhVien = new List<SinhVien>();

        foreach (var sinhVien in DanhSachSinhVien)
        {
            if (sinhVien.Ten.ToLower() == tenSinhVien.ToLower())
                danhSachSinhVien.Add(sinhVien);
        }

        return danhSachSinhVien;
    }

    public List<SinhVien> TimDanhSachSinhVienKhongDat(double diemChuan = 5)
    {
        var danhSachSinhVien = new List<SinhVien>();

        foreach (var sinhVien in DanhSachSinhVien)
        {
            if (sinhVien.DiemTrungBinh < diemChuan)
                danhSachSinhVien.Add(sinhVien);
        }

        return danhSachSinhVien;
    }

    public void XoaSinhVienTheoMaSo(string maSoSinhVien)
    {
        var danhSachSinhVien = new List<SinhVien>();

        foreach (var sinhVien in DanhSachSinhVien)
        {
            if (sinhVien.MaSinhVien != maSoSinhVien)
                danhSachSinhVien.Add(sinhVien);
        }

        DanhSachSinhVien = danhSachSinhVien;
    }
}