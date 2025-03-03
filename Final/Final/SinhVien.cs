using System.Text;

namespace Final;

class SinhVien
{
    public double DiemTrungBinh { get; set; }
    public string HoVaTen { get; set; }
    public string MaSinhVien { get; set; }
    public DateTime NgaySinh { get; set; }

    public string Ho
    {
        get
        {
            var danhSachCacTu = HoVaTen.Split(" ");

            if (danhSachCacTu.Length == 0) return "";
            return danhSachCacTu[0];
        }
    }

    public string Ten
    {
        get
        {
            var danhSachCacTu = HoVaTen.Split(" ");

            if (danhSachCacTu.Length == 0) return "";
            return danhSachCacTu[danhSachCacTu.Length - 1];
        }
    }

    public SinhVien(double diemTrungBinh, string hoVaTen, string maSinhVien, DateTime ngaySinh)
    {
        DiemTrungBinh = diemTrungBinh;
        HoVaTen = hoVaTen;
        MaSinhVien = maSinhVien;
        NgaySinh = ngaySinh;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine("Thong tin sinh vien");
        builder.AppendLine($"- Ho Va Ten: {HoVaTen}");
        builder.AppendLine($"- Ma sinh vien: {MaSinhVien}");
        builder.AppendLine($"- Ngay sinh vien: {NgaySinh.ToString("dd/MM/yyyy")}");
        builder.AppendLine($"- Diem Trung Binh: {DiemTrungBinh}");

        return builder.ToString();
    }
}